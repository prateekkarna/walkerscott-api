using System;
using Microsoft.AspNetCore.Http;

namespace walkerscott_application.Utilities
{
	public class RequestInfo
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public string Host { get
			{
				return _httpContextAccessor.HttpContext.Request.Host.ToString();
			} }

		public string QueryString {
			get {
				return _httpContextAccessor.HttpContext.Request.QueryString.ToString();
			}
		}

        public string Path
        {
            get
            {
				return _httpContextAccessor.HttpContext.Request.Path.ToString();
            }
        }
        public RequestInfo(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
	}
}

