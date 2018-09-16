using Microsoft.EntityFrameworkCore;

namespace AutoRegistryTechingClass.AutoRegistry.Data
{
    public class RegisteredClassManagerContext: DbContext
    {
        public DbSet<RegisteredClass> RegisteredClass { get; set; }
        public DbSet<Settings> Settings { get; set; }

        public RegisteredClassManagerContext(DbContextOptions option) : base(option)
        {
        }

        public RegisteredClassManagerContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisteredClass>().HasKey(c => c.Id);
            modelBuilder.Entity<RegisteredClass>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RegisteredClass>().Property(c => c.Registered).HasDefaultValue(false);


            modelBuilder.Entity<Settings>().HasKey(c => c.Id);
            modelBuilder.Entity<Settings>().Property(c => c.SettingKey).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=./RegisteredClassManagerment.db");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }

    public class RegisteredClass
    {
        public int Id { get; set; }
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public bool Registered { get; set; }
    }

    public class Settings
    {
        public int Id { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
    }
}
