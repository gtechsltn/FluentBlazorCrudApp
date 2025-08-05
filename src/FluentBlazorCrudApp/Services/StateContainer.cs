namespace FluentBlazorCrudApp.Services;
public class StateContainer
{
    public string CurrentRoute { get; private set; } = "/";
    public event Action? OnChange;
    public void SetRoute(string route) { CurrentRoute = route; OnChange?.Invoke(); }
}
