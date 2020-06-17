using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }


        public int? id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public string Title
        {
            get
            {
                return id != 0 ? "Edit Customer" : "New Customer";
            }
        }
        public CustomerFormViewModel()
        {
            id = 0;
        }

        public CustomerFormViewModel(Customer Customer)
        {
            id = Customer.id;
            Name = Customer.Name;
            BirthDate = Customer.BirthDate;
            IsSubscribedToNewsletter = Customer.IsSubscribedToNewsletter;
            MembershipTypeId = Customer.MembershipTypeId;
        }


    }
}