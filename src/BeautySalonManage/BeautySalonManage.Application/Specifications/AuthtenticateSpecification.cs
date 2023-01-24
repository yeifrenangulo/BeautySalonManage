using Ardalis.Specification;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Specifications
{
    public class AuthtenticateSpecification : Specification<User>
    {
        public AuthtenticateSpecification(string login, string password)
        {
            Query.Where(w => w.UserName == login && w.Password == password);
        }
    }
}
