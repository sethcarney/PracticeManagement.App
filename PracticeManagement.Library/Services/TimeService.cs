using PracticeManagement.Library.Models;

namespace PracticeManagement.Library.Services
{
    public class TimeService
    {
        private static TimeService? instance;
        private List<Time> times;
        private static object _lock = new object();
        private static int _counter = 1;
        public static TimeService Current
        {
            get
            {
                //Thread safety, mission critical
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new TimeService();
                    }
                }
                return instance;
            }
        }

        private TimeService()
        {
            times = new List<Time>();
        }

        public List<Time> currentTimes
        {
            get { return times; }
        }

        public Time? Get(int id)
        {
            return times.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Time? Time)
        {

            if (Time != null)
            {
                Time.Id = _counter++;
                times.Add(Time);
            }
        }

        public List<Time> Search(List<Time> filtered, string query)
        {
            return filtered.Where(s => s.Date.ToShortDateString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
            s.Employee.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
            s.Project.ShortName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
            s.Project.LongName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        public List<Time> applyFilters(SearchFilters filter)
        {
            List<Time> filtered = currentTimes;
            foreach (var filterItem in filter.Filters)
            {
                if (filterItem.Name == "Today" && filterItem.Applied)
                    filtered = filtered.Where(p => p.Date == DateTime.Now.Date).ToList();
                else if (filterItem.Name == "Show Closed")
                    filtered = filtered.Where(p => p.Project.isActive != filterItem.Applied).ToList();
            }
            return filtered;
        }

        public void Delete(int id)
        {
            var toRemove = Get(id);
            if (toRemove != null)
            {
                times.Remove(toRemove);
            }
        }

        public void Delete(Time s)
        {
            Delete(s.Id);
        }

        public List<Time> Search(string query)
        {
            return times.Where(s => s.Narrative.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void Read()
        {
            times.ForEach(Console.WriteLine);
        }
    }
}
