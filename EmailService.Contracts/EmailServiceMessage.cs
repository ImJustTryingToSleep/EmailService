using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Contracts
{
    public class EmailServiceMessage
    {
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string MessageBody { get; set; }
    }
}
