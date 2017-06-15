namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Diagnos
{
    public class ByDelete: Specification<Entity.POCO.Diagnos>
    {
        public ByDelete(bool value)
            : base(element => element.isDelete == value)
        {
        }
    }
}
