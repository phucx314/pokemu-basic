using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Exceptions;

public class UnprocessableContentException : Exception
{
    public UnprocessableContentException() : base() { }
    public UnprocessableContentException(string message) : base(message) { }
}