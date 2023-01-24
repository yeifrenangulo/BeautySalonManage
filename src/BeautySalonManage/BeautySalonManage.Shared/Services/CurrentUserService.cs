﻿using BeautySalonManage.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BeautySalonManage.Shared.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserAsync()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue("userName");
        }
    }
}
