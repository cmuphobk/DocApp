namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Symptom
{
    public class ById: Specification<Entity.POCO.Symptom>
    {
        public ById(int value)
            : base(element => element.id == value)
        {
        }
    }
}
