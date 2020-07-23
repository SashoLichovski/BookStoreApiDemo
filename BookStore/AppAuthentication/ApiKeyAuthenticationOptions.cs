﻿using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.AppAuthentication
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
            public const string DefaultScheme = "ApiKey";
            public string Scheme = DefaultScheme;
            public string AuthenticationType = DefaultScheme;
    }
}
