using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Moment_02_test_01.Models;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;
using System.Xml;


namespace Moment_02_test_01.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //väg til index-sidan: skickas med denna titel:
        ViewData["title"] = "Den perfekta listan";
        //läser innehåll i Boklistans json-fil:
        var JsonStr = System.IO.File.ReadAllText("Lista.json");
        //läser in till Ienums här:
        var JsonObj = JsonConvert.DeserializeObject<IEnumerable<Items>>(JsonStr);
//och skickas med till view:en:
        return View(JsonObj);
    }

//route till gästbok:
    [Route("/Guestbook")]
    public IActionResult Guestbook()
    {
        //skickas med denna titel:
        ViewData["title"] = "Gästbok";
        //och detta meddelande:
        ViewBag.Message = "välkommen hit! hoppas du haft trevligt";
        return View();
    }

//route för Gästboksformulär:
    [Route("/Guestbook")]
    [HttpPost]
    public IActionResult Guestbook(GB_POST post)
    {
        
//om data validerar korrekt:
        if (ModelState.IsValid)
        {
            //så lägger vi in Gästboks-JSON här:
            string jsonStr = System.IO.File.ReadAllText("GB.json");
            //avserialiserar till lista:
            var newPost = System.Text.Json.JsonSerializer.Deserialize<List<GB_POST>>(jsonStr);
            //finns innehåll innehåll:
            if (newPost != null)
            {
                //ska det adderas:
                newPost.Add(post);
                //serialiserar:
                jsonStr = System.Text.Json.JsonSerializer.Serialize(newPost);
                //och skriver över JSON-fil:
                System.IO.File.WriteAllText("GB.json", jsonStr);
            }
        }
        //returnerar view med parameter:
        return View(post);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
