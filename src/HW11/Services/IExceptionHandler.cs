using System;
using Microsoft.Extensions.Logging;

namespace HW11.Services
{
    public interface IExceptionHandler
    {
        public void HandleException<T>(T exception) where T : Exception;
    }
}