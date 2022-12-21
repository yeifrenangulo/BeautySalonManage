using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime? DateBirth { get; set; }
        public int GenderId { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
