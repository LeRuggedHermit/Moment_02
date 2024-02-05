using System.ComponentModel.DataAnnotations;

namespace Moment_02_test_01.Models;

public class GB_POST{

//modell för gästboks-inlägg:

    //props:
[Required(ErrorMessage ="Du måste ange ditt namn!")]
[Display(Name = "Ditt namn")]
public string? Name {get; set;}

[Required(ErrorMessage ="Du måste ange ett meddelande!")]
[Display(Name = "Ditt meddelande")]
public string? MSG {get; set;}

[Required(ErrorMessage ="berätta om du uppskattade upplevelsen!")]
[Display(Name = "Tyckte du om sidan?")]
public bool XP {get; set;}

[Required(ErrorMessage ="Du måste ange ditt betyg!")]
[Display(Name = "Ditt betyg (1-10)")]
public int Rating {get; set;}


}