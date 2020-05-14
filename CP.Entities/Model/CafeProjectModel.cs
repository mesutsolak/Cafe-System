namespace CP.Entities.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CafeProjectModel : DbContext
    {
        public CafeProjectModel()
          : base("CafeProjectModel")
        {
            Database.SetInitializer<CafeProjectModel>(null);
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampProduct> CampProduct { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<CompanyInformation> CompanyInformation { get; set; }
        public virtual DbSet<ConfirmStatus> ConfirmStatus { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LogInfoes> LogInfoes { get; set; }
        public virtual DbSet<LogStatus> LogStatus { get; set; }
        public virtual DbSet<MusicList> MusicList { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<HomePage> HomePage { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyInformation>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyInformation>()
                .Property(e => e.Header1)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyInformation>()
                .Property(e => e.Header2)
                .IsUnicode(false);

            modelBuilder.Entity<ConfirmStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ConfirmStatus>()
                .HasMany(e => e.Cart)
                .WithOptional(e => e.ConfirmStatus)
                .HasForeignKey(e => e.ConfirmId);

            modelBuilder.Entity<ConfirmStatus>()
                .HasMany(e => e.MusicList)
                .WithOptional(e => e.ConfirmStatus)
                .HasForeignKey(e => e.ConfirmId);

            modelBuilder.Entity<ConfirmStatus>()
                .HasMany(e => e.Table)
                .WithOptional(e => e.ConfirmStatus)
                .HasForeignKey(e => e.ConfirmId);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.LocationGeneral)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Twitter)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Facebook)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Instagram)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.UrlAccessed)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Data)
                .IsUnicode(false);

            modelBuilder.Entity<LogInfoes>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<LogInfoes>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<LogInfoes>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<LogInfoes>()
                .Property(e => e.ExceptionMessage)
                .IsUnicode(false);

            modelBuilder.Entity<LogStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MusicList>()
                .Property(e => e.MusicName)
                .IsUnicode(false);

            modelBuilder.Entity<MusicList>()
                .Property(e => e.ArtistName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductDetail)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.Roles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
