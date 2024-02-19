using MedicalCRUD.Data.Contexts;
using MedicalCRUD.Data.Services.MedicalCharts;
using MedicalCRUD.Data.Services.Patients;
using MedicalCRUD.Repository.MedicalCharts;
using MedicalCRUD.Repository.Patients;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IMedicalChartRepository, MedicalChartRepository>();

builder.Services.AddScoped<IPatientServices, PatientServices>();
builder.Services.AddScoped<IChartSerices, ChartServices>();

builder.Services.AddDbContext<MedicalDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalCRUD")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
