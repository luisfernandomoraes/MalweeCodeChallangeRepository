using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MalweeCodeChallenge.Models
{
    public class ExpensesPerMonthViewModel
    {
        public string Month { get; set; }
        public List<ExpensesPerMonthItemViewModel> Items { get; set; }

        public ExpensesPerMonthViewModel()
        {
            Items = new List<ExpensesPerMonthItemViewModel>();
        }
    }

    public class ExpensesPerMonthItemViewModel
    {
        public  string ClientName { get; set; }
        public string Value { get; set; }
    }
}