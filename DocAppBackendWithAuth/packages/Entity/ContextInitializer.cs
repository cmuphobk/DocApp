using System.Data.Entity;

namespace DocAppBackendWithAuth.Entity.Entity
{
    public class ContextInitializer : DropCreateDatabaseAlways<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            base.Seed(context);
        }
    }
}
