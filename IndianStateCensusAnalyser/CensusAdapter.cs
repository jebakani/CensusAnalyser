using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
   public class CensusAdapter
    {
        public string[] GetCensusData(string csvFilePath,string dataHeader)
        {
            string[] censusData;
            //checks for file existence
            if(!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            //checks for file extention
            if(Path.GetExtension(csvFilePath)!=".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            //read all the data in lines using string array
            censusData = File.ReadAllLines(csvFilePath);
            //check for correct header
            if(censusData[0] != dataHeader)
            {
                throw new CensusAnalyserException("Data header in not matched", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            //return the array
            return censusData;
        }
    }
}
