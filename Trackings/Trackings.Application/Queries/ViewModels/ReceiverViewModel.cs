namespace Trackings.Application.Queries
{
    public class ReceiverViewModel
    {
        public int id { get; set; }
        public int realId { get; set; }
        public string realName { get; set; }
        public string realAddress { get; set; }
        public string contactName { get; set; }
        public string contactEmail { get; set; }
        public string contactPhone { get; set; }
        public bool autoGo { get; set; }
        public bool active { get; set; }
    }
}
