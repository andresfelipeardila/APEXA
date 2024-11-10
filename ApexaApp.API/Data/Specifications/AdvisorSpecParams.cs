using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexaApp.API.Data.Specifications
{
    public class AdvisorSpecParams
    {
        private const int MaxPageSize = 15;        
        public int PageIndex {get; set;} =1;

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Sort { get; set; } = string.Empty;

        private string _search = string.Empty;
        public string Search 
        { 
            get => _search; 
            set => _search = value.ToLower(); 
        }
    }
}