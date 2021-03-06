namespace NhomXingfa.Areas.Quantri.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PermissionRole
    {
        [Key]
        public int PermitRoleID { get; set; }

        public int? RoleID { get; set; }

        public int? PermissionID { get; set; }

        public DateTime? Created { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Role Role { get; set; }
    }
}
