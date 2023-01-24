namespace BeautySalonManage.Application.DTOs.Turns
{
    public class TurnDTO
    {
        public long TurnId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneCustomer { get; set; }
        public string Observation { get; set; }
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }

        public List<TurnDetailDTO> Details { get; set; }
        public List<TurnAdditionalDetailDTO> AdditionalDetails { get; set; }
    }
}
