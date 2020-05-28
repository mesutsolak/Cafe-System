namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("User")]
    public partial class User : BaseEntity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Cart = new HashSet<Cart>();
            Comment = new HashSet<Comment>();
            MusicList = new HashSet<MusicList>();
            Rate = new HashSet<Rate>();
            UserRoles = new HashSet<UserRoles>();
            IsConfirm = false;
            IsDeleted = false;
        }

        [StringLength(150)]
        [Display(Name = "Kullanýcý Adý")]
        [Required(ErrorMessage = "Kullanýcý adý boþ býrakýlamaz.")]
        public string Username { get; set; }

        [StringLength(150)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email boþ býrakýlamaz.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli email giriniz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(150)]
        [Display(Name = "Adý")]
        [Required(ErrorMessage = "Ýsim boþ býrakýlamaz.")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Ýsim sadece harflerden oluþmalýdýr.")]
        public string FirstName { get; set; }

        [StringLength(150)]
        [Display(Name = "Soyadý")]
        [Required(ErrorMessage = "Soyisim boþ býrakýlamaz.")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Soyisim sadece harflerden oluþmalýdýr.")]
        public string LastName { get; set; }

        [StringLength(150)]
        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Parola boþ býrakýlamaz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool? IsConfirm { get; set; }

        [StringLength(500)]
        [Display(Name = "Profil Fotoðrafý")]
        public string ProfilPhoto { get; set; }

        [StringLength(500)]
        [Display(Name = "Arka Plan Fotoðrafý")]
        public string BackGround { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet boþ býrakýlamaz.")]
        public int? GenderId { get; set; }

        public bool? IsDeleted { get; set; }

        [NotMapped]
        public HttpPostedFileBase ProfilPhotos { get; set; }
        [NotMapped]
        public HttpPostedFileBase BackGroundPhotos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MusicList> MusicList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
