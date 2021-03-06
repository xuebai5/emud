﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Emprise.Application.Admin.Dtos;
using Emprise.Application.Admin.Services;
using Emprise.Domain.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Emprise.Web.Areas.Admin.Pages
{
    [AllowAnonymous]
    public class LoginModel : BaseAdminPageModel
    {
        private readonly IAdminAppService _adminAppService;
        private readonly AppConfig _appConfig;
        private readonly IMapper _mapper;
        public LoginModel(
            ILogger<LoginModel> logger,
            IAdminAppService adminAppService,
            IMapper mapper,
            IOptionsMonitor<AppConfig> appConfig)
            : base(logger)
        {
            _mapper = mapper;
            _adminAppService = adminAppService;
            _appConfig = appConfig.CurrentValue;

        }

        public bool HasSetAdmin { get; set; }

        public string ErrorMessage { get; set; }

        [BindProperty]
        public LoginInput LoginInput { get; set; }

        public async Task OnGetAsync()
        {
            var adminCount = await _adminAppService.GetCount();
            HasSetAdmin = adminCount > 0;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ErrorMessage = "";
            if (!ModelState.IsValid)
            {
                ErrorMessage = ModelState.Where(e => e.Value.Errors.Count > 0).Select(e => e.Value.Errors.First().ErrorMessage).First();
                var adminCount = await _adminAppService.GetCount();
                HasSetAdmin = adminCount > 0;
                return Page();
            }

            var result = await _adminAppService.Login(LoginInput);
            if (!result.IsSuccess)
            {
                ErrorMessage = result.Message;
                var adminCount = await _adminAppService.GetCount();
                HasSetAdmin = adminCount > 0;
                return Page();
            }
            else
            {
                return RedirectToPage("Index");
            }

            /*
            AdminEntity admin = null;
            if (_db.Admins.Count() == 0)
            {
                admin = new AdminEntity
                {
                    Name = LoginInput.Name,
                    Password = LoginInput.Password.ToMd5()
                };
                _db.Admins.Add(admin);
                await _db.SaveChangesAsync();

                await AddSuccess(new OperatorLog
                {
                    Type = OperatorLogType.登录,
                    Content = $"初始化帐号:{admin.Name}",
                    Name = LoginInput.Name
                });
            }
            else
            {
                admin = _db.Admins.FirstOrDefault(x => x.Name == LoginInput.Name);
                if (admin == null)
                {
                    ErrorMessage = "账号或密码错误";
                    HasSetAdmin = _db.Admins.Count() != 0;

                    await AddError(new OperatorLog
                    {
                        Type = OperatorLogType.登录,
                        Content = JsonConvert.SerializeObject(LoginInput),
                        Name = LoginInput.Name
                    });
                    return Page();
                }

                if (admin.Password != LoginInput.Password.ToMd5())
                {
                    ErrorMessage = "账号或密码错误";
                    HasSetAdmin = _db.Admins.Count() != 0;

                    await AddError(new OperatorLog
                    {
                        Type = OperatorLogType.登录,
                        Content = JsonConvert.SerializeObject(LoginInput),
                        Name = LoginInput.Name
                    });
                    return Page();
                }
            }

            var claims = new[] { 
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()), 
                new Claim(ClaimTypes.Name, admin.Name)
            };



            var claimsIdentity = new ClaimsIdentity(claims, "Default");
            ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("admin", user, new AuthenticationProperties { IsPersistent = true, AllowRefresh = true, ExpiresUtc = DateTimeOffset.Now.AddDays(30) });

            await AddSuccess(new OperatorLog
            {
                Type = OperatorLogType.登录,
                Content = "", 
                Name = LoginInput.Name
            });


            return RedirectToPage("Index");
            */
        }
    }
}