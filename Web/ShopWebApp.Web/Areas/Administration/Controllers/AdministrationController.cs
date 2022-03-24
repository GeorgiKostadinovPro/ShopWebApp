namespace ShopWebApp.Web.Areas.Administration.Controllers
{
    using ShopWebApp.Common;
    using ShopWebApp.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
