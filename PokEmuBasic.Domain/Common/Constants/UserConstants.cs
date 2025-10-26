using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Common.Constants
{
    public static class UserConstants
    {
        public const int FULLNAME_MIN_LENGTH = 1;
        public const int FULLNAME_MAX_LENGTH = 100;

        public const int USERNAME_MIN_LENGTH = 8;
        public const int USERNAME_MAX_LENGTH = 50;

        public const int PASSWORD_MIN_LENGTH = 8;
        public const int PASSWORD_MAX_LENGTH = 50;
    }
}
