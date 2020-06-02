namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRoles : BaseEntity<int>
    {
        public UserRoles()
        {
            IsDeleted = false;
        }
        public int? UserId { get; set; }

        public int? RoleId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Roles Roles { get; set; }

        public virtual User User { get; set; }
    }
}
