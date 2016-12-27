﻿using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.Radar.Request;
using GoogleApi.Entities.Places.Search.Text.Request;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GooglePlacesTest : BaseTest
    {
        [Test]
        public void PlacesAutoCompleteTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                Key = this._apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.Query(_request);
            var _results = _response.Predictions.ToArray();

            Assert.AreEqual(_results[0].Description, "Jagtvej, 2200 Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej, 2200 Copenhagen, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(5, _results.Length);
        }
        [Test]
        public void PlacesAutoCompleteAsyncTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                Key = this._apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.QueryAsync(_request).Result;
            var _results = _response.Predictions.ToArray();

            Assert.AreEqual(_results[0].Description, "Jagtvej, 2200 Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej, 2200 Copenhagen, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(5, _results.Length);
        }

        [Test]
        public void PlacesQueryAutoCompleteTest()
        {
            var _request = new PlacesQueryAutoCompleteRequest
            {
                Key = this._apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };
            var _response = GooglePlaces.QueryAutoComplete.Query(_request);
            var _results = _response.Predictions.ToArray();

            Assert.AreEqual(_results[0].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Næstved, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Fredensborg, Denmark");
            Assert.AreEqual(5, _results.Length);
        }
        [Test]
        public void PlacesQueryAutoCompleteAsyncTest()
        {
            var _request = new PlacesQueryAutoCompleteRequest
            {
                Key = this._apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };
            var _response = GooglePlaces.QueryAutoComplete.QueryAsync(_request).Result;
            var _results = _response.Predictions.ToArray();

            Assert.AreEqual(_results[0].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Næstved, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Fredensborg, Denmark");
            Assert.AreEqual(5, _results.Length);
        }

        [Test]
        public void PlacesAddTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void PlacesAddAsyncTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesDeleteTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void PlacesDeleteAsyncTest()
        {
            Assert.Inconclusive();
        }
        
        [Test]
        public void PlacesDetailsTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                Key = _apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.Query(_request);
            var _results = _response.Predictions.ToArray();
            var _result = _results.First();
            
            var _request2 = new PlacesDetailsRequest
            {
                Key = _apiKey,
                PlaceId = _result.PlaceId,
                Sensor = true,
            };

            var _response2 = GooglePlaces.Details.Query(_request2);
            Assert.AreEqual(Status.OK, _response2.Status);
        }
        [Test]
        public void PlacesDetailsAsyncTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                Key = _apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.QueryAsync(_request).Result;
            var _results = _response.Predictions.ToArray();
            var _result = _results.First();

            var _request2 = new PlacesDetailsRequest
            {
                Key = _apiKey,
                PlaceId = _result.PlaceId,
                Sensor = true,
            };

            var _response2 = GooglePlaces.Details.Query(_request2);
            Assert.AreEqual(Status.OK, _response2.Status);
        }

        [Test]
        public void PlacesNearBySearchTest()
        {
            var _request = new PlacesNearBySearchRequest
            {
                Key = this._apiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] { SearchPlaceType.SCHOOL, SearchPlaceType.POLICE }
            };

            var _response = GooglePlaces.NearBySearch.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }
        [Test]
        public void PlacesNearBySearchAsyncTest()
        {
            var _request = new PlacesNearBySearchRequest
            {
                Key = this._apiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] { SearchPlaceType.SCHOOL, SearchPlaceType.POLICE }
            };

            var _response = GooglePlaces.NearBySearch.QueryAsync(_request).Result;

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }
        
        [Test]
        public void PlacesTextSearchTest()
        {
            var _request = new PlacesTextSearchRequest
            {
                Key = this._apiKey,
                Sensor = true,
                Language = "en",
                Query = "picadelly circus"
            };

            var _response = GooglePlaces.TextSearch.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }
        [Test]
        public void PlacesTextSearchAsyncTest()
        {
            var _request = new PlacesTextSearchRequest
            {
                Key = this._apiKey,
                Sensor = true,
                Language = "en",
                Query = "picadelly circus"
            };

            var _response = GooglePlaces.TextSearch.QueryAsync(_request).Result;

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }

        [Test]
        public void PlacesRadarSearchTest()
        {
            var _request = new PlacesRadarSearchRequest
            {
                Key = this._apiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Sensor = true,
                Language = "en",
                Keyword = "abc"
            };

            var _response = GooglePlaces.RadarSearch.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }
        [Test]
        public void PlacesRadarSearchAsyncTest()
        {
            var _request = new PlacesRadarSearchRequest
            {
                Key = this._apiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Sensor = true,
                Language = "en",
                Keyword = "abc"
            };

            var _response = GooglePlaces.RadarSearch.QueryAsync(_request).Result;

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }

        [Test]
        public void PlacesPhotosTest()
        {
            Assert.Inconclusive();

            //var _request = new PlacesAutoCompleteRequest
            //{
            //    Key = _apiKey,
            //    Input = "det kongelige teater",
            //    Sensor = true,
            //    Language = "en",
            //};

            //var _response = GooglePlaces.AutoComplete.Query(_request);
            //var _results = _response.Predictions.ToList();
            //var _result = _results.First();

            //var _request2 = new PlacesDetailsRequest
            //{
            //    Key = _apiKey,
            //    PlaceId = _result.PlaceId,
            //    Sensor = true,
            //};

            //var _response2 = GooglePlaces.Details.Query(_request2);
            //Assert.AreEqual(Status.OK, _response2.Status);

            //var _photo = _response2.Result.Photos.FirstOrDefault();
            //Assert.IsNotNull(_photo);

            //var _request3 = new PlacesPhotosRequest
            //{
            //    Key = _apiKey,
            //    Sensor = true,
            //    PhotoReference = _photo.PhotoReference,
            //    MaxWidth = 1600
            //};

            //var _response3 = GooglePlaces.Photos.Query(_request3);

            //Assert.IsNotNull(_response3);
            //Assert.IsNotNull(_response3.Photo);
            //Assert.AreEqual(Status.OK, _response3.Status);
        }
        [Test]
        public void PlacesPhotosAsyncTest()
        {
            Assert.Inconclusive();
        }
    }
}