using Microsoft.EntityFrameworkCore;
using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Repositories;
using SigechipBack.Services;

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


// Registrar servicios
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IHistorialService, HistorialService>();
builder.Services.AddScoped<IProcedimientoService, ProcedimientoService>();
builder.Services.AddScoped<IRecomendacionService, RecomendacionService>();
builder.Services.AddScoped<IFormulaService, FormulaService>();
builder.Services.AddScoped<IEvidenciasService, EvidenciasService>();
builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
builder.Services.AddScoped<IVacunasService, VacunasService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<ICodeQRService, CodeQRService>();
builder.Services.AddScoped<IVeterinariaService, VeterinariaService>();
/*
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
