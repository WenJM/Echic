using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Echic.Domain.Base;

namespace Echic.Domain.Model
{
    public partial class ES_User : AggregateRoot
    {
        public new string ObjectID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<DateTime> Expired { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedTime { get; set; }
    }
}
