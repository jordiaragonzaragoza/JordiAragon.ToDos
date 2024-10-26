namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Controllers.V1
{
    using JordiAragon.SharedKernel.Presentation.WebApi.Controllers;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0", Deprecated = false)]
    public abstract class BaseVersionedApiController : BaseApiController
    {
    }
}