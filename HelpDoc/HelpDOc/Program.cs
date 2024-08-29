using HelpDOc.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazorBootstrap();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string email = Environment.GetEnvironmentVariable("email_key");
string senha = Environment.GetEnvironmentVariable("pws_email_key");

// Injetando o EmailService
builder.Services.AddSingleton(new EmailService("smtp.gmail.com", 465, email, senha));
// O Gmail precisa que seja gerado uma senha especifica para o app. Procure por "Senha de App"

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
