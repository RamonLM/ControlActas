using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.Services
{
    public class MailServiceImpl : IMailService
    {
        public void sendMail(string to, string from, string subject, string body)
        {
            Debug.WriteLine($"Sending Mail To: {to} From: {from} Subject: {subject}");
        }
    }
}
