using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using ApexaApp.API.Models;

namespace ApexaApp.API.Data
{
    public class ApexaContextSeed
    {
        public static async Task SeedAsync(ApexaContext context) 
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if(!context.Advisors.Any())
            {
                var advisorsData = File.ReadAllText("Data/SeedData/advisors.json");
                var advisors = JsonSerializer.Deserialize<List<Advisor>>(advisorsData);
                context.Advisors.AddRange(advisors!);                
            }

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

           
        }
    }
}