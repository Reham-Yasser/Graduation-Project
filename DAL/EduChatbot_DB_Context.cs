using DAL.Entities;
using DAL.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EduChatbot_DB_Context  : DbContext
    {


        public EduChatbot_DB_Context(DbContextOptions<EduChatbot_DB_Context> options) : base(options)
        {

        }





        public DbSet<Courses> Courses { get; set; }
     
       
      

        public DbSet<Tracks> Tracks { get; set; }

      



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

             //modelBuilder.Entity<DashBoard_Track>().HasKey(a => new { a.Track_Id, a.Dash_Id });

          




        }

    }
}
