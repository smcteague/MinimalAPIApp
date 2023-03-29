using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{

    private readonly ISqlDataAccess _db;
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers()
    {
        var sql = "" +
            "select " +
                "Id, " +
                "FirstName, " +
                "LastName " +
            "from " +
                "dbo.[User];";

        return _db.LoadData<UserModel, dynamic>(sql, new { });
        //_db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });
    }

    public async Task<UserModel?> GetUser(int id)
    {
        var sql = "" +
            "select " +
                "Id, " +
                "FirstName, " +
                "LastName " +
            "from " +
                "dbo.[User]" +
            "where " +
                "Id = @Id;";

        var results = await _db.LoadData<UserModel, dynamic>(sql, new { Id = id });
        //var results = await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });

        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel user)
    {
        var sql = "" +
            "insert " +
                "into dbo.[User] " +
                "(FirstName, LastName) " +
            "values " +
                "(@FirstName, @LastName);";

        return _db.SaveData(sql, new { user.FirstName, user.LastName });
        //_db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });
    }

    public Task UpdateUser(UserModel user)
    {
        var sql = "" +
            "update dbo.[User] " +
            "set " +
                "FirstName = @FirstName, " +
                "LastName = @LastName " +
            "where " +
                "Id = @Id;";

        return _db.SaveData(sql, user);
        //_db.SaveData("dbo.spUser_Update", user);
    }

    public Task DeleteUser(int id)
    {
        var sql = "" +
            "delete " +
            "from " +
                "dbo.[User] " +
            "where " +
                "Id = @Id;";

        return _db.SaveData(sql, new { Id = id });
        //_db.SaveData("dbo.spUser_Delete", new { Id = id });
    }
}
