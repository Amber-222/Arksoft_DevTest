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
        => optionsBuilder.UseSqlServer("data source=AMBER-LAPTOP\\SQLEXPRESS;initial catalog=ArkSoft_DevTest;TrustServerCertificate=true;trusted_connection=true");

        public DbSet<Customer> Customer { get; set; } //creates a link to customer table in sql db

        //METHOD THAT WILL UPLOAD CUSTOMER OBJECTS TO DB
        public async Task<bool> CreateCustomer(Customer newCust)
        {
            if (newCust != null)
            {
                await Customer.AddAsync(newCust); //add to db
                int result = await SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }
            }
            return false; //if anything goes wrong, return false
        }

        //METHDO TO UPDATE DETAILS IN DB
        public async Task<bool> Update(Customer cust)
        {
            var updatedCustomer = await Customer.FindAsync(cust.custID); //look for the customer to update in db

            if (updatedCustomer != null)
            {
                //update all current details to any new details passed in
                updatedCustomer.custName = cust.custName;
                updatedCustomer.custAddress = cust.custAddress;
                updatedCustomer.vatNumber = cust.vatNumber;
                updatedCustomer.custTelephone = cust.custTelephone;
                updatedCustomer.custContactEmail = cust.custContactEmail;
                updatedCustomer.custContactName = cust.custContactName;
                Entry(updatedCustomer).State = EntityState.Modified; //tag that the record is updated
                int result = await SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }
            }
            
            return false;
        }

        //METHDO TO REMOVE RECORD FROM DB
        public async Task<bool> Delete(int custID)
        {
            var cust = await Customer.FindAsync(custID); //find customer to delete

            if (cust != null)
            {
                Customer.Remove(cust);
                int result = await SaveChangesAsync();

                if (result > 0) //if deleted
                {
                    return true;
                }
            }

            return false;
        }
    }
}
