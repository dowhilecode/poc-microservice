using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.UI.Models
{
    sealed public class MessagingOptions
    {
        public const string Messaging = "Messaging";
        
        public string Hostname { get; set; }
        public string OrderQueue { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
