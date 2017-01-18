using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSystem.Entity.POCO
{
    /// <summary>
    /// Запись о работе адвоката на судебном участке
    /// </summary>
    public class LawyerInDistrict
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Судебный участок
        /// </summary>
        public virtual JudicialDistrict District { get; set; }

        /// <summary>
        /// Юрист
        /// </summary>
        public virtual Lawyer Lawyer { get; set; }

        /// <summary>
        /// Дата начала работы
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания работы
        /// </summary>
        public DateTime? DateEnd { get; set; }
    }
}
