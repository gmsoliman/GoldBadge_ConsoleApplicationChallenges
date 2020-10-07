using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsClassLibrary
{
    public enum TypeOfClaim { Car, Home, Theft }
    public class Claims
    {
        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan validWindow = DateOfClaim - DateOfIncident;
                if (validWindow.TotalDays <= 30 && validWindow.TotalDays >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Claims() { }
        public Claims(int claimId, TypeOfClaim claimType, string description, double claimAmount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
        }
    }
}
