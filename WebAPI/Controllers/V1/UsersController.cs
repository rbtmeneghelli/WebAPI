using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.V1.Controllers;

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
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
        : base(iHttpContextAccessor, iGenericNotifyLogsService)

    {
        _iUserService = iUserService;
        _iFileService = iFileService;
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iUserService.GetAllUserAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate([FromBody] UserFilter userFilter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);
        var model = await _iUserService.GetAllUserPaginateAsync(userFilter);
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _iUserService.ExistUserByIdAsync(id))
        {
            var model = await _iUserService.GetUserByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpGet("GetByLogin/{login}")]
    public async Task<IActionResult> GetByLogin(string login)
    {
        if (await _iUserService.ExistUserByLoginAsync(login))
        {
            var model = await _iUserService.GetUserByLoginAsync(login);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, await _iUserService.GetUsersAsync(), FixConstants.SUCCESS_IN_DDL);
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
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] UserRequestDTO userRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _iUserService.CreateUserAsync(userRequestDTO);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.CREATE_CODE, userRequestDTO);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromBody] UserRequestDTO userRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        if (id != userRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        if (await _iUserService.ExistUserByIdAsync(userRequestDTO.Id.GetValueOrDefault()))
        {
            var result = await _iUserService.UpdateUserAsync(id, userRequestDTO);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.NO_CONTENT_CODE);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpDelete("LogicDelete/{id:long}")]
    public async Task<IActionResult> LogicDelete(long id)
    {
        if (await _iUserService.ExistUserByIdAsync(id))
        {
            bool result = await _iUserService.DeleteUserLogicAsync(id);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    /// <summary>
    /// Metodo para exclusão Fisica do registro
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("PhysicalDelete/{id:long}")]
    public async Task<IActionResult> PhysicalDelete(long id)
    {
        var existId = await _iUserService.ExistUserByIdAsync(id);
        var canDelete = await _iUserService.CanDeleteUserByIdAsync(id);

        if (existId && canDelete)
        {
            bool result = await _iUserService.DeleteUserPhysicalAsync(id);

            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, FixConstants.SUCCESS_IN_DELETEPHYSICAL);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        NotificationError(FixConstants.NO_AUTHORIZATION);
        return CustomResponse(ConstantHttpStatusCode.UNAUTHORIZED_CODE);
    }

    [HttpPost("ExportData")]
    public async Task<IActionResult> ExportData([FromBody] UserFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var excelData = await _iUserService.ExportData(filter);
        var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
        var excelName = $"Users._{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
        var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
        return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
    }
}
