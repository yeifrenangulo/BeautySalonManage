using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public int TypeUserId { get; set; }
        public string User1 { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual TypeUser TypeUser { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
