using System;

namespace UnluCo.Hafta2.Odev.Services
{
        public class DBLogger : ILoggerService
        {
                public void Write(string message)
                {
                        Console.WriteLine("[DBLogger] - " + message);
                }
        }
}