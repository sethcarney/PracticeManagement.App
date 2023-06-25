namespace PracticeManagement.Library.Models
{
    public class SearchFilters
    {
        public List<Filter> Filters { get; set; }
        public SearchFilters()
        {
            Filters = new List<Filter>();
        }
    }
    public class Filter
    {
        public string? Name { get; set; }
        public bool Applied { get; set; }
        public Filter()
        { }
    }
}
