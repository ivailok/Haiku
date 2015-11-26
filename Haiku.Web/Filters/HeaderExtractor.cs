using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Haiku.Web.Filters
{
    public static class HeaderExtractor
    {
        public static bool ExtractHeader(
            HttpRequestHeaders headers, string headerName, out string headerValue)
        {
            var token = headers.FirstOrDefault(x => x.Key == headerName);
            if (token.Key != null)
            {
                var firstToken = token.Value.FirstOrDefault();
                if (firstToken != null)
                {
                    headerValue = firstToken;
                    return true;
                };
            }

            headerValue = string.Empty;
            return false;
        }
    }
}