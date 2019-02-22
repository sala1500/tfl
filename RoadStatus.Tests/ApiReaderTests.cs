using System.Collections.Generic;
using NUnit.Framework;
using RoadStatus.Code.Concretes;
using RoadStatus.Code.Contracts;
using RoadStatus.Code.Dtos;

namespace RoadStatus.Tests
{
    //Pact Net would probably be useful in mocking these responses.
    public class ApiReaderTests
    {
        private ApiReader reader;
        private string validApiPath = "https://api.tfl.gov.uk/road/A2";
        private string inValidApiPath = "https://api.tfl.gov.uk/road/A23232";

        [SetUp]
        public void Setup()
        {
            reader = new ApiReader();
        }

        [Test]
        public void Get_200Recieved_ListOfRoadCorridorIsReturned()
        {
            var result = reader.Get<RoadCorridor>(validApiPath);
            Assert.AreEqual(true, result is IEnumerable<RoadCorridor>);
        }

        [Test]
        public void Get_404Received_KeyNotFoundExceptionIsThrown()
        {
            Assert.Throws<KeyNotFoundException>(() =>
            {
                reader.Get<RoadCorridor>(inValidApiPath);
            });
        }
    }
}