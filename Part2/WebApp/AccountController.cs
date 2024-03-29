﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    // TODO 5: unauthorized users should receive 401 status code
    [Route("api/account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ValueTask<Account> Get()
        {
            return _accountService.LoadOrCreateAsync(HttpContext.Request.Cookies["ExternalId"]);/* TODO 3: Get user id from cookie */
        }

        //TODO 6: Endpoint should works only for users with "Admin" Role
        [Authorize (Roles="Admin")]
        [HttpGet("{id}")]
        public Account GetByInternalId([FromRoute] int id)
        {
            return _accountService.GetFromCache(id);
        }

        [HttpPost("counter")]
        public async Task UpdateAccount()
        {
            //Update account in cache, don't bother saving to DB, this is not an objective of this task.
            var account = await Get();
            account.Counter++;
        }
    }
}