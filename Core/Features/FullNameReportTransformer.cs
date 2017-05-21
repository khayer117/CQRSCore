using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Features
{
    public class FullNameReportTransformer : IReportTransformer
    {
        public IEnumerable<Dictionary<string, object>> Transform()
        {
            throw new NotImplementedException();
        }
    }
}
