using System;
using AutoLogger.Contracts;

namespace AutoLogger {

    [AttributeUsage(
        AttributeTargets.Class
    )]
    public class LoggableAttribute : System.Attribute {

        public LoggableItem LoggableItems { get; set; }

    }

}