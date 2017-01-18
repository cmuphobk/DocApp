namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Dialog
{
    public class ByUsers: Specification<Entity.POCO.Dialog>
    {
        public ByUsers(int userFirstId, int userSecondId)
            : base(element => (element.FirstUser.Id == userFirstId && element.SecondUser.Id == userSecondId) || element.FirstUser.Id == userSecondId && element.SecondUser.Id == userFirstId)
        {
        }
    }
}
