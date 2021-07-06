using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge02
{
    public class ClaimRepository
    {
        //Queue
        protected readonly Queue<Claims> _queueOfClaims = new Queue<Claims>();

        //CRUD
        //CREATE
        public bool AddClaimToQueue(Claims claim)
        {
            int startingCount = _queueOfClaims.Count;
            _queueOfClaims.Enqueue(claim);
            bool wasAdded = (_queueOfClaims.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ
        public Queue<Claims> GetClaimQueue()
        {
            return _queueOfClaims; 
        }
        public Claims GetClaimByID(int claimID)
        {
            foreach (Claims claim in _queueOfClaims)
            {
                if (claim.ClaimID.ToString() == claimID.ToString())
                {
                    return claim;
                }
            }
            return null;
        }
        public Claims GetNextClaim()
        {
            return _queueOfClaims.Peek();
        }
        //UPDATE

        //DELETE
    }
}
