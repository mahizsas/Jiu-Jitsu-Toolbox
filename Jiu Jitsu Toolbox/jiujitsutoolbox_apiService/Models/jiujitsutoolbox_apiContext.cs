using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
using jiujitsutoolbox_apiService.DataObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace jiujitsutoolbox_apiService.Models
{
    public class jiujitsutoolbox_apiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public jiujitsutoolbox_apiContext() : base(connectionStringName)
        {
        } 

        //public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }
            
            // I happen to like my table names to be singular
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // set the Id column of every to be the PK
            modelBuilder.Properties<string>()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            modelBuilder.Entity<Profile>()
                .Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Training>()
                .Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<School>()
               .Property(m => m.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Event>()
               .Property(m => m.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Location>()
               .Property(m => m.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // map Profile to Training and back
            modelBuilder.Entity<Training>().HasRequired(t => t.Profile)
                .WithMany(p => p.Training)
                .HasForeignKey(t => t.ProfileId);

            // map Event to Location and back
            modelBuilder.Entity<Event>().HasRequired(e => e.Location)
                .WithMany(l => l.Events)
                .HasForeignKey(e => e.LocationId);

            // map School to Location
            modelBuilder.Entity<School>().HasRequired(s => s.Location)
                .WithMany()
                .HasForeignKey(s => s.LocationId);

            // map Reviews to School and back
            modelBuilder.Entity<Review>().HasRequired(r => r.School)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.SchoolId);
                


          
        }

    }

}
