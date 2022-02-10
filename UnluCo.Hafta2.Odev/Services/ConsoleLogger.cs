using System;

namespace UnluCo.Hafta2.Odev.Services
{
        public class ConsoleLogger : ILoggerService
        {
                public void Write(string message)
                {
                        Console.WriteLine("[ConsoleLogger] - " + message);
                }
        }
}