using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebWatchingAnime.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }

        //public DateTime? BirthDay { set; get; }

        //public decimal Balance { get; set; }

        //public string Avatar { get; set; }

        //public DateTime DateCreated { get; set; }
        ///public DateTime DateModified { get; set; }
        public bool Status { get; set; }
    }
}
