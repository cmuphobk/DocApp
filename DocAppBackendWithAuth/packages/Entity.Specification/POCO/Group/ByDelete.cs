namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Group
{
    public class ByDelete: Specification<Entity.POCO.Group>
    {
        public ByDelete(bool value)
            : base(element => element.isDelete == value)
        {
        }
    }
}
