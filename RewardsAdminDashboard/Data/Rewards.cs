using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RewardsAdminDashboard.Data
{
    public class RewardsContext : DbContext
    {
        public DbSet<RewardsDto> Rewards { get; set; }
        public DbSet<ChainsDto> Chains { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot Config = new ConfigurationBuilder()
                                        .AddUserSecrets<Program>()
                                        .Build();

            optionsBuilder.UseSqlServer(
                $"Server=tcp:{Config.GetSection("RewardsDatabase:DataSource").Value};Initial Catalog={Config.GetSection("RewardsDatabase:InitialCatalog").Value};Persist Security Info=False;User ID={Config.GetSection("RewardsDatabase:UserID").Value};Password='{Config.GetSection("RewardsDatabase:Password").Value}';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30");
        }
    }

    public class RewardsDto
    {
        [Required]
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime RewardDate { get; set; }

        [Required]
        public int ChainId { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        public Single Amount { get; set; }
    }

    public class ChainsDto
    {
        [Required]
        [Key]
        public int ChainId { get; set; }

        [Required]
        public string ChainName { get; set; }
    }
}
