using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApexaApp.API.Dtos;
using ApexaApp.API.Models;
using AutoMapper;
using static ApexaApp.API.Helpers.Enums;

namespace ApexaApp.API.Helpers
{
    public class HealthStatusResolver: IValueResolver<AdvisorDto, Advisor, HealthStatus>
    {
        private readonly IConfiguration _config;
        public HealthStatusResolver(IConfiguration config)
        {
            _config = config;
        }

        public HealthStatus Resolve(AdvisorDto source, Advisor destination, HealthStatus destMember, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source.HealthStatus))
            {
                return Utils.GenerateRandomHealthStatus();
            }

            return (HealthStatus)Enum.Parse(typeof(HealthStatus), source.HealthStatus);
        }

    }
}