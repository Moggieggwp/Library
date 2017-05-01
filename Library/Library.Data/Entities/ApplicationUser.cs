using System;
using System.Collections.Generic;

using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Library.Data.Entities
{
    public class ApplicationUser : IdentityUser/*<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>*/
    {
        //public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

    //public class ApplicationUserLogin : IdentityUserLogin<int>
    //{
    //}

    //public class ApplicationUserRole : IdentityUserRole<int>
    //{
    //    [ForeignKey("RoleId")]
    //    public virtual ApplicationRole Role { get; set; }

    //    [ForeignKey("UserId")]
    //    public virtual ApplicationUser User { get; set; }
    //}

    //public class ApplicationRole : IdentityRole<int, UserRole>
    //{

    //}

    //public class ApplicationUserClaim : IdentityUserClaim<int>
    //{
    //}
}
