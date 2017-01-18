using System;
using System.Linq;

namespace LawSystem.Entity.Specifications.POCO.Lawyer
{
    public class ByIdDistrict : Specification<Entity.POCO.Lawyer>
    {
        public ByIdDistrict(int value)
            : base(element => element.Districts.Any(t => t.District.Id == value && (t.DateEnd==null || t.DateEnd > DateTime.Now)) )
        {
        }
    }
}
