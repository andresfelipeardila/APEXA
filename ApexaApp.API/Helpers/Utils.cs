using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexaApp.API.Helpers
{
    public static class Utils
    {
        public static Enums.HealthStatus GenerateRandomHealthStatus()
        {
            Random random = new Random();
            int randomValue = random.Next(1, 101); // Generates a random number between 1 and 100

            if (randomValue <= 60)
                return Enums.HealthStatus.Green; // 60% probability
            else if (randomValue <= 80)
                return Enums.HealthStatus.Yellow; // 20% probability (60 + 20)
            else
                return Enums.HealthStatus.Red; // 20% probability
        }
    }
}