using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DemoKafka.PersistenceEFCore.DataContexts
{
    internal class DemoKafkaContextFactory :
        IDesignTimeDbContextFactory<DemoKafkaContext>
    {
        //Add-Migration AddDemoKafka -p DemoKafka.PersistenceEFCore -s DemoKafka.PersistenceEFCore -c DemoKafkaContextFactory
        //Update-Database -p DemoKafka.PersistenceEFCore -s DemoKafka.PersistenceEFCore -context DemoKafkaContextFactory
        public DemoKafkaContext CreateDbContext(string[] args)
        {
            var OptionBuilder =
            new DbContextOptionsBuilder<DemoKafkaContext>();

            OptionBuilder
                .UseMySQL("server=localhost;port=3307;database=TareaKafka;user=root;password=DemoKafka#2024");

            return new DemoKafkaContext(OptionBuilder.Options);
        }
    }
}
