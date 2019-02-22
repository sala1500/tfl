using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RoadStatus.Code.Concretes;
using RoadStatus.Code.Contracts;
using RoadStatus.Code.Dtos;

namespace RoadStatus.Tests
{
    public class RoadServiceTests
    {
        private Mock<IApiReader> mockApiReader;
        private Mock<IConfigReader> mockConfigReader;
        private RoadService service;
        private const string AppId = "4a0deb66";
        private const string AppKey = "69d009fdac45c18b1f4cf302eabc3e62";
        private const string ApiPath = "https://api.tfl.gov.uk/road";

        [SetUp]
        public void Setup()
        {
            mockApiReader = new Mock<IApiReader>();
            mockConfigReader = new Mock<IConfigReader>();
            mockConfigReader.Setup(m => m.GetApiPath()).Returns(ApiPath);
            mockConfigReader.Setup(m => m.GetAppId()).Returns(AppId);
            mockConfigReader.Setup(m => m.GetAppKey()).Returns(AppKey);

            service = new RoadService(mockConfigReader.Object, mockApiReader.Object);
        }

        [Test]
        public void GetRoadStatus_ValidRoad_ApiReaderIsCalledWithCorrectPath()
        {
            //GIVEN we have a valid road
            var road = "A2";
            mockApiReader.SetupAllProperties();
            
            //WHEN we call GetRoadStatus
            service.GetRoadStatus(road);

            var expectedPath = $"{ApiPath}/{road}?app_id={AppId}&app_key={AppKey}";

            //THEN I expect the ApiReader to have been called with the correct Path
            mockApiReader.Verify(m => m.Get<RoadCorridor>(expectedPath), Times.Once());
        }

        [Test]
        public void GetRoadStatus_NullRoad_ApiReaderIsCalledWithBasePath()
        {
            //GIVEN we have a null road
            string road = null;
            mockApiReader.SetupAllProperties();
            
            //WHEN we call GetRoadStatus
            service.GetRoadStatus(road);

            var expectedPath = $"{ApiPath}?app_id={AppId}&app_key={AppKey}";

            //THEN I expect the ApiReader to have been called with the correct Path
            mockApiReader.Verify(m => m.Get<RoadCorridor>(expectedPath), Times.Once());
        }

        [Test]
        public void GetRoadStatus_InValidRoad_HandleAndRethrowKeyNotException()
        {
            //GIVEN we have an Invalid road
            string road = "A23242323";
            mockApiReader.Setup(m => m.Get<RoadCorridor>(It.IsAny<string>())).Throws(new KeyNotFoundException());
            
            //WHEN we call GetRoadStatus
            var exception = Assert.Throws<KeyNotFoundException>(() =>
            {
                //THEN we expect it to throw a KeyNotFoundException
                service.GetRoadStatus(road);
            });

            var expectedMessage = $"{road} is not a valid road";

            //AND we also expect the correct error message
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}