namespace Trackings.Application.Queries.Mappers
{
    public class ReceiverMapper
    {
        public int mall_id { get; set; }
        public int mall_real_id { get; set; }
        public string mall_real_name { get; set; }
        public string mall_real_address { get; set; }
        public string mall_contact_name { get; set; }
        public string mall_contact_email { get; set; }
        public string mall_contact_phone { get; set; }
        public bool mall_auto_go { get; set; }
        public bool mall_active { get; set; }
    }
}
