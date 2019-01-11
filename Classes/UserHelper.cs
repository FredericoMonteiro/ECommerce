using ECommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ECommerce.Classes
{
    public class UserHelper 
    {
        public class UsersHelper : IDisposable
        {
            private static ApplicationDbContext userContext = new ApplicationDbContext();
            private static ECommerceContext db = new ECommerceContext();

            // Delete user
            public static bool DeleteUser(string userName)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userASP = UserManager.FindByEmail(userName);
                if (userASP == null)
                {
                    return false;
                }

                var response = UserManager.Delete(userASP);
                return response.Succeeded;
            }

            //Update User
            public static bool UpdateUserName(string CurrentUserName, string newUserName)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userASP = UserManager.FindByEmail(CurrentUserName);
                if (userASP == null)
                {
                    return false;
                }

                userASP.UserName = newUserName;
                userASP.Email = newUserName;
                
                var response = UserManager.Update(userASP);
                return response.Succeeded;
            }

            public static void CheckRole(string roleName)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));
                if (!roleManager.RoleExists(roleName))
                {
                    roleManager.Create(new IdentityRole(roleName));
                }
            }

            public static void CheckSuperUser()
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var email = WebConfigurationManager.AppSettings["AdminUser"];
                var password = WebConfigurationManager.AppSettings["AdminPassword"];
                var userASP = UserManager.FindByEmail(email);
                if (userASP == null)
                {
                    CreateUserASP(email, "Admin", password);
                    return;
                }
                UserManager.AddToRole(userASP.Id, "Admin");
            }

            public static void CreateUserASP(string email, string roleName)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

                var userASP = new ApplicationUser
                {
                    Email = email,
                    UserName = email
                };
                userManager.Create(userASP, email);
                userManager.AddToRole(userASP.Id, roleName);
            }

            public static void CreateUserASP(string email, string roleName, string password)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

                var userASP = new ApplicationUser
                {
                    Email = email,
                    UserName = email
                };
                userManager.Create(userASP, password);
                userManager.AddToRole(userASP.Id, roleName);
            }

            public static async Task PasswordRecovery(string email)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userASP = userManager.FindByEmail(email);

                if (userASP == null)
                {
                    return;
                }

                var user = db.Users.Where(tp => tp.UserName == email).FirstOrDefault();
                if (user == null)
                {
                    return;
                }

                var random = new Random();
                var newPassword = string.Format("{0}{1}{2:04} ",
                    user.FirstName.Trim().ToUpper().Substring(0, 1),
                    user.LastName.Trim().ToLower(),
                    random.Next(10000));

                userManager.RemovePassword(userASP.Id);
                userManager.AddPassword(userASP.Id, newPassword);

                var subject = "Password Changed";
                var body = string.Format(@"
                <h1>Password Changed</h1>
                <p>Your new Password is: <strong>{0}</strong></p>
                <p>Please change it for one, that you remember easyly",
                    newPassword);
                await MailHelper.SendMail(email, subject, body);
            }



            public void Dispose()
            {
                userContext.Dispose();
                db.Dispose();
            }
        }
        
    }
}