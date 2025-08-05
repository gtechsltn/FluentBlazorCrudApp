namespace FluentBlazorApp.Application.Services;

public interface IUserAgentParserService
{
    string Parse(string userAgentString);
}