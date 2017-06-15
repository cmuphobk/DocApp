namespace DocAppBackendWithAuth.Entity.Specifications.POCO.Disease
{
    public class ByDiagnosId: Specification<Entity.POCO.Disease>
    {
        public ByDiagnosId(int value)
            : base(element => element.Diagnos.id == value)
        {
        }
    }
}
