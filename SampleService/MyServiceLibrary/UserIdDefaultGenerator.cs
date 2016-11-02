using System;
using System.Collections.Generic;
using System.Linq;

namespace MyServiceLibrary
{
    public class UserIdDefaultGenerator
    {
        public static int DefaultIdGenerator(List<User> users)
        {
            var lastUser = users.LastOrDefault();

            if (lastUser == null)
            {
                return 1;
            }

            var newUserId = lastUser.Id + 1;
            return newUserId;
        }
    }
}
