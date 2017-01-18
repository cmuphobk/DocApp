namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Departament
{
    public class ById: Specification<Entity.POCO.Departament>
    {
        public ById(int value)
            : base(element => element.id == value)
        {
        }
    }
}
