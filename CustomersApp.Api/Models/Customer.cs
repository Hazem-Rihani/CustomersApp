using MongoDB.Bson;
using System;

namespace CustomersApp.Api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }

        public string Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName)) return "First Name is required";
            if (string.IsNullOrWhiteSpace(LastName)) return "Last Name is required";
            return string.Empty;
        }

    }
}
