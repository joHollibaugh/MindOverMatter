using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindOverMatter.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.DbContexts
{
    public class ProfileContext : IdentityDbContext<ApplicationUser>
    {
        public ProfileContext(DbContextOptions<ProfileContext> options): base(options)
        {

        }
    }
}
