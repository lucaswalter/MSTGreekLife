using System.Data.Entity;

namespace MSTGreekLife.DAL
{
    public class GreekLifeInitializer : DropCreateDatabaseIfModelChanges<GreekLifeContext>
    {
        protected override void Seed(GreekLifeContext context)
        {

        }
    }
}