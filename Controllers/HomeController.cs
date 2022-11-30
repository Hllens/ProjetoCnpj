using AgoraVai_Cnpj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Reflection;
using System.Threading.Tasks;
using System.Net.Http;


namespace AgoraVai_Cnpj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string ApiCnpj = "https://receitaws.com.br/v1/cnpj";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index() => View();
        [HttpPost]


        public async Task<IActionResult> Index(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
            {
                return View();
            }

            CnpjResultado resultado = new CnpjResultado();/*MEU OBJETO QUE ESTÁ FAZENDO REFERECES COM A MINHA MODEL*/
            string postCNPJ = ApiCnpj + "/" + cnpj.Replace("/", "").Replace(".", "").Replace("_", "").Replace("-", "").Trim();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(resultado),
                                                 Encoding.UTF8, "application/json");
                using (var response = await httpClient.GetAsync(postCNPJ))

                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resultado = JsonConvert.DeserializeObject<CnpjResultado>(apiResponse);

                }
            }

            return View(resultado);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CnpjResultado Resultado)
        {

            return RedirectToRoute("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
