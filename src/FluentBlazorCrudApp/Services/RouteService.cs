using Microsoft.AspNetCore.Components;

namespace FluentBlazorCrudApp.Services;
public class RouteService
{
    private readonly NavigationManager _nav;
    private readonly StateContainer _state;
    public RouteService(NavigationManager nav, StateContainer state) { _nav = nav; _state = state; }
    public void NavigateTo(string uri) { _state.SetRoute(uri); _nav.NavigateTo(uri); }
}
