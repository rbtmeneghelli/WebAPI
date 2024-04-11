using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public class NotificationMessage
    {
        public string Message { get; }

        public NotificationMessage(string message)
        {
            Message = message;
        }
    }
}
