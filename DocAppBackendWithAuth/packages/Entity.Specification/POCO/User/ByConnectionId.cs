namespace DocAppBackendWithAuth.Entity.Specifications.POCO.User
{
    public class ByConnectionId : Specification<Entity.POCO.BaseUser>
    {
        public ByConnectionId(string value)
            : base(element => element.ConnectionId == value)
        {
        }
    }
}
