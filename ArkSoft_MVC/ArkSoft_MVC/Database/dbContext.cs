using ArkSoft_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ArkSoft_MVC.Database
{
    public class dbContext : DbContext
    {
        public readonly IWebHostEnvironment _environment;

        public dbContext(DbContextOptions<dbContext> options, IWebHostEnvironment environment): base(options)
        {
            _environment = environment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=AMBER-LAPTOP\\SQLEXPRESS;initial catalog=ArkSoft_DevTest;trusted_connection=true");

        public DbSet<Customer> Customer { get; set; } //creates a link to customer table in sql db

        //METHOD THAT WILL UPLOAD CUSTOMER OBJECTS TO DB
        public async Task<bool> CreateCustomer(Customer newCust)
        {
            return false; //placeholder for now
        }
    }
}
