using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class ClaimContent
    {

        public ClaimContent(ClaimType claimtype, int claimID, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = (dateOfClaim - dateOfIncident).Days <= 30;

        }

        public ClaimContent ()
        {

        }

        public ClaimType ClaimType { get; set; }
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        
    }

}
