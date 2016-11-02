using System;
using System.Collections.Generic;

namespace MyServiceLibrary
{
    public interface IUserStorageService
    {
        User Add(User user);
        IEnumerable<User> GetUsersByPredicate(Func<User, bool> func);
        User GetUser(int id);
        User GetUser(string firstName, string lastName, DateTime birth);
        IEnumerable<User> GetAllUsers();
    }
}
