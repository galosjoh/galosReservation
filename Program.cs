using MongoDB.Driver;
using RestReservation.Models;
using RestReservation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var mongoDbSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
if (mongoDbSettings == null)
{
    throw new InvalidOperationException("MongoDBSettings configuration section is missing or invalid.");
}

// Register the MongoDB client and database for dependency injection.
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoDbSettings.AtlasURI));
builder.Services.AddScoped<IMongoDatabase>(sp => 
    sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.DatabaseName));

builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Restaurant}/{action=Index}/{id?}");


// MongoDB connection verification
try
{
    var mongoClient = app.Services.GetRequiredService<IMongoClient>();
    var result = mongoClient.GetDatabase("admin").RunCommand<MongoDB.Bson.BsonDocument>(new MongoDB.Bson.BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
}
catch (Exception ex)
{
    Console.WriteLine("MongoDB connection failed: " + ex.Message);
}

app.Run();