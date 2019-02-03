using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using MalweeCodeChallenge.Core.Helper;
using MalweeCodeChallenge.Core.Infra.EntityFramework;
using MalweeCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace MalweeCodeChallenge.Controllers
{
    [AllowAnonymous]
    public class ReportsController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IServiceProvidedService _serviceProvidedService;

        public ReportsController(MalweeContext context, ISupplierService supplierService,IServiceProvidedService serviceProvidedService)
        {
            _supplierService = supplierService;
            _serviceProvidedService = serviceProvidedService;
        }

        // GET: Reports
        public ActionResult ExpensesPerMonth()
        {
            List<ExpensesPerMonthViewModel> viewModel = new List<ExpensesPerMonthViewModel>();

            var result = _serviceProvidedService.GetExpensesPerMonth().ToList();

            var resultPerMonth = result.GroupBy(x => x.Month).OrderBy(x => x.Key);

            foreach (var itemPerMonth in resultPerMonth)
            {
                var expensesByMonth = new ExpensesPerMonthViewModel();

                expensesByMonth.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(itemPerMonth.Key);

                var clientsFromMonth = result.Where(x => x.Month == itemPerMonth.Key).OrderByDescending(x => x.Value).Take(3);

                foreach (var clientFromMonth in clientsFromMonth)
                {
                    var item = new ExpensesPerMonthItemViewModel();
                    item.ClientName = clientFromMonth.Name;
                    item.Value = clientFromMonth.Value.ToString("C2");

                    expensesByMonth.Items.Add(item);
                }

                viewModel.Add(expensesByMonth);
            }

            return View(viewModel);
        }

        public ActionResult SupplierAverageByService()
        {
            List<SupplierAverageByServiceViewModel> viewModel = new List<SupplierAverageByServiceViewModel>();

            var supplierAverages = _serviceProvidedService.GetSupplierAverageByService().OrderByDescending(x => x.Value).ToList();

            foreach (var supplierAverage in supplierAverages)
            {
                var item = new SupplierAverageByServiceViewModel();

                item.SupplierName = supplierAverage.Name;
                item.ServiceType = ((ServiceEnum)supplierAverage.Service).GetDescription();
                item.Value = supplierAverage.Value.ToString("C2");

                viewModel.Add(item);
            }

            return View(viewModel);
        }

        public ActionResult SupplierServiceByMonth()
        {
            List<SupplierServiceByMonthViewModel> viewModel = new List<SupplierServiceByMonthViewModel>();

            var servicesByMonth = _serviceProvidedService.GetSupplierServiceByMonth().ToList();

            var suppliers = _supplierService.GetAllSuppliers();

            DateTime finalDate = new DateTime(DateTime.Now.Year, 12, 31);
            DateTime iterationDate = new DateTime(DateTime.Now.Year, 1, 1);

            while (iterationDate <= finalDate)
            {
                var supplierByMonth = new SupplierServiceByMonthViewModel();
                supplierByMonth.Month = iterationDate.ToString("MMM");

                foreach (var supplier in suppliers)
                {
                    if (!servicesByMonth.Where(x => x.Month == iterationDate.Month).Any(x => x.Name == supplier.Name))
                    {
                        if (!supplierByMonth.Items.Any(x => x.SupplierName == supplier.Name))
                        {
                            supplierByMonth.Items.Add(new SupplierServiceByMonthViewModelItem { SupplierName = supplier.Name });
                        }
                    }
                }

                if (supplierByMonth.Items.Count == 0)
                {
                    supplierByMonth.Items.Add(new SupplierServiceByMonthViewModelItem { SupplierName = "Nenhum fornecedor sem serviço" });
                }

                viewModel.Add(supplierByMonth);

                iterationDate = iterationDate.AddMonths(1);
            }

            return View(viewModel);
        }
    }
}