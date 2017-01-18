namespace DocAppBackendWithAuth.Entity.Specifications.POCO.User
{
    public class ByUserId: Specification<Entity.POCO.BaseUser>
    {
        public ByUserId(string value)
            : base(element => element.User.Id == value)
        {
        }
    }
}
