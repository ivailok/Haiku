using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.DTO.Exceptions
{
    public class DuplicateNicknameException : Exception
    {
        public DuplicateNicknameException(string message = null)
            : base(message)
        {
        }

        public DuplicateNicknameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
