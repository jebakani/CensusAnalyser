using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    class CensusAdapterFactory
    {
        public Dictionary<string,CensusData> LoadCsvData(CensusAnalyser.Country country,string csvFilePath,string dataHeader)
        {
            switch(country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().
            }
        }
    }
}
