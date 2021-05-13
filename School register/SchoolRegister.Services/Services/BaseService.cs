using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.DAL.EF;

namespace SchoolRegister.Services.Services
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext DbContext;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;

        protected readonly UserManager<User> UserManager;
        public BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager)
        {
            DbContext = dbContext;
            Mapper = mapper;
            Logger = logger;
            UserManager = userManager;
        }

    }
}