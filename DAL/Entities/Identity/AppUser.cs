using Microsoft.AspNetCore.Identity;


namespace DAL.Entities.Identity
{
    public class AppUser  : IdentityUser
    {


        public string Display_Name { get; set; }

        public int age { get; set; }

        public Address Address { get; set; }


    }
}
