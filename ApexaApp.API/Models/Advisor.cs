using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ApexaApp.API.Helpers;
using Microsoft.EntityFrameworkCore;


namespace ApexaApp.API.Models
{
    //[PrimaryKey("Id","SIN")]
    public class Advisor : BaseEntity
    {
        public required string FullName { get; set; }
        public required string SIN { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public Enums.HealthStatus HealthStatus { get; set; }


        public Advisor()
        {
            HealthStatus = GenerateRandomHealthStatus();
        }


        private Enums.HealthStatus GenerateRandomHealthStatus()
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