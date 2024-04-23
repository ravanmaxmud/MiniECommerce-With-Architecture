using ECommerceBackEnd.Persistence;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceService();
builder.Services.AddCors(options=> options.AddDefaultPolicy(policy => 
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    //.WithOrigns("custom link http//localhost:4200,https//localhost:4200")
    //==> bele yazaraqda istediyimiz urllerden sorgulari qebul ede bilerik
    //ancaq yuxarida yazilan ise her yerden gelen sorgunu qebul edir
));
builder.Services.AddControllers();

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
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
