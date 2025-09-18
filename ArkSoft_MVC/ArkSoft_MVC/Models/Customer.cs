using System.ComponentModel.DataAnnotations;

namespace ArkSoft_MVC.Models
{
    public class Customer
    {
        [Key]
        public int custID { get; set; } //keeps records unique
        [Required(ErrorMessage = "Please provide a full name and surname")]
        public string custName { get; set; } //stores full name REQUIRED
        [Required(ErrorMessage = "Please provide an address to reference")]
        public string custAddress { get; set; } //REQUIRED
        [Phone]
        public string? custTelephone { get; set; }
        public string? custContactName { get; set; } //contact person's full name
        [EmailAddress(ErrorMessage = "Invalid email address format, please ensure you have '@' and '.'")]
        public string? custContactEmail { get; set; } //contact person's email, if provided: VALID EMAIL ONLY
        public string? vatNumber { get; set; }

        //empty constructor
        public Customer()
        {

        }

        //constructor to create objects
        public Customer(int custID, string custName, string custAddress, string custTelephone, string custContactName, string custContactEmail, string vatNumber)
        {
            this.custID = custID;
            this.custName = custName;
            this.custAddress = custAddress;
            this.custTelephone = custTelephone;
            this.custContactName = custContactName;
            this.custContactEmail = custContactEmail;
            this.vatNumber = vatNumber;
        }
    }
}
