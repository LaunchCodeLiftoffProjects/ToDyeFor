using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDyeFor.Models;

namespace ToDyeFor.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<string> GetCurrentUserId()
		{
			ApplicationUser usr = await GetCurrentUserAsync();
			return usr?.Id;
		}

		private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
	}
}
