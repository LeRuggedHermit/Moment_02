using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Moment_02_test_01.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;
using System.Xml;

namespace Moment_02_test_01.Controllers;

public class FormController : Controller
{
    //Filväg till Bok-listans jsonfil:
    private const string JsonFilePath = "Lista.json"; //fil-väg till JSON

//Route till bok-formuläret:
    [Route("/skapa")]
    public IActionResult Form()
    {
        //den returneras med följande titel:
        ViewData["title"] = "Skapa lista";
        return View();
    }

//route för formulärdata:
    [Route("/skapa")]
    [HttpPost]
    public IActionResult Form(Items item)
    {

        //validerar data:
        if (ModelState.IsValid)
        {
            //är data okej läser vi in json-filen här:
            string jsonStr = System.IO.File.ReadAllText(JsonFilePath);
            //lägger in den i följande variabel:
            var newItem = JsonSerializer.Deserialize<List<Items>>(jsonStr);

//om den inte är tom...
            if (newItem != null)
            {
                //adderar vi den nya boken här:
                newItem.Add(item);
                //serialiserar tillbaks till JSON:
                jsonStr = JsonSerializer.Serialize(newItem);
                //och skriver tillbaka det i filen:
                System.IO.File.WriteAllText(JsonFilePath, jsonStr);
            }
        }

//och returnerar view med item-parameter:
        return View(item);
    }

}