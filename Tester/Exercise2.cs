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

public class Exercise2 : IClassFixture<ApplicationFactory>
{
    ApplicationFactory factory;

    public Exercise2(ApplicationFactory factory)
    {
        this.factory = factory;
    }

    [Fact]
    public async Task Test1()
    {
        // given
        var client = factory.CreateClient();

        // when
        var response = await client.GetStringAsync("/2");

        // then
        Assert.NotNull(response);
        Assert.True(response == "Ja" || response == "Nej");
    }
}*/
