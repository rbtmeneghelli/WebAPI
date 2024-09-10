using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_VerticalSliceArc.Domain.Generics;

[ApiController]
[Route("api/[controller]")]
public abstract class GenericController : ControllerBase
{
    protected readonly IMediator _iMediator;

    protected GenericController(IMediator iMediator)
    {
        _iMediator = iMediator;
    }
}
