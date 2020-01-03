using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Echic.Domain.Base;

namespace Echic.Domain.Model
{
    [Table("es_user")]
    public partial class ES_User : IAggregateRoot
    {
        [Column("objectid")]
        public string ObjectID { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("expired")]
        public Nullable<DateTime> Expired { get; set; }
        [Column("createdby")]
        public string CreatedBy { get; set; }
        [Column("createdtime")]
        public Nullable<DateTime> CreatedTime { get; set; }
        [Column("modifiedby")]
        public string ModifiedBy { get; set; }
        [Column("modifiedtime")]
        public Nullable<DateTime> ModifiedTime { get; set; }
    }
}
