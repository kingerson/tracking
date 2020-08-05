using System;

namespace Trackings.Domain.Core
{
    public abstract class Entity
    {
        public int register_user_id { get; set; }
        public string register_user_fullname { get; set; }
        public DateTime register_datetime { get; set; }
        public int update_user_id { get; set; }
        public string update_user_fullname { get; set; }
        public DateTime update_datetime { get; set; }
    }
}
