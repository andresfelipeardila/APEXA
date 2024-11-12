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
            HealthStatus = Utils.GenerateRandomHealthStatus();
        }

    }

    
}