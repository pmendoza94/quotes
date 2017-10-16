using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace quoting_dojo.Controllers
{

    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes(){
            string query = "SELECT * FROM quotes";
            var AllQuotes = _dbConnector.Query(query);
            ViewBag.AllQuotes = AllQuotes;
            System.Console.WriteLine(AllQuotes);
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Method(string name, string content){
            Console.WriteLine(name);
            Console.WriteLine(content);
            string query = $"INSERT INTO quotes (name, content, created_at) VALUES ('{name}','{content}',Now())";
            _dbConnector.Execute(query);
            return RedirectToAction("quotes");
        }
    }
}

 // List<Dictionary<string,object>> AllQuotes = _dbConnector.Query("SELECT * FROM quotes");