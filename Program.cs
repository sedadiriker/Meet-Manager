using Microsoft.EntityFrameworkCore;
using Meet_Manager.Data;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Swagger generator
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Meet Management System API",
        Version = "v1"
    });

    // HomeController'ı Swagger'dan hariç tutun
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        var controller = apiDesc.ActionDescriptor.RouteValues["controller"];
        return controller != "Home"; // HomeController'ı hariç tutun
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i servisler listesine ekleme
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meet Management System API V1");
        c.RoutePrefix = "swagger"; // Swagger UI'yi kök URL'de gösterir
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
