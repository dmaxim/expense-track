
using System;

namespace Barney.Infrastructure.Configuration
{ 
    public class BarneyWebUIConfiguration
    {
        public BarneyWebUIConfiguration(string databaseConnectionString)
        {
            if (string.IsNullOrWhiteSpace(databaseConnectionString))
            {
                throw new ArgumentNullException(nameof(databaseConnectionString));
            }

            DatabaseConnectionString = databaseConnectionString;
        }


        public string DatabaseConnectionString { get; }
    }
}
