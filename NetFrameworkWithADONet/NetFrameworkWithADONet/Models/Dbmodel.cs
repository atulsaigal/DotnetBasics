//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using System.Web;

//namespace NetFrameworkWithADONet.Models
//{
//    public class Dbmodel:IdentityUser
//    {
//        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Dbmodel> manager)
//        {
//            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
//            // Add custom user claims here
//            return userIdentity;
//        }
//        public class ApplicationDbContext : IdentityDbContext<Dbmodel>
//        {
//            public ApplicationDbContext()
//                : base("Atul_SaigalEntities", throwIfV1Schema: false)
//            {
//            }

//            public static ApplicationDbContext Create()
//            {
//                return new ApplicationDbContext();
//            }
//        }


//    }
//}