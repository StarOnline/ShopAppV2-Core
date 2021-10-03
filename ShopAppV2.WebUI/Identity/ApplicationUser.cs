﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShopAppV2.WebUI.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
