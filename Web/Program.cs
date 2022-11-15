using Core.Services;
using DataAccess.Data;
using KLearn.DataAccess;
using KLearn.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddDbContext<BlogPostsDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("PostAppConnection")
    ));
        

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
{
    config.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<BlogPostsDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IDataDbContext, DataDbContext>();
builder.Services.AddScoped<BlogPostService, BlogPostService>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<IBlogPostsDbContext, BlogPostsDbContext>();
builder.Services.AddScoped<PostsService, PostsService>();




var app = builder.Build();
IServiceProvider serviceProvider = app.Services;

var scope = serviceProvider.CreateScope();
scope.ServiceProvider.GetRequiredService<BlogPostsDbContext>().Database.EnsureCreated();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

