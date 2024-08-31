using ClickBurger.Areas.Admin.Sevircos;
using Microsoft.AspNetCore.Mvc;

namespace ClickBurger.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendasServicos relatorioVendasService;

        public AdminRelatorioVendasController(RelatorioVendasServicos _relatorioVendasService)
        {
            relatorioVendasService = _relatorioVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendaSimples(DateTime? minDate,
            DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await relatorioVendasService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
    }
}
