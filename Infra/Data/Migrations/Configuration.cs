﻿using Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace Infra.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}

//So para testar o commit