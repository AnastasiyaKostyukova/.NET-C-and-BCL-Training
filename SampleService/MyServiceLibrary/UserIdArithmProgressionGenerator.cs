using System.Collections.Generic;
using System.Linq;

namespace MyServiceLibrary
{
    public class UserIdArithmProgressionGenerator
    {
        private readonly int _step;

        public UserIdArithmProgressionGenerator(int step)
        {
            _step = step;
        }

        public int IdGeneratorAsArithmeticProgression(List<User> users)
        {
            var lastUser = users.LastOrDefault();

            if (lastUser == null)
            {
                return 1;
            }

            var newUserId = lastUser.Id + _step;
            return newUserId;
        }
    }
}
