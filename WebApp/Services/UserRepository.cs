using System.Net.Http.Json;
using WebApp.Models;

namespace WebApp.Services;

public class UserRepository : IUserRepository
{
    private readonly HttpClient _httpClient;
    private IEnumerable<User>? _users = null;

    public UserRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        if (_users == null)
            _users = await _httpClient.GetFromJsonAsync<User[]>("Users");

        return _users!;
    }
}
