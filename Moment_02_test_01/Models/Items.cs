using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace Moment_02_test_01.Models
{
    //proppar:
public class Items {

//man måste skriva in = required - annars visas felmeddelandet.
[Required(ErrorMessage ="Du måste ange en titel!")]
//den ska visas i label som "bok-titel" - resterande följer samma mönster
[Display(Name = "Bok-titel:")]
public string? Name {get; set;}

[Required(ErrorMessage ="Du måste ange en Genre!")]
[Display(Name = "Genre:")]
public string? Category {get; set;}

[Required(ErrorMessage ="*host* Vad heter författaren?!")]
[Display(Name = "Författare")]
public string? Author {get; set;}

}



}