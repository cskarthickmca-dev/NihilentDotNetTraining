using System.Collections.Generic;
using SecureWebApp.Entities;
using SecureWebApp.Models;

namespace SecureWebApp.Services
{


    //Business Logic Layer for User authentication
    public interface IUserService
    {

        //DTO:
        //Data Transfer Object
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}