using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApexaApp.API.Models;

namespace ApexaApp.API.Data.Specifications
{
    public class AdvisorsForCountSpecification : BaseSpecification<Advisor>
    {
        public AdvisorsForCountSpecification(AdvisorSpecParams advisorsParams)
        : base( x=> string.IsNullOrEmpty(advisorsParams.Search) || x.FullName.ToLower().Contains(advisorsParams.Search))
        {
        }
    }
}