﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CSIT321.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UserAuthentication class
public class UserAuthentication : IdentityUser
{
    [Required]
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName {get; set;}
    [Required]
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName {get; set;}
}

