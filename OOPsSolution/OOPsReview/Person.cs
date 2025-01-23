using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ResidentAddress Address { get; set; } //record is an object, default value is null
        public List<Employment> EmploymentPositions { get; set; } //List<T> is an object, default value is null

        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            EmploymentPositions = new List<Employment>(); //the list will be empty but at least it exists
        }

        public Person(string firstname, string lastname, ResidentAddress address,
                        List<Employment> employments)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentNullException("First Name", "First name is required, cannot be empty.");
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentNullException("Last Name", "Last name is required, cannot be empty.");
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if (employments == null)
            {
                EmploymentPositions = new List<Employment>();
            }
            else
            {
                EmploymentPositions = employments;
            }
        }
    }
}
