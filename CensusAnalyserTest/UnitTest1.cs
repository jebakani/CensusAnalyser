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
        string stateCodePath = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\IndianStateCode.csv";
        string stateCodeInvalidDelimeter= @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\StateCodeWrongDelimeter.csv";
        IndianStateCensusAnalyser.CensusAdapterFactory  csv = null;
        CensusAdapter adapter;
        Dictionary<string, CensusData> totalRecord;
        Dictionary<string, CensusData> stateRecord;

        [TestInitialize]
        public void testSetup()
        {
            csv = new CensusAdapterFactory();
            adapter = new CensusAdapter();
            totalRecord = new Dictionary<string, CensusData>();
            stateRecord = new Dictionary<string, CensusData>();
        }

        //TC.1
        //Giving correct path it should return total count of the census list
        [TestCategory("StateCensusAnalyser")]
        [TestMethod]
        public void GivenStateCensusReturnTotalRecord()
        {
            stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA ,stateCensusPath,"State,Population,AreaInSqKm,DensityPerSqKm");
            int actual= stateRecord.Count;
            int expected = 36;
            //assertion
            Assert.AreEqual(actual, expected);
        }
        //TC 1.2
        //Given the incorrect path return file not exist
        [TestCategory("StateCensusAnalyser")]
        [TestMethod]
        public void GivenIncorrectPath()
        {
            try
            {
                stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA ,wrongPath,"State,Population,AreaInSqKm,DensityPerSqKm");

            } 
            catch(CensusAnalyserException ce)
            {
                Assert.AreEqual("File Not Found", ce.Message);
            }
        }
        //TC 1.3
        //Given the invalid file it returns invalid file type exception
        [TestCategory("StateCensusAnalyser")]
        [TestMethod]
        public void GivenInvalidFile()
        {
            try
            {
                stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA , wrongFileType, "State,Population,AreaInSqKm,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Invalid File Type", ce.Message);
            }
        }
        //TC 1.4
        //Given the file with in valid delimeter
        [TestCategory("StateCensusAnalyser")]
        [TestMethod]
        public void GivenInvalidDelimeter()
        {
            try
            {
                stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA , invalidDelimeter, "State,Population,AreaInSqKm,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("File contains invalid Delimiter", ce.Message);
            }
        }
        //TC 1.5
        //when passing the incorrect header
        [TestCategory("StateCensusAnalyser")]
        [TestMethod]
        public void GivenIncorrectHeader()
        {
            try
            {
                stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA , invalidDelimeter, "Population,AreaInSqKm,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Data header in not matched", ce.Message);
            }
        }
        //TC2.1
        //Giving correct path it should return total count of the census list
        [TestCategory("StateCodeAnalser")]
        [TestMethod]
        public void GivenStateCensusReturnTotalRecordForStateCode()
        {
            stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodePath, "SrNo,State,TIN,StateCode");
            int actual = stateRecord.Count;
            int expected = 37;
            //assertion
            Assert.AreEqual(actual, expected);
        }
        //TC 2.2
        //Given the incorrect path return file not exist
        [TestCategory("StateCode")]
        [TestMethod]
        public void GivenIncorrectPathForStateCode()
        {
            try
            {
                stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongPath, " SrNo, State, TIN, StateCode");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("File Not Found", ce.Message);
            }
        }
        //TC 2.3
        //Given the invalid file it returns invalid file type exception
        [TestCategory("StateCode")]
        [TestMethod]
        public void GivenInvalidFileForUC2()
        {
            try
            {
                stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFileType, " SrNo, State, TIN, StateCode");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Invalid File Type", ce.Message);
            }
        }
        //TC 2.4
        //Given the file with in valid delimeter
        [TestCategory("StateCode")]
        [TestMethod]
        public void GivenInvalidDelimeterforStateCode()
        {
            try
            {
                stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeInvalidDelimeter, "SrNo,State,TIN,StateCode");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("File contains invalid Delimiter", ce.Message);
            }
        }
        //TC 2.5
        //when passing the incorrect header
        [TestCategory("StateCode")]
        [TestMethod]
        public void GivenIncorrectHeaderForStateCode()
        {
            try
            {
                stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodePath, "State,Population,Area,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Data header in not matched", ce.Message);
            }
        }

        [TestCategory("StateCensusAnalyser")]
        [TestMethod]
        public void SampleTest()
        {
            totalRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            int actual = totalRecord.Count;
            int expected = 36;
            //assertion
            Assert.AreEqual(actual, expected);
        }
    }
}
