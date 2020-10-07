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
