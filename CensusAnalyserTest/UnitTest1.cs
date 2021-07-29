using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateCensusAnalyser;
using System.Collections.Generic;
namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        string stateCensusPath = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusData.csv";
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
    }
}
