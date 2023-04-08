using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UI.BrazilianAddressCode.Models;

namespace UI.BrazilianAddressCode.Controllers
{
    public class AddressController : Controller
    {
        IHttpClientFactory _client { get; }
        public AddressController(IHttpClientFactory client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAddress(string zipCode)
        {
            try
            {
                string urlApi = "";
                using (var _ = _client.CreateClient())
                {
                    var response = await _.GetAsync(urlApi);
                    var result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var Ok = Task.FromResult(JsonConvert.DeserializeObject<AddressViewModel>(result));
                        return View(Ok);
                    }
                    else
                    {
                        var Nok = Task.FromResult(JsonConvert.DeserializeObject<ErrorViewModel>(result));
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
