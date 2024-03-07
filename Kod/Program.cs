using Microsoft.AspNetCore.Mvc;

namespace Kod;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}

[ApiController]
[Route("")]
public class MyController : ControllerBase
{
    // Övning 1
    [HttpGet("1")]
    public string SayHello()
    {
        return "Hello World!";
    }

    // Övning 2
    [HttpGet("2")]
    public string YesOrNo()
    {
        Random random = new Random();
        if (random.NextSingle() <= 0.5)
        {
            return "Ja";
        }
        else
        {
            return "Nej";
        }
    }
}
