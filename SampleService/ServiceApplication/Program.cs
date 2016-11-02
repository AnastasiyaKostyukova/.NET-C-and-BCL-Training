using MyServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //var idGenerator = new UserIdArithmProgressionGenerator(5);
            //var service = new UserStorageService(idGenerator.IdGeneratorAsArithmeticProgression);

            var service = new UserStorageService(UserIdDefaultGenerator.DefaultIdGenerator);
            service.Add(new User { FirstName = "1", LastName = "11", DateOfBirth = new DateTime(1991, 11, 5) });
            service.Add(new User { FirstName = "2", LastName = "22", DateOfBirth = new DateTime(1991, 8, 5) });
            service.Add(new User { FirstName = "3", LastName = "33", DateOfBirth = new DateTime(1991, 10, 5) });

            //var a = service.GetUsersByPredicate(r => r.FirstName == "A0");
            //foreach (var user in a)
            //{
            //    Console.WriteLine(user.LastName);
            //}

            foreach (var user in service.GetAllUsers())
            {
                Console.WriteLine(user.Id + " " + user.FirstName);
            }

            var us = service.GetUser(1);
            Console.WriteLine(us.FirstName);

            // 1. Add a new user to the storage. ----- DONE
            // 2. Remove an user from the storage.
            // 3. Search for an user by the first name. --- NO Search USERS by predicate
            // 4. Search for an user by the last name.  --- also NO
        }
    }
}
