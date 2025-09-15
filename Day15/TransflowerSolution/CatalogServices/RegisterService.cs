
namespace CatalogServices;

using CatalogEntities;
using System.Collections.Generic;
using CatalogRepositories;
public class RegisterService : IRegisterService
{
    private readonly IRegisterRepository _registerRepository;


    // Dependency Injection via constructor
    public RegisterService(IRegisterRepository registerRepository)
    {
        _registerRepository = registerRepository;
    }

    public IEnumerable<Register> GetAllUser()
    {
        


        // Do something with userId
        //file IO operations
        return _registerRepository.GetAllUser();
    }

    public Register? GetUserByEmailId(string email)
    {
        return _registerRepository.GetUserByEmailId(email);
    }

    public void AddUser(Register register)
    {
        _registerRepository.AddUser(register);
    }

    public void UpdateUser(Register register)
    {
        _registerRepository.UpdateUser(register);
    }

    public void DeleteUser(string email)
    {
        _registerRepository.DeleteUser(email);
    }
}