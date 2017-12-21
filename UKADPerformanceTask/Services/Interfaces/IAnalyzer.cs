
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IAnalyzer
    {
        List<string> ReturnSiteMap(string url);
    }
}
