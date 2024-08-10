using Microsoft.EntityFrameworkCore;
using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));


 
 
// Registrar repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IHistorialRepository, HistorialRepository>();
builder.Services.AddScoped<IProcedimientoRepository, ProcedimientoRepository>();
builder.Services.AddScoped<IRecomendacionRepository, RecomendacionRepository>();
builder.Services.AddScoped<IFormulaRepository, FormulaRepository>();
builder.Services.AddScoped<IEvidenciasRepository, EvidenciasRepository>();
builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
builder.Services.AddScoped<IVacunasRepository, VacunasRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<ICodeQRRepository, CodeQRRepository>();
builder.Services.AddScoped<IVeterinariaRepository, VeterinariaRepository>();

/*
// Registrar servicios
builder.Services.AddScoped<IYourService, YourService>();

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(YourMapperProfile));

// Registrar ViewModels, si es necesario
builder.Services.AddScoped<YourViewModel>();

 */

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
