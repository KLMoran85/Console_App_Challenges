using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public class ClaimContentRepository
    {
        public Queue<ClaimContent> _queueOfClaimContent = new Queue<ClaimContent>();

        public Queue<ClaimContent> GetClaimContentQueue()
        {
            return _queueOfClaimContent;
        }

        public void AddContentToQueue(ClaimContent content)
        {
            _queueOfClaimContent.Enqueue(content);
        }

        public ClaimContent TakeCareOfNextClaim()
        {
            return _queueOfClaimContent.Peek();

        }

        public void RemoveNextClaim()
        {
            _queueOfClaimContent.Dequeue();
        }
        public void SeedList()
        {
            ClaimContent claim = new ClaimContent(ClaimType.Car, 1, "Car Wreck on I65N", 5000m, DateTime.Parse("2019, 04, 15"), DateTime.Parse("2019, 04, 17"));
            ClaimContent claimTwo = new ClaimContent(ClaimType.Home, 2, "Home Invasion", 1000m, DateTime.Parse("2019, 05, 10"), DateTime.Parse("2019, 05, 11"));
            ClaimContent claimThree = new ClaimContent(ClaimType.Theft, 3, "Porch Pirate stolen Amazon package", 50m, DateTime.Parse("2019, 06, 11"), DateTime.Parse("2019, 06, 13"));

            AddContentToQueue(claim);
            AddContentToQueue(claimTwo);
            AddContentToQueue(claimThree);
        }
    }
}
