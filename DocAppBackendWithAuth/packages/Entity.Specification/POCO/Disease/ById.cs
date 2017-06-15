namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Disease
{
    public class ById: Specification<Entity.POCO.Disease>
    {
        public ById(int value)
            : base(element => element.Id == value)
        {
        }
    }
}
