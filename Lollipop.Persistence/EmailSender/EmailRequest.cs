namespace Lollipop.Persistence.EmailSender
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    public class EmailRequest
    {
        public string toEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}