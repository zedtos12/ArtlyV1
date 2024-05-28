using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;

namespace ArtlyV1.Repository
{
    public class ActiveEntitiesInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) { }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) { }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            ModifyCommand(command);
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) { }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) { }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) { }

        private void ModifyCommand(DbCommand command)
        {
            if (command.CommandText.Contains("FROM") && !command.CommandText.Contains("IsActive"))
            {
                command.CommandText = command.CommandText.Replace("FROM", "WHERE IsActive = 1 AND FROM");
            }
        }
    }
}