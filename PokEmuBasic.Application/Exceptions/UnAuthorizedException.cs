using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Exceptions;

public class UnAuthorizedException : Exception
{
    public UnAuthorizedException() : base() { }
    public UnAuthorizedException(string message) : base(message) { }
}
