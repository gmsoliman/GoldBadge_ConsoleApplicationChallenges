using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsClassLibrary
{
    public class ClaimsRepo
    {
        protected readonly Queue<Claims> _claims = new Queue<Claims>();
        //CREATE
        public bool AddClaimToQueue(Claims newClaim)
        {
            int startingCount = _claims.Count;
            _claims.Enqueue(newClaim);
            bool wasAdded = (_claims.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ (all claims)
        public Queue<Claims> GetAllClaims()
        {
            return _claims;
        }

        //READ (next claim)
        public Claims GetNextClaim()
        {
            var nextClaim = _claims.Peek();
            return nextClaim;
        }

        //READ (any claim)
        public Claims GetClaimById(int claimId)
        {
            foreach (Claims claim in _claims)
            {
                if (claim.ClaimID == claimId)
                {
                    return claim;
                }
            }
            return null;
        }

        //UPDATE
        public bool ChangeClaim(int claimToBeChanged, Claims updatedClaim)
        {
            Claims oldClaim = GetClaimById(claimToBeChanged);
            if (oldClaim != null)
            {
                oldClaim.ClaimID = updatedClaim.ClaimID;
                oldClaim.ClaimType = updatedClaim.ClaimType;
                oldClaim.Description = updatedClaim.Description;
                oldClaim.ClaimAmount = updatedClaim.ClaimAmount;
                oldClaim.DateOfIncident = updatedClaim.DateOfIncident;
                oldClaim.DateOfClaim = updatedClaim.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool DeleteClaimFromQueue()
        {
            int startingCount = _claims.Count;
            _claims.Dequeue();
            bool wasDeleted = (_claims.Count < startingCount) ? true : false;
            return wasDeleted;
        }
    }
}
