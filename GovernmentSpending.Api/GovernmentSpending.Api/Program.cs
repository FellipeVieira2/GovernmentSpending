using GovernmentSpending.Api.Common;
using GovernmentSpending.Api.Filters;
using Microsoft.Extensions.FileProviders;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;
using GovernmentSpending.Application;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }
    ); ;
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{



    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Government Speding Api",
            Version = "v1",
            Description = "This project aims to facilitate society's access to data on government spending, working initially only in Brazil. All help is welcome",
            Contact = new OpenApiContact
            {
                Name = "Fellipe Vieira",
                Email = "fvsouza623@gmail.com"
            }
        }
    );
    string[] methodsOrder = new string[5] { "post", "get", "put", "patch", "delete" };

    options.OrderActionsBy(apiDesc => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{Array.IndexOf(methodsOrder, apiDesc.HttpMethod.ToLower())}");

    options.OperationFilter<JsonIgnoreQueryOperationFilter>();
    options.OperationFilter<JsonIgnorePathOperationFilter>();
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    SwaggerExtensions.AddSwaggerXml(options);
});
builder.Services.AddApplication();
builder.Services.AddControllersWithViews(options =>
    options.Filters.Add<ApiExceptionFilterAttribute>())
        .AddFluentValidation(x => x.AutomaticValidationEnabled = false);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseRouting();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "GovernmentSpending V1");
});
app.MapControllers();


app.Run();
