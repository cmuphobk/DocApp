namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Departament
{
    public class ByDelete: Specification<Entity.POCO.Departament>
    {
        public ByDelete(bool value)
            : base(element => element.isDelete == value)
        {
        }
    }
}
