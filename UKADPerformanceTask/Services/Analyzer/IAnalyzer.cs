
using System.Collections.Generic;

namespace Services.Analyzer
{
    public interface IAnalyzer
    {
        List<string> ReturnSiteMap(string url);
    }
}
