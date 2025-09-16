using System.ComponentModel.DataAnnotations;

namespace ArkSoft_MVC.Models
{
    public class Customer
    {
        [Key]
        public int custID { get; set; } //keeps records unique
        public string custName { get; set; } //stores full name
        public string custAddress { get; set; }
        public string custTelephone { get; set; }
        public string custContactName { get; set; } //contact person's full name
        public string custContactEmail { get; set; } //contact person's email VALID EMAIL ONLY
        public int vatNumber { get; set; }

        //empty constructor
        public Customer()
        {

        }

        //constructor to create objects
        public Customer(int custID, string custName, string custAddress, string custTelephone, string custContactName, string custContactEmail, int vatNumber)
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
