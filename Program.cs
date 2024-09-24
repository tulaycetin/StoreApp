using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services ;
using Services.Contracts;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//Servis Kayıtları için

builder.Services.AddDbContext<RepositoryContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection"),
        b => b.MigrationsAssembly("StoreApp"));
}); 

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddScoped<IServicesManager, ServiceManager>();   
builder.Services.AddScoped<IProductServices, ProductManager>();
builder.Services.AddScoped<ICategoryServices, CategoryManager>();

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();//
app.UseRouting();

app.MapControllerRoute(
    name:"defaut",
    pattern:"{Controller=Home}/{action=Index}/{id?}"
);

app.Run();
