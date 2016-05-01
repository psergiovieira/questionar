using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ApiQuestionar.Auth
{
    public class IdentityUser : IUser
    {
        public string Id
        {
            set; get;
        }
                
        public string UserName
        {
            get; set;
        }

        public string Password
        {
            get;set;
        }
    }
}