using PracticeManagement.Library.Models;

namespace PracticeManagement.Library.Services
{
    public class BillService
    {
        private static BillService? instance;
        private List<Bill> Bills;
        private static object _lock = new object();
        private static int _counter = 1;
        public static BillService Current
        {
            get
            {
                //Thread safety, mission critical
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new BillService();
                    }
                }
                return instance;
            }
        }

        private BillService()
        {
            Bills = new List<Bill>();

        }

        public List<Bill> currentBills
        {
            get { return Bills; }
        }

        public Bill? Get(int id)
        {
            return Bills.FirstOrDefault(e => e.Id == id);
        }

        public Bill? Get(Bill Bill)
        {
            return Bills.FirstOrDefault(e => e == Bill);
        }

        public void Add(Bill? Bill)
        {

            if (Bill != null)
            {
                Bill.Id = _counter++;
                Bills.Add(Bill);
            }
        }



        public void Delete(int id)
        {
            var toRemove = Get(id);
            if (toRemove != null)
            {
                Bills.Remove(toRemove);
            }
        }

        public void Delete(Bill s)
        {
            Delete(s.Id);
        }

       

        public void Read()
        {
            Bills.ForEach(Console.WriteLine);
        }
    }
}
