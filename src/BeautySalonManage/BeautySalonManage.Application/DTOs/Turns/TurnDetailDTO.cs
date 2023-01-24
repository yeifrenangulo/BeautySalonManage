namespace BeautySalonManage.Application.DTOs.Turns
{
    public class TurnDetailDTO
    {
        public int CollaboratorId { get; set; }
        public string CollaboratorName { get; set; }
        public string CollaboratorSurname { get; set; }
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public decimal Price { get; set; }
    }
}
