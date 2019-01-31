using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using XBase.API.FAO.Services.FAO;
using Xunit;

namespace XBase.API.FAO.Test
{
	public class FAOTest
	{
		[Fact]
		public void RCTMustBeInAtlantic()
		{
			Point agadirWaters = new Point(ServiceFAO.GetLongitude("O", "9", "47", "25.83"), ServiceFAO.GetLatitude("N", "30", "27", "18.85"))
			{
				SRID = 4326
			};
			
			string d = ServiceFAO.GetFaoDistribution(agadirWaters, "RCT", FAODistributionField.PRESENCE);
			Assert.Equal("1", d);
		}

		[Fact]
		public void RCTMustNotBeInBrazil()
		{
			Point staCatarinaWaters = new Point(ServiceFAO.GetLongitude("O", "46", "00", "00.00"), ServiceFAO.GetLatitude("S", "25", "39", "00.00"))
			{
				SRID = 4326
			};
			string d = ServiceFAO.GetFaoDistribution(staCatarinaWaters, "RCT", FAODistributionField.PRESENCE);
			Assert.Null(d);			
		}

		[Fact]
		public void RCTFaos()
		{
			Point agadirWaters = new Point(ServiceFAO.GetLongitude("O", "9", "47", "25.83"), ServiceFAO.GetLatitude("N", "30", "27", "18.85"))
			{
				SRID = 4326
			};

			List<string> faoAreas = ServiceFAO.GetFaoAreaDistribution("RCT");//Rhinochimaera atlantica (Holt & Byrne, 1909)
			var faosRCT = new[] { "47","51","27","34","21","31","41"};
			Assert.All(faoAreas, x => Assert.Contains(x, faosRCT));
			Assert.All(faosRCT, x => Assert.Contains(x, faoAreas));
		}

		[Fact]
		public void RCTFaoLevelMajorCode()
		{
			Point agadirWaters = new Point(ServiceFAO.GetLongitude("O", "9", "47", "25.83"), ServiceFAO.GetLatitude("N", "30", "27", "18.85"))
			{
				SRID = 4326
			};
			string faoMajor = ServiceFAO.GetFaoAreaFromCoordinates(agadirWaters, FAOLevel.MAJOR, FAOField.CODE);
			Assert.Equal("34", faoMajor);
		}
	}
}
