using System;
using System.Collections.Generic;
using System.Text;

namespace api.model
{
    public class MysqlConfiguration
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string SshHostName { get; set; }
        public string SshUserName { get; set; }
        public string SshPassword { get; set; }
        public string Database { get; set; }
    }
}
