namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Group
{
    public class ById: Specification<Entity.POCO.Group>
    {
        public ById(int value)
            : base(element => element.id == value)
        {
        }
    }
}
