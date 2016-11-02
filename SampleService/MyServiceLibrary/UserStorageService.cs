using System;
using System.Collections.Generic;
using System.Linq;

namespace MyServiceLibrary
{
    public class UserStorageService : IUserStorageService
    {
        private List<User> _listOfUsers = new List<User>();
        private Func<List<User>, int> _idGeneratorFunction;

        public UserStorageService(Func<List<User>, int> generatorFunction)
        {
            _listOfUsers = new List<User>();
            _idGeneratorFunction = generatorFunction;
        }

        // Add all required methods here.
        public User Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                throw new UserCreateException("Firstname and Lastname should be not empty");
            }

            if (user.DateOfBirth == null)
            {
                throw new UserCreateException("Date Of Birth should be not empty");
            }

            if (IsUserAlreadyExists(user))
            {
                throw new UserAlreadyExistsException("User with such parameters already exists");
            }

            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };

            newUser.Id = _idGeneratorFunction(_listOfUsers);

            _listOfUsers.Add(newUser);
            return newUser;
        }

        //public IEnumerable<User> GetUsersByFirstAndLastName(string firstName, string lastName)
        //{
        //    return GetUsersByPredicate(r => r.FirstName == firstName && r.LastName == lastName);
        //}

        public IEnumerable<User> GetUsersByPredicate(Func<User, bool> func)
        {
            return _listOfUsers.Where(func);
        }

        public User GetUser(int id)
        {
            //var user = _listOfUsers.FirstOrDefault(r => r.Id == id);
            //if (user == null)
            //{
            //    throw new 
            //}
            var us = _listOfUsers.FirstOrDefault(r => r.Id == id);
            return us;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _listOfUsers;
        }

        public User GetUser(string firstName, string lastName, DateTime birth)
        {
            throw new NotImplementedException();
        }


        private bool IsUserAlreadyExists(User user)
        {
            var userExist = _listOfUsers.Any(r => r.FirstName.Equals(user.FirstName, StringComparison.OrdinalIgnoreCase)
                                             && r.LastName.Equals(user.LastName, StringComparison.OrdinalIgnoreCase)
                                             && r.DateOfBirth == user.DateOfBirth);

            return userExist;
        }

        
    }
}
