using System.Data.Entity;

namespace DataAnnotations
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder
              .Entity<Course>()
              .Property(c => c.Description)
              .IsRequired()
              .HasMaxLength(2000);

            //each course has one author
            modelBuilder
                .Entity<Course>()
                .HasRequired(c => c.Author)
                //each author has many courses
                .WithMany(a=>a.Courses)
                //to configure the foreign key
                .HasForeignKey(c=>c.AuthorID)
                .WillCascadeOnDelete(false);



            base.OnModelCreating(modelBuilder);
        }
    }
}