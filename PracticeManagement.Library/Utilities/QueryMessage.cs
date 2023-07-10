using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.Library.Models;

namespace PracticeManagement.Library.Utilities
{
    public class QueryMessage
    {
        private string? query;

        private SearchFilters? filters;
        public SearchFilters Filters { get => filters ?? new SearchFilters();
                set 
                {
                    filters = value;
                } 
        }
        public string Query { get => query ?? string.Empty;
            set
            {
                query = value;
            }
        } 

        public QueryMessage(string query, SearchFilters filters)
        {
            Query = query;
            Filters = filters;
        }

        public QueryMessage(string query)
        {
            Query = query;
            
        }
    }
}
