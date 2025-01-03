using App.Domain.Core.CardToCard.Card.AppService;
using App.Domain.Core.CardToCard.Card.Data.Repository;
using App.Domain.Core.CardToCard.Card.Service;
using App.Domain.Core.CardToCard.Transaction.Data.Repository;
using App.Domain.Core.CardToCard.Transaction.Service;
using App.Domain.Core.CardToCard.User;
using App.Domain.Core.CardToCard.User.Data.Repository;
using App.Domain.Service.Card;
using App.Domain.Service.Transaction;
using App.Domain.Service.User;
using App.Infra.Data.Db.SqlServer.Ef.Db;
using App.Infra.Data.Repos.Ef.CardToCard;
using App.Infra.Data.Repos.Ef.CardToCard.Card;
using App.Infra.Data.Repos.Ef.CardToCard.Transaction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITransactionService,TransactionService>();
builder.Services.AddScoped<ICardServices,CardService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
