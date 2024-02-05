var builder = WebApplication.CreateBuilder(args);

// Aktiverar MVC:
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//Aktiverar användning av statisk CSS och JS:
app.UseStaticFiles();
//aktiverar routing:
app.UseRouting();

app.UseAuthorization();

//definierar hur routingen fungerar:
app.MapControllerRoute(
    name: "default",
    //vilken mönster följer routing? 
    //vilken controller används? vilken undersida söks? skickas parameter?
    pattern: "{controller=Home}/{action=Index}/{id?}"); //kort sagt: kontroller / view / parameter är mönstret.

app.Run();
