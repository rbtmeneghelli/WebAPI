using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;
using FixConstants = WebAPI.Domain.Constants.FixConstants;

namespace WebAPI.V1.Controllers;


[ApiController]
[ApiVersion("1.0", Deprecated = true)]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]

public sealed class UsersController : GenericController
{
    private readonly IUserService _iUserService;
    private readonly IFileService<UserExcelDTO> _iFileService;
    private readonly GeneralMethod _generalMethod;

    public UsersController(
        IUserService iUserService,
        IFileService<UserExcelDTO> iFileService,
        IMapper iMapperService,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
        : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)

    {
        _iUserService = iUserService;
        _iFileService = iFileService;
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var model = _iMapperService.Map<IEnumerable<UserResponseDTO>>(await _iUserService.GetAllAsync());

        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate([FromBody] UserFilter userFilter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var model = await _iUserService.GetAllPaginateAsync(userFilter);

        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _iUserService.ExistByIdAsync(id))
        {
            var model = _iMapperService.Map<UserResponseDTO>(await _iUserService.GetByIdAsync(id));
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse();
    }

    [HttpGet("GetByLogin/{login}")]
    public async Task<IActionResult> GetByLogin(string login)
    {
        if (await _iUserService.ExistByLoginAsync(login))
        {
            var model = _iMapperService.Map<UserResponseDTO>(await _iUserService.GetByLoginAsync(login));
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse();
    }

    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        return CustomResponse(await _iUserService.GetUsersAsync(), FixConstants.SUCCESS_IN_DDL);
    }

    /// <summary>
    /// Realiza o processo de inserção do usuário
    /// </summary>
    /// <param name="userSendDto"></param>
    /// <returns></returns>
    /// <response code = "201">Sucesso</response>
    /// <response code = "500">Erro interno no servidor</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] UserRequestDTO userRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        User user = _iMapperService.Map<User>(userRequestDTO);

        var result = await _iUserService.AddAsync(user);

        if (result)
            return CreatedAtAction(nameof(Add), user);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(int id, [FromBody] UserRequestDTO userRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        User user = _iMapperService.Map<User>(userRequestDTO);

        if (id != userRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        var result = await _iUserService.UpdateAsync(id, user);

        if (result)
            return NoContent();

        return CustomResponse();
    }

    /// <summary>
    /// Metodo para exclusão Logica do registro
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Remove/{id:long}")]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
            bool result = await _iUserService.DeleteLogicAsync(id);
            if (result)
                NotificationError(FixConstants.ERROR_IN_DELETELOGIC);

            return CustomResponse();
        }
        catch
        {
            NotificationError(FixConstants.NO_AUTHORIZATION);
            return CustomResponse();
        }
    }

    /// <summary>
    /// Metodo para exclusão Fisica do registro
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete/{id:long}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (await _iUserService.CanDeleteAsync(id))
            {
                bool result = await _iUserService.DeletePhysicalAsync(id);
                if (result)
                    NotificationError(FixConstants.ERROR_IN_DELETEPHYSICAL);
            }

            return CustomResponse();
        }
        catch
        {
            if (ProfileId == 1)
                NotificationError(FixConstants.ERROR_IN_DELETEPHYSICAL);
            else
                NotificationError(FixConstants.NO_AUTHORIZATION);

            return CustomResponse();
        }
    }

    [HttpPost("Export2Excel")]
    public async Task<IActionResult> Export2Excel([FromBody] UserFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var list = await _iUserService.GetAllPaginateAsync(filter);
        if (list?.Results?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelData = _iMapperService.Map<IEnumerable<UserExcelDTO>>(list.Results);
            var excelName = $"Usuarios.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return NotFound();
    }
}
