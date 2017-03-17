using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT.Security.App_Start
{
    public class WebToken
    {
        public string Role { get; set; }
        public string Team { get; set; }
        public string Authority { get; set; }
    }
}