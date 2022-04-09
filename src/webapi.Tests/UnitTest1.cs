using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using webapi.Dto;
using Xunit;

namespace webapi.Tests;

public class UnitTest1
{
    record Result(string Hash);
    [Fact]
    public async Task Test1()
    {
        var application = new WebApplicationFactory<Program>();

        using var client = application.CreateClient();
        using var flu = new FlurlClient(client);

        var ret = await flu.Request("/HashTest")
                           .PostJsonAsync(new HelloDto("1", "2"));

        var body = await ret.GetJsonAsync<Result>();

        Assert.Equal("YL2LE6OZGH+XT7uP4OiZxVD7CRaWrpp4VsM6STI5k2uKfyS0IOWdbiz4oAb6Ta4IhUVcw48pkYo8IL1IeekQgw==", body.Hash);
    }
}
