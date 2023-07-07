using Microsoft.AspNetCore.Identity;

namespace DAL.Entities.Identity
{
   public class AppIdentityDbContextSeed
    {

        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    Display_Name = "Samar_Algammal",
                    UserName = "SamarAlgammal",
                    Email = "samar@gmail.com",
                    
                    Address = new Address
                    {
                        FristName = "Samar",
                        LastName = "Algammal",
                        //Country= "Egypt",          
                    }
                };
        await userManager.CreateAsync(user, "P@ssw0rd");
    }
}




    }
}
