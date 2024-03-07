using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tester;


/*public class ApplicationFactory : WebApplicationFactory<VideoVecka2.Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<VideoVecka2.TodoDbContext>(options =>
            {
                var path = Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                );
                options.UseSqlite($"Data Source={Path.Join(path, "TestDb.db")}");
            });

            var context = CreateDbContext(services);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        });
    }

    static VideoVecka2.TodoDbContext CreateDbContext(IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();

        var scope = provider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<VideoVecka2.TodoDbContext>();
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
        var dto = new VideoVecka2.CreateTodoDto(title, description);

        // Rensa databasen för testet.
        var scope = factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<VideoVecka2.TodoDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // when
        var request = await client.PostAsJsonAsync("/api/todo", dto);
        var response = await request.Content.ReadFromJsonAsync<VideoVecka2.Todo>();

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
        var context = scope.ServiceProvider.GetRequiredService<VideoVecka2.TodoDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var todoService = scope.ServiceProvider.GetRequiredService<VideoVecka2.TodoService>();

        todoService.CreateTodo(title, description);

        // when
        var request = await client.DeleteAsync("/api/todo/1");
        var response = await request.Content.ReadFromJsonAsync<VideoVecka2.Todo>();

        // then
        request.EnsureSuccessStatusCode();
        Assert.NotNull(response);
        Assert.Equal(title, response.Title);
        Assert.Equal(description, response.Description);
        Assert.False(response.Completed);
        Assert.True(response.Id == 1);
    }
}
*/
