using CadastroCliente.Application.Mappers;
using CadastroCliente.Application.Services;
using CadastroCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(ClienteMapProfile));
builder.Services.AddTransient<ICurrentUser, CurrentUserService>();
builder.Services.AddTransient<ICacheService, CacheService>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHttpClient<IClienteService, ClienteService>((sp, client) =>
{
    client.BaseAddress = new Uri("http://localhost:7019");
});

builder.Services.AddHttpClient<IUsuarioService, UsuarioService>((sp, client) =>
{
    client.BaseAddress = new Uri("http://localhost:7019"); 
});

builder.Services.AddHttpClient<IEnderecoService, EnderecoService>((sp, client) =>
{
    client.BaseAddress = new Uri("http://localhost:7019");
});

builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.Zero;
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
