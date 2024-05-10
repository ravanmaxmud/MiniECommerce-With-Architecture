using ECommerceBackEnd.Application.Validators.Products;
using ECommerceBackEnd.Domain.Entities.Common;
using ECommerceBackEnd.Infrastucture;
using ECommerceBackEnd.Infrastucture.Filters;
using ECommerceBackEnd.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastuructureServices();
builder.Services.AddPersistenceService();
builder.Services.AddCors(options=> options.AddDefaultPolicy(policy => 
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    //.WithOrigns("custom link http//localhost:4200,https//localhost:4200")
    //==> bele yazaraqda istediyimiz urllerden sorgulari qebul ede bilerik
    //ancaq yuxarida yazilan ise her yerden gelen sorgunu qebul edir
));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
              .AddFluentValidation(configuration => 
              configuration.RegisterValidatorsFromAssemblyContaining<AddProductValidator>())
              .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true); //Fluent Validation ucun
                                                                                                       //lazim olan bir configurationdur. 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
