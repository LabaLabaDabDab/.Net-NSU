using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElonVSmarkTask4
{
    public class ExperimentCondition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Deck { get; set; }
        public bool Success { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        private string _datasource = null!;
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationDbContext(String datasource)
        {
            _datasource = datasource;
            Database.EnsureCreated();
        }
        public DbSet<ExperimentCondition> ExperimentConditions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {      
            if (_datasource != null)
            {
                optionsBuilder.UseSqlite($"Data Source=file:{_datasource}?cache=shared");
            }
            else
            {
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\thest\\source\\repos\\ElonVSmarkTask4\\ElonVSmarkTask4\\experiments.db");
            }
        }

        public List<ExperimentCondition> GetExperimentConditions()
        {
            return ExperimentConditions.ToList();
        }
    }
}