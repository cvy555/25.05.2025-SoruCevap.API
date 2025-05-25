using Microsoft.AspNetCore.Mvc;

namespace SoruCevap.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
     
        public IActionResult Index()
        {
            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            return View();
        }

        [Route("QuestionMenu/{id}")]
        [Route("QuestionMenu")]
        public IActionResult QuestionMenu(int id = 0)
        {
            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            ViewBag.CatId = id;
            return View();
        }
        [Route("Categories")]
        public IActionResult Categories()
        {
            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            return View();
        }

        [Route("Questions/{id}")]
        [Route("Questions")]
        public IActionResult Questions(int id = 0)
        {

            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            ViewBag.CatId = id;
            return View();
        }

        [Route("Answer/{id}")]

        public IActionResult Answer(int id)
        {
            ViewBag.QuestId = id;
            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            return View();
        }
        [Route("Login")]
        public IActionResult Login()
        {
            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            return View();
        }

        [Route("Register")]
        public IActionResult Register()
        {
            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            return View();
        }

        [Route("Profile")]
        public IActionResult Profile()
        {
            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            return View();
        }
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {

            var ApiBaseURL = _configuration["ApiBaseURL"];
            ViewBag.ApiBaseURL = ApiBaseURL;
            ViewBag.DetailsId = id;
            return View();
        }
    }
}
