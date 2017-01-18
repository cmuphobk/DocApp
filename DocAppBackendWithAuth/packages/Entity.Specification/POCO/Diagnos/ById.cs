namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Diagnos
{
    public class ById: Specification<Entity.POCO.Diagnos>
    {
        public ById(int value)
            : base(element => element.id == value)
        {
        }
    }
}
