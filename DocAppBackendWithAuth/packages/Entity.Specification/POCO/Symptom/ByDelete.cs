namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Symptom
{
    public class ByDelete: Specification<Entity.POCO.Symptom>
    {
        public ByDelete(bool value)
            : base(element => element.isDelete == value)
        {
        }
    }
}
