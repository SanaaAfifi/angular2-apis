using Jokes.APIs.Models;
using Jokes.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jokes.APIs.DataContext
{
    public class JokesMemeber : IdentityUser
    {
        public virtual JokesMemberInfo MyUserInfo { get; set; }
    }

    public class JokesMemberInfo
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public PhotoLibrary ProfilePhoto { get; set; }
    }


    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }

        public System.Data.Entity.DbSet<JokesMemberInfo> JokesMemberInfo { get; set; }


    }
}