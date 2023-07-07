using DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL
{
    public  class Edu_ChatbotDataSeed
    {

        public static async Task SeedAsycn(EduChatbot_DB_Context context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Tracks.Any())
                {
                    var TracksData = File.ReadAllText("../DAL/Data/DataSeeds/Tracks.json");
                    var Tracks = JsonSerializer.Deserialize<List<Tracks>>(TracksData);
                    foreach (var track in Tracks)
                        context.Tracks.Add(track);
                    await context.SaveChangesAsync();
                }
          


                if (context.Courses.Any())
                {
                    var courcesData = File.ReadAllText("../DAL/Data/DataSeeds/courses.json");
                    var Courses = JsonSerializer.Deserialize<List<Courses>>(courcesData);
                    foreach (var course in Courses)
                        context.Courses.Add(course);
                    await context.SaveChangesAsync();
                }

               
              


                if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Edu_ChatbotDataSeed>();
                logger.LogError(ex.Message);

            }            
        }
    }
}
