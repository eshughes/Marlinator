using Marlinator.Business.Yarn;
using Marlinator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;

namespace Marlinator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IYarnBo _yarnBo;

        public HomeController(ILogger<HomeController> logger, IYarnBo yarnBo)
        {
            _logger = logger;
            _yarnBo = yarnBo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MarlCalculator()
        {
            var viewModel = new MarlCalculatorViewModel();

            var allYarnWeights = _yarnBo.GetYarnWeights();
            viewModel.YarnWeightOptions = allYarnWeights.Select(x => new SelectListItem(x.FriendlyName, x.Id.ToString())).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MarlCalculator(MarlCalculatorViewModel viewModel)
        {
            var inputYarns = new List<int>();
            if (viewModel.Yarn1 != null)
                inputYarns.Add(viewModel.Yarn1.Value);
            if (viewModel.Yarn2 != null)
                inputYarns.Add(viewModel.Yarn2.Value);
            if (viewModel.Yarn3 != null)
                inputYarns.Add(viewModel.Yarn3.Value);

            var matchingYarnWeights = _yarnBo.GetMarledYarnWeight(inputYarns);
            if (matchingYarnWeights != null)
            {
                viewModel.YarnWeightResults = matchingYarnWeights;
            }

            var allYarnWeights = _yarnBo.GetYarnWeights();
            viewModel.YarnWeightOptions = allYarnWeights.Select(x => new SelectListItem(x.FriendlyName, x.Id.ToString())).ToList();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}