using Infrastructure.Data;
using Application.Services; 
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<PostgresDataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
builder.Services.AddScoped<HomeBannerService>();
builder.Services.AddScoped<HomeAboutService>();
builder.Services.AddScoped<TechnologyCardService>();
builder.Services.AddScoped<HomePortfolioService>();
builder.Services.AddScoped<ProjectCardService>();
builder.Services.AddScoped<HomeService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
