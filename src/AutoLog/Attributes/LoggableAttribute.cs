using System;

namespace AutoLogger {

    [AttributeUsage(
        AttributeTargets.Class
    )]
    public class LoggableAttribute : System.Attribute {
        public LoggableItem LoggableItems { get; set; }
    }

}