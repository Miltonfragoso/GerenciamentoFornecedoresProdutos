using GerFuncProd.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace GerFuncProd.Infra.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<MeuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}

//So para testar o commit