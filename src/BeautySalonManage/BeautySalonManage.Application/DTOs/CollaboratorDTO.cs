namespace BeautySalonManage.Application.DTOs
{
    public class CollaboratorDTO
    {
        public int CollaboratorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NameContact { get; set; }
        public string PhoneContact { get; set; }
        public int GenderId { get; set; }
        public string GenderDescription { get; set; }
        public string Color { get; set; }
        public List<ServicePercentageDTO> Services { get; set; }
    }
}
