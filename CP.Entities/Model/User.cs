namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comment = new HashSet<Comment>();
            Order = new HashSet<Order>();
            UserRoles = new HashSet<UserRoles>();
            IsConfirm = false;
            IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(150)]
        [Display(Name = "Kullanýcý Adý")]
        [Required(ErrorMessage = "Kullanýcý Adý Zorunludur")]
        public string Username { get; set; }

        [StringLength(150)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Geçerli Email Giriniz")]
        [Required(ErrorMessage = "Email Zorunludur")]
        public string Email { get; set; }

        [StringLength(150)]
        [Display(Name = "Adýnýz")]
        [Required(ErrorMessage = "Ad alaný Zorunludur")]
        [RegularExpression("^[a-zA-ZçÇðÐýÝöÖþÞüÜ]*$", ErrorMessage = "Sadece harflerden oluþmalýdýr")]

        public string FirstName { get; set; }

        [StringLength(150)]
        [Display(Name = "Soyadýnýz")]
        [Required(ErrorMessage = "Soyadý alaný Zorunludur")]
        [RegularExpression("^[a-zA-ZçÇðÐýÝöÖþÞüÜ]*$", ErrorMessage = "Sadece harflerden oluþmalýdýr")]

        public string LastName { get; set; }

        [StringLength(150)]
        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Parola alaný Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool? IsConfirm { get; set; }

        public bool? IsDeleted { get; set; }

        [StringLength(200)]
        [Display(Name = "Resim")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
