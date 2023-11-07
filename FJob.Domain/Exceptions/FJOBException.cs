using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJob.Domain.Exceptions;

public class FJOBException : Exception 
{
    public FJOBException()
    {
    }

    public FJOBException(string? message) : base(message)
    {
    }

    public FJOBException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
