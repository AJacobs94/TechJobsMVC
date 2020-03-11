using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {

            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> results = JobData.FindByValue(searchTerm = "");

                ViewBag.title = "All " + ListController.columnChoices[searchType] + " Values";
                ViewBag.title = "All Jobs Results";
                ViewBag.jobs = results;
                ViewBag.columns = ListController.columnChoices;

                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "All " + ListController.columnChoices[searchType] + " Values";
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = searchResults;
                return View("Index");
            }

            // TODO #1 - Create a Results action method to process 
            // search request and display results

        }
    }

}

