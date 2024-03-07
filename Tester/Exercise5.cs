using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Tester;

public class ApplicationFactory : WebApplicationFactory<VideoVecka3.Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<VideoVecka3.TodoDbContext>(options =>
            {
                var path = Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                );
                options.UseSqlite($"Data Source={Path.Join(path, "TestDb.db")}");
            });

            services
                .AddAuthentication("TestScheme")
                .AddScheme<AuthenticationSchemeOptions, MyAuthHandler>(
                    "TestScheme",
                    options => { }
                );

            var context = CreateDbContext(services);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            CreateFakeUser(context);
        });
    }

    static VideoVecka3.TodoDbContext CreateDbContext(IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();

        var scope = provider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<VideoVecka3.TodoDbContext>();
    }

    public static void CreateFakeUser(VideoVecka3.TodoDbContext context)
    {
        VideoVecka3.User user = new VideoVecka3.User();
        user.Id = "my-user-id";
        user.Email = "my name";

        context.Users.Add(user);
        context.SaveChanges();
    }
}

public class MyAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public MyAuthHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
    )
        : base(options, logger, encoder, clock) { }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "my-user"),
            new Claim(ClaimTypes.NameIdentifier, "my-user-id"),
            new Claim(ClaimTypes.Role, "remove")
        };

        var identity = new ClaimsIdentity(claims, "Test");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "TestScheme");

        var result = AuthenticateResult.Success(ticket);
        return Task.FromResult(result);
    }
}

public class Exercise4 : IClassFixture<ApplicationFactory>
{
    ApplicationFactory factory;

    public Exercise4(ApplicationFactory factory)
    {
        this.factory = factory;
    }

    [Fact]
    public async Task CreateTodo()
    {
        // given
        var client = factory.CreateClient();
        var title = "Städa";
        var description = "Städa ett rum";
        var dto = new VideoVecka3.CreateTodoDto(title, description);

        // Rensa databasen för testet.
        var scope = factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<VideoVecka3.TodoDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        ApplicationFactory.CreateFakeUser(context);

        // when
        var request = await client.PostAsJsonAsync("/api/todo", dto);
        var response = await request.Content.ReadFromJsonAsync<VideoVecka3.Todo>();

        // then
        request.EnsureSuccessStatusCode();
        Assert.NotNull(response);
        Assert.Equal(title, response.Title);
        Assert.Equal(description, response.Description);
        Assert.False(response.Completed);
        Assert.True(response.Id >= 0);
    }

    [Fact]
    public async Task RemoveTodo()
    {
        // given
        var client = factory.CreateClient();
        var title = "Städa";
        var description = "Städa ett rum";

        // Rensa databasen för testet.
        var scope = factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<VideoVecka3.TodoDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        ApplicationFactory.CreateFakeUser(context);

        var todoService = scope.ServiceProvider.GetRequiredService<VideoVecka3.TodoService>();

        todoService.CreateTodo(title, description, "my-user-id");

        // when
        var request = await client.DeleteAsync("/api/todo/1");
        var response = await request.Content.ReadFromJsonAsync<VideoVecka3.Todo>();

        // then
        request.EnsureSuccessStatusCode();
        Assert.NotNull(response);
        Assert.Equal(title, response.Title);
        Assert.Equal(description, response.Description);
        Assert.False(response.Completed);
        Assert.True(response.Id == 1);
    }
}
