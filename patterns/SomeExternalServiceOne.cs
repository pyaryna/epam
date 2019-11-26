using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    class SomeExternalServiceOne : ISomeExternalService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;
        public SomeExternalServiceOne(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }
        public string PrintSomething()
        {
            return _randomGuidProvider.RandomGuid.ToString();
        }
    }
}
