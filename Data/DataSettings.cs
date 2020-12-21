using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;

namespace FProject.Data.DataSettings
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class DataSettings : ILinqToDBSettings 
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();
        public string DefaultConfiguration => "PostgreSQL";
        public string DefaultDataProvider => "PostgreSQL";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings 
        {
            get 
            {
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                yield return
                    new ConnectionStringSettings
                    {
                        ConnectionString = connectionString,
                        Name = "FProjectDb",
                        ProviderName = "PostgreSQL"
                    };
            }
        }
    }
}
