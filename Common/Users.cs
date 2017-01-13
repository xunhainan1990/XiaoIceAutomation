using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    public class UserConfiguration
    {
        public User[] Users;
    }
    
    public class User
    {
        public string UserID;
        public string UserNickname;
        public string Sign;

    }
}
