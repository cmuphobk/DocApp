namespace LawSystem.Entity.Specifications.POCO.LawyerInDistrict
{
    public class ById: Specification<Entity.POCO.LawyerInDistrict>
    {
        public ById(int value)
            : base(element => element.Id == value)
        {
        }
    }
}
