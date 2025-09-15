namespace CatalogServices;

using CatalogEntities;
using System.Collections.Generic;
public interface IRegisterService
{
    IEnumerable<Register> GetAllUser();
    Register? GetUserByEmailId(string email);
    void AddUser(Register register);
    void UpdateUser(Register register);
    void DeleteUser(string email);
}
