namespace LawSystem.Entity.Specifications.POCO.LawyerInDistrict
{
    public class ByIdDistrict: Specification<Entity.POCO.LawyerInDistrict>
    {
        public ByIdDistrict(int value)
            : base(element => element.District.Id == value)
        {
        }
    }
}
