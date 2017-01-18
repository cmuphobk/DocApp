namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Weight
{
    public class ById: Specification<Entity.POCO.Weight>
    {
        public ById(int value)
            : base(element => element.id == value)
        {
        }
    }
}
