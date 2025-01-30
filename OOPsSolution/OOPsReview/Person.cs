using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;
        public string FirstName 
        {
            get { return _FirstName; } 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("First Name", "First Name is required. Cannot be missing");
                _FirstName = value.Trim(); 
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Last Name", "Last Name is required. Cannot be missing");
                _LastName = value.Trim(); 
            }
        }
        public ResidentAddress Address { get; set; } //record is an object, default value is null
        public List<Employment> EmploymentPositions { get; set; } //List<T> is an object, default value is null

        public string FullName { get { return LastName + ", " + FirstName; } }

        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            EmploymentPositions = new List<Employment>(); //the list will be empty but at least it exists
        }

        public Person(string firstname, string lastname, ResidentAddress address,
                        List<Employment> employments)
        {
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
    
        public void AddEmployment(Employment employment)
        {
            if (employment == null)
                throw new ArgumentNullException("Adding Employment", "Employment required, missing employment data. Unable to add employment history. ");

            //do not care to actually receive a copy of the found instance
            //all this cares for, is there an instance that matches the condition(s)? (looking for a true or false)
            if (EmploymentPositions.Any(e => e.Title.Equals(employment.Title)
                                          && e.StartDate == employment.StartDate))
                throw new ArgumentException("Employment", 
                                $"Duplicate employment. Employment record with position {employment.Title} on {employment.StartDate}");
            EmploymentPositions.Add(employment);
        }

        public void ChangeFullName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
