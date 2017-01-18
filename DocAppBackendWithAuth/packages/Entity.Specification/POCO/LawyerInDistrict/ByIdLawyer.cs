namespace LawSystem.Entity.Specifications.POCO.LawyerInDistrict
{
    public class ByIdLawyer: Specification<Entity.POCO.LawyerInDistrict>
    {
        public ByIdLawyer(int value)
            : base(element => element.Lawyer.Id == value)
        {
        }
    }
}
