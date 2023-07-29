using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.Library.Models;

namespace PracticeManagement.Library.Utilities
{
    public class SearchObj
    {
        private string? query;

        public List<Filter> Filters { get; set; }


        
        public string Query { get => query ?? string.Empty;
            set
            {
                query = value;
            }
        }
        
        public bool hasContent ()
        {
            return !string.IsNullOrEmpty(Query) || Filters.Any(f => f.Applied);
        }

        public void Reset()
        {
            Query = string.Empty;
            Filters.ForEach(f => f.Applied = false);
        }
        public SearchObj(string query, List<Filter> filters)
        {
            Query = query;
            Filters = filters;
        }

        public SearchObj(string query)
        {
            Query = query;
            Filters= new List<Filter>();
        }

        public SearchObj()
        {
            query = string.Empty;
            Filters = new List<Filter>();
        }
    }
}
