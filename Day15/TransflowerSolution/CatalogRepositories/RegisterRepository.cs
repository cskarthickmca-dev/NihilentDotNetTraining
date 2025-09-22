namespace CatalogRepositories;

using CatalogEntities;
using System.Collections.Generic;
public class RegisterRepository : IRegisterRepository
{


    //automic operations
    public IEnumerable<Register> GetAllUser()
    {
        return JSONCatalogManager.LoadUsers();
    }


    public Register? GetUserByEmailId(string email)
    {
        IEnumerable<Register> registers = GetAllUser();
        return registers.FirstOrDefault(p => p.email == email);
    }

    public void AddUser(Register register)
    {
        List<Register> registers = GetAllUser().ToList();
        registers.Add(register);
        JSONCatalogManager.SaveRegistrationData(registers);
    }

    public void UpdateUser(Register register)
    {
        Console.WriteLine("update user inside repository:::::"+register);
        List<Register> registers = GetAllUser().ToList();
        var existingUser = registers.FirstOrDefault(p => p.email == register.email);
        if (existingUser != null)
        {
            existingUser.firstname = register.firstname;
            existingUser.lastname = register.lastname;
            existingUser.email = register.email;
            existingUser.password = register.password;
            JSONCatalogManager.SaveRegistrationData(registers);
        } else {
            JSONCatalogManager.SaveRegistrationData(registers);
        }
         
    }

    public void DeleteUser(string email)
    {
        List<Register> registers = GetAllUser().ToList();
        var registerToRemove = registers.FirstOrDefault(p => p.email == email);
        if (registerToRemove != null)
        {
            registers.Remove(registerToRemove);
            JSONCatalogManager.SaveRegistrationData(registers);
        }
    }
}
