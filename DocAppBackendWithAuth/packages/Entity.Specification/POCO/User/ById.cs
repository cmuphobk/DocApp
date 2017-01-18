namespace DocAppBackendWithAuth.Entity.Specifications.POCO.User
{
    public class ById: Specification<Entity.POCO.BaseUser>
    {
        public ById(int value)
            : base(element => element.Id == value)
        {
        }
    }
}
