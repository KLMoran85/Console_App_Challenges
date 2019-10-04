using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Repository
{
    public class OutingContentRepository
    {
       
        private List<OutingContent> _listofOutingContent = new List<OutingContent>();

        public void AddOutingContentToList(OutingContent content)
        {
            _listofOutingContent.Add(content);
            
        }

        public List<OutingContent> GetOutingContentList()
        {
            return _listofOutingContent;
        }

        public decimal GetOutingCostByType(OutingType outingType)
        {
            decimal cost = 0;
            foreach (OutingContent content in _listofOutingContent)
            {
                if (content.OutingType == outingType)
                {
                    cost = cost + content.TotalCostOfOutings;
                }
            }
            return cost;

        }

        public decimal GetTotalOutingsCost()
        {
            decimal cost = _listofOutingContent.Sum(outing => outing.TotalCostOfOutings);

            return cost;
        }

        public void SeedList()
        {
            OutingContent outing = new OutingContent(65, DateTime.Parse("2019/06/15"), OutingType.Golf, 75m, 4875m);
            OutingContent outingTwo = new OutingContent(45, DateTime.Parse("2019/04/22"), OutingType.Bowling, 40m, 200m);
            OutingContent outingThree = new OutingContent(40, DateTime.Parse("2019/07/25"), OutingType.AmusementPark, 50m, 200m);

            AddOutingContentToList(outing);
            AddOutingContentToList(outingTwo);
            AddOutingContentToList(outingThree);

        }

    }
}
