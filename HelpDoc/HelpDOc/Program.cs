using HelpDOc.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Injetando o EmailService
builder.Services.AddSingleton(new EmailService("smtp.gmail.com", 465, "mlds.assinaturas@gmail.com", "ibvp tbgg bmwm qwfv"));
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
