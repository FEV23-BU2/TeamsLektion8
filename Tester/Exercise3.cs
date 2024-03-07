using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Tester;


/*public class ApplicationFactory : WebApplicationFactory<VideoVecka1.Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
    }
}

public class Exercise3 : IClassFixture<ApplicationFactory>
{
    ApplicationFactory factory;

    public Exercise3(ApplicationFactory factory)
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
        var dto = new VideoVecka1.CreateTodoDto(title, description);

        // when
        var request = await client.PostAsJsonAsync("/api/todo", dto);
        var response = await request.Content.ReadFromJsonAsync<VideoVecka1.Todo>();

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

        var scope = factory.Services.CreateScope();
        var todoService = scope.ServiceProvider.GetRequiredService<VideoVecka1.TodoService>();

        todoService.CreateTodo(title, description);

        // when
        var request = await client.DeleteAsync("/api/todo/0");
        var response = await request.Content.ReadFromJsonAsync<VideoVecka1.Todo>();

        // then
        request.EnsureSuccessStatusCode();
        Assert.NotNull(response);
        Assert.Equal(title, response.Title);
        Assert.Equal(description, response.Description);
        Assert.False(response.Completed);
        Assert.True(response.Id == 0);
    }
}*/
