using SEM.Core.Migrations;
using SEM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM.Core.DAL
{
    class PublisherInitializer : MigrateDatabaseToLatestVersion<SEM.Models.ApplicationDbContext, Configuration>
    {
    }
}
