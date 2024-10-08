﻿using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
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
        var model = _iMapperService.Map<IEnumerable<UserResponseDTO>>(await _iUserService.GetAllUserAsync());
        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate([FromBody] UserFilter userFilter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);
        var model = await _iUserService.GetAllUserPaginateAsync(userFilter);
        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _iUserService.ExistUserByIdAsync(id))
        {
            var model = _iMapperService.Map<UserResponseDTO>(await _iUserService.GetUserByIdAsync(id));
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
    }

    [HttpGet("GetByLogin/{login}")]
    public async Task<IActionResult> GetByLogin(string login)
    {
        if (await _iUserService.ExistUserByLoginAsync(login))
        {
            var model = _iMapperService.Map<UserResponseDTO>(await _iUserService.GetUserByLoginAsync(login));
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
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
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] UserRequestDTO userRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        User user = ApplyMapToEntity<UserRequestDTO, User>(userRequestDTO);
        var result = await _iUserService.CreateUserAsync(user);

        if (result)
            return CreatedAtAction(nameof(Create), user);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromBody] UserRequestDTO userRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        User user = ApplyMapToEntity<UserRequestDTO, User>(userRequestDTO);

        if (id != userRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iUserService.ExistUserByIdAsync(userRequestDTO.Id.GetValueOrDefault()))
        {
            var result = await _iUserService.UpdateUserAsync(id, user);
            if (result)
                return NoContent();
            else
                return CustomResponse();
        }

        return CustomNotFound();
    }

    [HttpDelete("LogicDelete/{id:long}")]
    public async Task<IActionResult> LogicDelete(long id)
    {
        if (await _iUserService.ExistUserByIdAsync(id))
        {
            bool result = await _iUserService.DeleteUserLogicAsync(id);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse();
        }

        return CustomNotFound();
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
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETEPHYSICAL);
            else
                return CustomResponse();
        }

        NotificationError(FixConstants.NO_AUTHORIZATION);
        return CustomResponse();
    }

    [HttpPost("ExportData")]
    public async Task<IActionResult> ExportData([FromBody] UserFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var list = await _iUserService.GetAllUserPaginateAsync(filter);
        if (list?.Results?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelData = _iMapperService.Map<IEnumerable<UserExcelDTO>>(list.Results);
            var excelName = $"Users._{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomNotFound();
    }
}
