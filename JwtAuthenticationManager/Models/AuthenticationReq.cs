﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class AuthenticationReq
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
