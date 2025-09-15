namespace CatalogRepositories;

using CatalogEntities;
using System.Collections.Generic; 

public interface IRegisterRepository
{
    IEnumerable<Register> GetAllUser();
    Register? GetUserByEmailId(string email);
    void AddUser(Register register);
    void UpdateUser(Register register);
    void DeleteUser(string email);
}