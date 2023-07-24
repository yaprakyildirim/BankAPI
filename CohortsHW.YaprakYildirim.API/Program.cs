using CohortsHW.YaprakYildirim.Business.Middleware;
using CohortsHW.YaprakYildirim.Business.Services.Abstract;
using CohortsHW.YaprakYildirim.Business.Services.Concrete;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
////builder.Services.AddSingleton<IUserService, FakeUserService>();
builder.Services.AddTransient<IUserService, FakeUserService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sipay Api Collection", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sipay v1"));
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseMiddleware<LogMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
