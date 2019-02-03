using System.Collections.Generic;

namespace MalweeCodeChallenge.Models
{
    public class SupplierServiceByMonthViewModel
    {
        public string Month { get; set; }

        public List<SupplierServiceByMonthViewModelItem> Items { get; set; }

        public SupplierServiceByMonthViewModel()
        {
            Items = new List<SupplierServiceByMonthViewModelItem>();
        }
    }

    public class SupplierServiceByMonthViewModelItem
    {
        public string SupplierName { get; set; }
    }
}