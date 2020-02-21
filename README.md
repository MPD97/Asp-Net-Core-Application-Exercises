# Asp-Net-Core-Application-Exercises
A bunch of exercises using **Core 3.1**

## 01_DependencyInjection 
- You can easy change the **TImplementation** that inhierit from **TService** witchout changing your code.
Pick one and try!
```csharp
    services.AddScoped<IExampleInterface, CoolStrings>();
    // or
    services.AddScoped<IExampleInterface, AmazingStrings>();
    // or
    services.AddScoped<IExampleInterface, NormalStrings>();
```
- Inject **service** through constructor like this
```csharp
    public StringController(IExampleInterface stringClass)
    {
        InjectedClass = stringClass;
    }
```
- *Important! To ensure flexibility of your code, assign inject service to the Interface type instead of class.*
```csharp
    public IExampleInterface InjectedClass { get; }
```
## 02_Logging
- Configure the logger using **appsetting.json**
```csharp
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Trace",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
- Add this code to the **CreateHostBuilder** method in **Program.cs**
```csharp
 public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)

            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders();
                logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                logging.AddConsole();
            });
        }
```
- *Hint! Run project using KESTREL to see the command line*
## 03_Configuration
- This example shows how to **bind** class depending on **appsettings.json**. Frist create a class to store the data
```csharp
public class CustomSettings
    {
        public string GitHubUrl { get; set; }
        public string CreatedDate { get; set; }
    }
```
- Create **appsettings.json** file in the project
```csharp
{
  //...
  "CustomConfig": {
    "GitHubUrl": "https://github.com/MPD97",
    "CreatedDate" : "2020-02-21"
  }
}
```
- Then **bind** the class using injected **IConfiguration** service
```csharp
    CustomSettings settings = new CustomSettings();
    Configuration.GetSection("CustomConfig").Bind(settings);
```
## 04_CRUD	Completed CRUD project
- Creating simple **CRUD** project using **EntityFramework Core** and built in **(localdb)\MSSQLLocalDB**. Start from creating simple entities
```csharp
    public class Item
    {
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
```
```csharp
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
```
- Create an **ApplicationDbContext** class. It must inherit from **DbContext**. 
```csharp
 public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }
```
- *Note! Don't forget to call base class with options parameter*
```csharp
  : base(options)
```
- Also I want to seed the database with some data. Override **OnModelCreating** method like this
```csharp
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var shop1 = new Shop
        {
            ShopId = 1,
            Name = "Super Grocery",
            Created = DateTime.Now
        };
        var item1 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Milk 500ml",
            Cost = 2.32m,
            ShopId = 1,
        };
        modelBuilder.Entity<Shop>().HasData(shop1);
        modelBuilder.Entity<Item>().HasData(item1);
    }
```
- Use **AddDbContext** to register **ApplicationDbContext** and configure database.
```csharp
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("LocalDb"));
        });
```
- Save the connection string to the **appsettings.json**
```csharp
{
  //...,
  "ConnectionStrings": {
    "LocalDb": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopsDatabase;Integrated Security=True;Connect Timeout=10;"
  }
}
```
