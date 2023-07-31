using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTaskManager.Model;

public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateOfStart { get; set; }
    public int TeamSize { get; set; }
}

public class TaskManagerDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-UCUSAML;Database=Taskmanager;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
    public DbSet<Project> Projects { get; set; }


}
