namespace CP.Entities.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CafeProjectModel : DbContext
    {
        public CafeProjectModel()
            : base("name=CafeProjectModel")
        {
            Database.SetInitializer<CafeProjectModel>(null);
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampProduct> CampProduct { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<CompanyInformation> CompanyInformation { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LogStatus> LogStatus { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MusicClaim> MusicClaim { get; set; }
        public virtual DbSet<MusicList> MusicList { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<LogInfo> LogInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyInformation>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.LocationGeneral)
                .IsUnicode(false);

            modelBuilder.Entity<Emails>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Images>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Images>()
                .HasMany(e => e.Category)
                .WithOptional(e => e.Images)
                .HasForeignKey(e => e.ImageId);

            modelBuilder.Entity<Images>()
                .HasMany(e => e.Menu)
                .WithOptional(e => e.Images)
                .HasForeignKey(e => e.ImageId);

            modelBuilder.Entity<Locations>()
                .Property(e => e.LocationName)
                .IsUnicode(false);

            modelBuilder.Entity<LogStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MusicClaim>()
                .Property(e => e.MusicName)
                .IsUnicode(false);

            modelBuilder.Entity<MusicList>()
                .Property(e => e.MusicName)
                .IsUnicode(false);

            modelBuilder.Entity<Phones>()
                .Property(e => e.Phone)
                .IsFixedLength()
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
                .Property(e => e.Photo)
                .IsUnicode(false);
        }
    }
}
