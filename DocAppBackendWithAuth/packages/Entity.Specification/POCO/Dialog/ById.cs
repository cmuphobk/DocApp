namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Dialog
{
    public class ById: Specification<Entity.POCO.Dialog>
    {
        public ById(int value)
            : base(element => element.Id == value)
        {
        }
    }
}
