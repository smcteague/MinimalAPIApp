using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace WebApp.Pages;

public class FetchUserDataBase : ComponentBase
{
    protected List<Models.UserModel> UsersList { get; set; } = new List<Models.UserModel>();

    protected async override Task OnInitializedAsync()
    {
        var httpClient = new HttpClient();
        UsersList = await httpClient.GetFromJsonAsync<List<Models.UserModel>>("https://localhost:7040/users");

        base.OnInitialized();
    }
}


