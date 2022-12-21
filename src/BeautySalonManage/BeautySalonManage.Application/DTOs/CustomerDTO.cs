namespace BeautySalonManage.Application.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public int GenderId { get; set; }
        public string GenderDescription { get; set; }
    }
}
