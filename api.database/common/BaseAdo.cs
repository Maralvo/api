using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace api.database.common
{
    public abstract class BaseAdo
    {
        protected readonly string CS = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;
        protected readonly string SSH_HOST = ConfigurationManager.AppSettings["SSH_HOST"];
        protected readonly string SSH_USER = ConfigurationManager.AppSettings["SSH_USER"];
        protected readonly string SSH_PASSWORD = ConfigurationManager.AppSettings["SSH_PASSWORD"];
        protected readonly string BOUND_HOST = ConfigurationManager.AppSettings["BOUND_HOST"];
        protected readonly uint BOUND_PORT = Convert.ToUInt32(ConfigurationManager.AppSettings["BOUND_PORT"]);
        protected readonly string HOST = ConfigurationManager.AppSettings["HOST"];
        protected readonly uint PORT = Convert.ToUInt32(ConfigurationManager.AppSettings["PORT"]);
    }
}
