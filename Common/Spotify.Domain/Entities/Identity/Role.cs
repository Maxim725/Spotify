using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Domain.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        Role() : base() { }
        Role(string roleName) : base(roleName) { }
    }
}
