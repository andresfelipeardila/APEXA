using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApexaApp.API.Models;

namespace ApexaApp.API.Data.Specifications
{
    public class AdvisorsSpecification : BaseSpecification<Advisor>
    {
        public AdvisorsSpecification(AdvisorSpecParams advisorsParams)
        : base(a => string.IsNullOrEmpty(advisorsParams.Search) || a.FullName.ToLower().Contains(advisorsParams.Search))
        {
            ApplyPaging(advisorsParams.PageSize * (advisorsParams.PageIndex -1), advisorsParams.PageSize);
        
            if(!string.IsNullOrEmpty(advisorsParams.Sort))
            {
                switch (advisorsParams.Sort)
                {
                    case "fullNameAsc":
                        AddOrderBy(p => p.FullName);
                        break;
                    case "SIN":
                        AddOrderBy(p => p.SIN);
                        break;
                    default:
                        AddOrderBy(p => p.FullName);
                        break;
                }
            }
        
        }
        
    }
}