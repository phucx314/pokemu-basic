using System.Diagnostics.CodeAnalysis;

namespace PokEmuBasic.Application.Exceptions;

public class ForbiddenException : Exception
{
    public ForbiddenException() : base() { }
    public ForbiddenException(string message) : base(message) { }
}