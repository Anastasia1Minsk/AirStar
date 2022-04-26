using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace AirStar.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IUserService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> RegistrationAsync(RegistrationViewModel registrationViewModel)
        {
            return await _service.InsertAsync(_mapper.Map<User>(registrationViewModel));
        }

        public async Task<bool> LogInAsync(LogInViewModel logInViewModel)
        {
            var user = await _service.GetByEmailAsync(logInViewModel.Email);
            if (user == null || logInViewModel.Password != user.Password || _httpContextAccessor.HttpContext == null)
            {
                return false;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.RoleType.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return true;
        }

        public async Task LogOffAsync()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                await _httpContextAccessor.HttpContext.SignOutAsync();
            }
        }
        
    }
}
