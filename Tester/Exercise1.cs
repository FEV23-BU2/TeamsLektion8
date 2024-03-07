using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tester;


/*public class ApplicationFactory : WebApplicationFactory<Kod.Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
    }
}

public class Exercise1 : IClassFixture<ApplicationFactory>
{
    ApplicationFactory factory;

    public Exercise1(ApplicationFactory factory)
    {
        this.factory = factory;
    }

    [Fact]
    public async Task Test1()
    {
        // given
        var client = factory.CreateClient();

        // when
        var response = await client.GetStringAsync("/");

        // then
        Assert.NotNull(response);
        Assert.Equal("Hello World!", response);
    }
}*/
