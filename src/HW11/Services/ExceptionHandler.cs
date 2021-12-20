using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace HW11.Services
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;
        
        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }
        
        public void HandleException<T>(T exception) where T : Exception
        {
            this.Handle((dynamic) exception);
        }

        public void Handle(NullReferenceException exception)
        {
            _logger.LogError($"Null reference exception: {exception.Message}");
        }

        public void Handle(ArgumentException exception)
        {
            _logger.LogError($"ArgumentException: {exception.Message}");
        }

        public void Handle(Exception exception)
        {
            _logger.LogError($"Base exception: {exception.Message}");
        }
        
        public void Handle(DivideByZeroException exception)
        {
            _logger.LogError($"Divide by zero exception: {exception.Message}");
        }
    }
}
