using HackerNewsClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Codecool.HackerNewsClient.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HackerNewsClient.Controllers
{
    /// <summary>
    /// HomeController is a generic controller responsible for communicating with
    /// external or internal data sources (API or other data services).
    /// It contains methods communicating with the external API and
    /// serializing the data into News object.
    /// The methods return ActionResult which generates respective HTML page (View)
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// returns index page with top news
        /// </summary>
        /// <param name="page"> parameter of current page index </param>
        /// <returns></returns>
        public async Task<ActionResult> Index(int page = 1)
        {
            List<TopNews> list = new List<TopNews>();

            string apiUrl = $"https://api.hnpwa.com/v0/news/{page}.json";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        TopNews item = new TopNews()
                        {
                            Title = table.Rows[i][1].ToString(),
                            TitleAuthor = table.Rows[i][3].ToString(),
                            TimeAgo = table.Rows[i][5].ToString(),
                            Link = table.Rows[i][8].ToString()
                        };
                        list.Add(item);
                    }


                }

                ViewData["next"] = "https://localhost:44334/Home/?page=" + (page + 1).ToString();
                if (page > 1)
                    ViewData["prev"] = "https://localhost:44334/Home/?page=" + (page - 1).ToString();
                else
                    ViewData["prev"] = "https://localhost:44334/Home/?page=1";
                return View(list);
            }


        }

        public async Task<ActionResult> Newest(int page = 1)
        {
            List<TopNews> list = new List<TopNews>();

            string apiUrl = $"https://api.hnpwa.com/v0/news/{page}.json";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        TopNews item = new TopNews()
                        {
                            Title = table.Rows[i][1].ToString(),
                            TitleAuthor = table.Rows[i][3].ToString(),
                            TimeAgo = table.Rows[i][5].ToString(),
                            Link = table.Rows[i][8].ToString(),
                            Time = table.Rows[i][4].ToString()
                        };
                        list.Add(item);
                    }

                    //list.OrderBy(x => int.Parse(x.Time));


                }

                ViewData["next"] = "https://localhost:44334/Home/Newest?page=" + (page + 1).ToString();
                if (page > 1)
                    ViewData["prev"] = "https://localhost:44334/Home/Newest?page=" + (page - 1).ToString();
                else
                    ViewData["prev"] = "https://localhost:44334/Home/Newest?page=1";
                return View(list.OrderByDescending(x => int.Parse(x.Time)));
            }
        }

        public async Task<ActionResult> TopNews(int page = 1)
        {
            List<TopNews> list = new List<TopNews>();

            string apiUrl = $"https://api.hnpwa.com/v0/news/{page}.json";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        TopNews item = new TopNews()
                        {
                            Title = table.Rows[i][1].ToString(),
                            TitleAuthor = table.Rows[i][3].ToString(),
                            TimeAgo = table.Rows[i][5].ToString(),
                            Link = table.Rows[i][8].ToString(),
                            Points = table.Rows[i][2].ToString(),
                        };
                        list.Add(item);
                    }
                }

                ViewData["next"] = "https://localhost:44334/Home/?page=" + (page + 1).ToString();
                if (page > 1)
                    ViewData["prev"] = "https://localhost:44334/Home/?page=" + (page - 1).ToString();
                else
                    ViewData["prev"] = "https://localhost:44334/Home/?page=1";
                return View(list.OrderBy(x => (x.Points)));
            }
        }

        public async Task<ActionResult> Jobs(int page = 1)
        {
            List<TopNews> list = new List<TopNews>();

            string apiUrl = $"https://api.hnpwa.com/v0/jobs/{page}.json";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        TopNews item = new TopNews()
                        {
                            Title = table.Rows[i][1].ToString(),
                            TitleAuthor = table.Rows[i][3].ToString(),
                            TimeAgo = table.Rows[i][5].ToString(),
                            Link = table.Rows[i][8].ToString()
                        };
                        list.Add(item);
                    }


                }

                ViewData["next"] = "https://localhost:44334/Home/?page=" + (page + 1).ToString();
                if (page > 1)
                    ViewData["prev"] = "https://localhost:44334/Home/?page=" + (page - 1).ToString();
                else
                    ViewData["prev"] = "https://localhost:44334/Home/?page=1";
                return View(list);
            }


        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
