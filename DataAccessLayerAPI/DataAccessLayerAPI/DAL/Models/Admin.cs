using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayerAPI.DAL.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
