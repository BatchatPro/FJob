using FJob.Access.Models;
using Microsoft.AspNetCore.Identity;

namespace FJob.API.Extensions;

public class RoleInitializer
{
    public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        string adminEmail = "goblindev02@gmail.com";
        string adminPassword = "12345678dev";

        var roles = new Dictionary<string, string>()
        {
            { RoleConst.ADMIN, "Admin" },
            { RoleConst.NEWUSER, "NewUser" },
            { RoleConst.EMPLOYER, "employer" },
            { RoleConst.EMPLOYEE, "employee" },
            { RoleConst.SUPERVISOR, "supervisor" },
        };

        foreach (var role in roles)
            if (await roleManager.FindByNameAsync(role.Key) == null)
                await roleManager.CreateAsync(new Role(role.Key, role.Value));

        User user = await userManager.FindByNameAsync(adminEmail);
        if (user != null)
        {
            await userManager.AddToRolesAsync(user, new string[] { RoleConst.ADMIN });
            await userManager.AddToRolesAsync(user, new string[] { RoleConst.EMPLOYER });
            await userManager.AddToRolesAsync(user, new string[] { RoleConst.EMPLOYEE });
            await userManager.AddToRolesAsync(user, new string[] { RoleConst.SUPERVISOR });
        }

        else
        {
            user = new User
            {
                LastName = "Nabijonov",
                FirstName = "Abdulaziz",
                MiddleName = "Axroriddin O'g'li",
                PhoneNumber = "+998932505255",
                Email = adminEmail,
                UserName = adminEmail,
                Location = "Buyuk Ipak Yo'li Metrosi Yonida.",
                Gender = "Male",
                BirthDate = new DateTime(2002, 06, 17),
            };
            IdentityResult result = await userManager.CreateAsync(user,adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(user, new string[] { RoleConst.SUPERVISOR, RoleConst.EMPLOYER,RoleConst.EMPLOYEE, RoleConst.ADMIN } );
            }
        }
    }
        
}
