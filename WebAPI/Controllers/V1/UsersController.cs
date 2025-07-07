using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;
using FastPackForShare.Controllers.Generics;
using FastPackForShare.Enums;
using FastPackForShare.Default;

namespace WebAPI.V1.Controllers;

[ApiVersion("1.0", Deprecated = true)]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]

public sealed class UsersController : GenericController
{
    private readonly IUserService _iUserService;
    private readonly IFileWriteService<UserExcelDTO> _iFileWriteService;

    public UsersController(
        IUserService iUserService,
        IFileWriteService<UserExcelDTO> iFileWriteService,
        INotificationMessageService iNotificationMessageService)
        : base(iNotificationMessageService)

    {
        _iUserService = iUserService;
        _iFileWriteService = iFileWriteService;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<IEnumerable<UserResponseDTO>>))]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iUserService.GetAllUserAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpPost("GetAllPaginate")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<BasePagedResultModel<UserResponseDTO>>))]
    public async Task<IActionResult> GetAllPaginate([FromBody, Required] UserFilter userFilter)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);
        var model = await _iUserService.GetAllUserPaginateAsync(userFilter);
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }

    [HttpGet("GetById/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<UserResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetById([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        if (await _iUserService.ExistUserByIdAsync(id))
        {
            var model = await _iUserService.GetUserByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpGet("GetByLogin/{login: string}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<UserResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetByLogin([FromRoute, Required]  string login)
    {
        if (await _iUserService.ExistUserByLoginAsync(login))
        {
            var model = await _iUserService.GetUserByLoginAsync(login);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpGet("GetUsers")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<IEnumerable<DropDownListModel>>))]
    public async Task<IActionResult> GetUsers()
    {
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, await _iUserService.GetUsersAsync(), FixConstants.SUCCESS_IN_DDL);
    }


    [HttpPost("Create")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Create([FromBody, Required] UserRequestCreateDTO userRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iUserService.CreateUserAsync(userRequestDTO);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.CREATE_CODE, userRequestDTO);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Update([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id, [FromBody, Required] UserRequestUpdateDTO userRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

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
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> LogicDelete([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
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
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> PhysicalDelete([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
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
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> ExportData([FromBody, Required] UserFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var excelData = await _iUserService.ExportData(filter);
        var memoryStreamResult = SharedExtension.GetMemoryStreamType(EnumFile.Excel);
        var excelName = $"Users._{GuidExtension.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
        var memoryStreamExcel = await _iFileWriteService.CreateExcelFileEPPLUS(excelData, excelName);
        return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
    }
}
