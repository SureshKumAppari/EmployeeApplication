namespace EmployeeApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(1000)]
        public string Email { get; set; }

        [StringLength(1000)]
        public string Alias { get; set; }

        [StringLength(1000)]
        public string FirstName { get; set; }

        [StringLength(1000)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        public int? ManagerId { get; set; }
    }
}
