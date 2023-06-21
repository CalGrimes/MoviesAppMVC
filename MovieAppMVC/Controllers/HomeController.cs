using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieAppMVC.Models;
using MovieAppMVC.Service;

namespace MovieAppMVC.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    private readonly MovieService _movieService;


    public HomeController(MovieService movieService)
    {
        //_logger = logger;y
        _movieService = movieService;
    }

    public ActionResult Index()
    {
        var suggestedMovies = _movieService.GetSuggestedMovies();
        return View(suggestedMovies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

