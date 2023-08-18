using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayerAPI.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Admins = new HashSet<Admin>();
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
