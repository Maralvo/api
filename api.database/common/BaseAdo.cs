using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace api.database.common
{
    public abstract class BaseAdo
    {
        protected readonly string SSH_HOST = ConfigurationManager.AppSettings["SSH_HOST"];
        protected readonly string SSH_USER = ConfigurationManager.AppSettings["SSH_USER"];
        protected readonly string SSH_PASSWORD = ConfigurationManager.AppSettings["SSH_PASSWORD"];
        protected readonly string BOUND_HOST = ConfigurationManager.AppSettings["BOUND_HOST"];
        protected readonly uint BOUND_PORT = Convert.ToUInt32(ConfigurationManager.AppSettings["BOUND_PORT"]);
        protected readonly string HOST = ConfigurationManager.AppSettings["HOST"];
        protected readonly uint PORT = Convert.ToUInt32(ConfigurationManager.AppSettings["PORT"]);

        protected readonly MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            UserID = ConfigurationManager.AppSettings["DATABASE_USER"],
            Password = ConfigurationManager.AppSettings["DATABASE_PASS"],
            Server = ConfigurationManager.AppSettings["DATABASE_SERVER"],
            SshHostName = ConfigurationManager.AppSettings["SSH_HOST"],
            SshUserName = ConfigurationManager.AppSettings["SSH_USER"],
            SshPassword = ConfigurationManager.AppSettings["SSH_PASSWORD"],
            Database = ConfigurationManager.AppSettings["DATABASE"]
        };
    }
}
