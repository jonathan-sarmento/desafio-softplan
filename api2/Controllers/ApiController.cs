using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;


namespace api2.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("/calcularJuros")]
        public string Get(int valorinicial, int meses)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/");

                //HTTP GET
                var responseTask = client.GetAsync("taxaJuros");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var taxaJuros = Convert.ToDouble(readTask.Result.Replace('.', ','));
                    var resultado = valorinicial * Math.Pow(1 + taxaJuros, meses);
                    return (Math.Round(resultado, 2)).ToString();
                }
                else
                {
                    return "error"; 
                }
            }
        }

        [HttpGet]
        [Route("/showmethecode")]
        public string Get()
        {
            return "https://github.com/jonathan-sarmento/desafio-softplan";
        }
       
    }
}
