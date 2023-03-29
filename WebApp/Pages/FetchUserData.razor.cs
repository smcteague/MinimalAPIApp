using Microsoft.AspNetCore.Components;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages;

public partial class FetchUserData
{
    [Inject]
    private IUserRepository Repository { get; set; } = null!;

    public IEnumerable<User> Users { get; private set; } = Enumerable.Empty<User>();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Users = await Repository.GetUsersAsync();
    }
}
