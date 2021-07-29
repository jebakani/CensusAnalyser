using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateCensusAnalyser;
using System.Collections.Generic;
namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        string stateCensusPath = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusData.csv";
        string wrongPath = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\IndianStateCensus.csv";
        string wrongFileType = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\TextFile1.txt";
        string invalidDelimeter = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\WorngDelimeter.csv";
        IndianStateCensusAnalyser.CensusAdapterFactory  csv = null;
        CensusAdapter adapter;
        Dictionary<string, CensusDataDAO> totalRecord;
        string[] stateRecord;

        [TestInitialize]
        public void testSetup()
        {
            csv = new CensusAdapterFactory();
            adapter = new CensusAdapter();
            totalRecord = new Dictionary<string, CensusDataDAO>();
        }

        //TC1.1
        //Giving correct path it should return total count of the census list
        [TestMethod]
        public void GivenStateCensusReturnTotalRecord()
        {
            stateRecord = adapter.GetCensusData(stateCensusPath,"State,Population,AreaInSqKm,DensityPerSqKm");
            int actual= stateRecord.Length-1;
            int expected = 36;
            //assertion
            Assert.AreEqual(actual, expected);
        }
        //TC 1.2
        //Given the incorrect path return file not exist
        [TestMethod]
        public void GivenIncorrectPath()
        {
            try
            {
                var stateRecor= adapter.GetCensusData(wrongPath, "State,Population,AreaInSqKm,DensityPerSqKm");

            } 
            catch(CensusAnalyserException ce)
            {
                Assert.AreEqual("File Not Found", ce.Message);
            }
        }
        //TC 1.3
        //Given the invalid file it returns invalid file type exception
        [TestMethod]
        public void GivenInvalidFile()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(wrongFileType, "State,Population,AreaInSqKm,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Invalid File Type", ce.Message);
            }
        }
        //TC 1.4
        //Given the file with in valid delimeter
        [TestMethod]
        public void GivenInvalidDelimeter()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(invalidDelimeter, "State,Population,AreaInSqKm,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("File contains invalid Delimiter", ce.Message);
            }
        }
        //TC 1.5
        //when passing the incorrect header
        [TestMethod]
        public void GivenIncorrectHeader()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(invalidDelimeter, "State,Population,Area,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Data header in not matched", ce.Message);
            }
        }
    }
}
