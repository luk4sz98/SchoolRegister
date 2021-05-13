using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;

namespace SchoolRegister.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IStringLocalizer Localizer;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        //protected readonly ApplicationDbContext DbContext;
        public BaseController(ILogger logger, IMapper mapper, IStringLocalizer localizer)
        {
            Localizer = localizer;
            Logger = logger;
            Mapper = mapper;
        }
    }
}