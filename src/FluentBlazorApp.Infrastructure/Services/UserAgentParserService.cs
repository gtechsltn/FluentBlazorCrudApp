using FluentBlazorApp.Application.Services;

using Newtonsoft.Json;

using UAParser;

namespace FluentBlazorApp.Infrastructure.Services;

public class UserAgentParserService : IUserAgentParserService
{
    private readonly Parser _parser;

    public UserAgentParserService()
    {
        _parser = Parser.GetDefault();
    }

    public string Parse(string userAgentString)
    {
        ClientInfo clientInfo = _parser.Parse(userAgentString);

        return JsonConvert.SerializeObject(clientInfo);
    }
}