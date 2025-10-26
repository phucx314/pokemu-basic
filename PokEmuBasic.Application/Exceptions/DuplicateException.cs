using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Exceptions
{
    /// <summary>
    /// Exception được ném ra khi cố gắng tạo một tài nguyên đã tồn tại.
    /// Thường sẽ được map thành HTTP Status Code 409 Conflict.
    /// </summary>
    public class DuplicateException : Exception
    {
        public DuplicateException(string message) : base(message) { }
    }
}
