using DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Entity_Configuration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {

            //1: override the table name
            ToTable("tbl_Course");

            //2: override the primary key
            HasKey(c => c.Id);


            //3: porperty configuration 
            //sort in asc
            Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(2000);

            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);


            //4: relation-ships
            //also sort them asc
            
            // course - author
            //each course has one author
            HasRequired(c => c.Author)
            //each author has many courses
            .WithMany(a => a.Courses)
            //to configure the foreign key
            .HasForeignKey(c => c.AuthorID)
            .WillCascadeOnDelete(false);

            // Course - Cover
            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(c => c.Course);


            //we want our own name in Intermediatory class
            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            //here m is the many to many navigation property
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId");
                    //our left is course because we started with Course
                    m.MapRightKey("TagId");
            });
            
        }
    }
}
