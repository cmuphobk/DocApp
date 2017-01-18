namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Dialog
{
    public class ByUser: Specification<Entity.POCO.Dialog>
    {
        public ByUser(int value)
            : base(element => element.FirstUser.Id == value || element.SecondUser.Id == value)
        {
        }
    }
}
