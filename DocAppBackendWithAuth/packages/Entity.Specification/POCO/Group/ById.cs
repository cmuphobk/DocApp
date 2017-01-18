namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Message
{
    public class ById: Specification<Entity.POCO.Message>
    {
        public ById(int value)
            : base(element => element.Id == value)
        {
        }
    }
}
