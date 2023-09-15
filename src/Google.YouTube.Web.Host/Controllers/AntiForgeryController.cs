﻿using Microsoft.AspNetCore.Antiforgery;

namespace Google.YouTube.Web.Controllers
{
    public class AntiForgeryController : YouTubeControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
