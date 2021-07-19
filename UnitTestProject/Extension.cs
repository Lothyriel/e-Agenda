using e_Agenda.Controladores;
using System;

namespace UnitTestProject.Extensions
{
    static class Extension
    {
        public static string resetId(string tableName)
        {
            switch (Db.bancoSelecionado)
            {
                case "SQLServer": return resetIdSQLServer(tableName);
                case "SQLite": return resetIdSQLite(tableName);
                default: throw new ArgumentException(message: "Invalid providerName");
            }
        }
        private static string resetIdSQLServer(string tableName)
        {
            return $@"DELETE FROM {tableName} DBCC CHECKIDENT('[{tableName}]', RESEED, 0)";
        }
        private static string resetIdSQLite(string tableName)
        {
            return $@"DELETE FROM {tableName};
                      update SQLITE_SEQUENCE
                      set seq = 0
                      where name = '{tableName}'";
        }
    }
}
