using Interdisciplinar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Interdisciplinar.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var result = new RootObject();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://172.31.0.36:8060");

                var ret = await client.GetAsync("ProjetoFinal/rest/Categoria/listarTodos");

                if (ret.IsSuccessStatusCode)
                {
                    var str = ret.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<RootObject>(str);
                }

            }
            return View(result.categoria);


            
        }
    }
}
