using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Services;

var builder = WebApplication.CreateBuilder(args);

// C?u hình DbContext v?i SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ??ng ký ProductService cho DI (Dependency Injection)
builder.Services.AddScoped<IProductService, ProductService.Services.ProductService>();

// C?u hình các d?ch v? khác
builder.Services.AddControllers();

// Thêm Swagger n?u c?n thi?t
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// C?u hình middleware
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
