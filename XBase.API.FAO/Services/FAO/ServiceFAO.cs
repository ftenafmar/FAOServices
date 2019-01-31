using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.IO.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace XBase.API.FAO.Services.FAO
{
	public class ServiceFAO
	{
		/// <summary>
		/// Transforms a Latitude to double
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="latitudeGrades"></param>
		/// <param name="latitudeMinutes"></param>
		/// <param name="latitudeSeconds"></param>
		/// <returns></returns>
		public static double GetLatitude(string latitude, string latitudeGrades, string latitudeMinutes, string latitudeSeconds)
		{
			var multiplier = latitude.Equals("N") ? 1 : -1; //Norte-North
			var degrees = Convert.ToDouble(latitudeGrades);
			var minutes = Convert.ToDouble(latitudeMinutes) / 60;
			var seconds = Convert.ToDouble(latitudeSeconds) / 3600;

			return (degrees + minutes + seconds) * multiplier;
		}

		/// <summary>
		/// Transforms a Longitude to double
		/// </summary>
		/// <param name="longitude"></param>
		/// <param name="longitudeGrades"></param>
		/// <param name="longitudeMinutes"></param>
		/// <param name="longitudeSeconds"></param>
		/// <returns></returns>
		public static double GetLongitude(string longitude, string longitudeGrades, string longitudeMinutes, string longitudeSeconds)
		{
			var multiplier = longitude.Equals("E") ? 1 : -1; //Este-East
			var degrees = Convert.ToDouble(longitudeGrades);
			var minutes = Convert.ToDouble(longitudeMinutes) / 60;
			var seconds = Convert.ToDouble(longitudeSeconds) / 3600;
			return (degrees + minutes + seconds) * multiplier;
		}

		/// <summary>
		/// Returns a list of FAO-3 ASFIS species code that has information about its distribution available
		/// </summary>
		/// <returns></returns>
		public static List<string> GetFAOCodesDistributionAvailable()
		{
			return new List<string>()
			{
				"FBM",
"BSZ",
"AKS",
"APB",
"AAY",
"AAD",
"AAF",
"APG",
"AAM",
"AAK",
"AAA",
"AAN",
"AAO",
"APR",
"AAH",
"AAI",
"APE",
"APU",
"APN",
"KUE",
"YVV",
"KUY",
"KUQ",
"YGP",
"YGS",
"ACN",
"TWP",
"OUK",
"OUM",
"OUL",
"LHQ",
"PTH",
"BTH",
"ALV",
"PAS",
"BLC",
"CAA",
"CAS",
"NKL",
"NHL",
"ELE",
"SAB",
"RPA",
"BSF",
"CUJ",
"TKV",
"CSN",
"CSZ",
"APQ",
"APA",
"APX",
"APW",
"APP",
"APC",
"SEK",
"GGQ",
"ARA",
"JPN",
"ARF",
"KZA",
"MSC",
"JPO",
"OJA",
"OJG",
"OJB",
"BLT",
"FRI",
"ZBL",
"YYA",
"BZB",
"BYG",
"BZM",
"BYE",
"BYP",
"BYQ",
"BYZ",
"RJQ",
"BJS",
"YHA",
"YTH",
"YTT",
"KUW",
"JLZ",
"KUH",
"JTQ",
"BDV",
"BOG",
"POC",
"OBW",
"BQP",
"BQR",
"GRB",
"MHG",
"MHA",
"USK",
"BRD",
"WBM",
"WHE",
"CRB",
"DUN",
"CRE",
"CCN",
"CCA",
"CCB",
"FAL",
"CCO",
"CCE",
"CCL",
"OCS",
"DUS",
"CCP",
"CCS",
"CCT",
"WSH",
"TTL",
"LAW",
"CEA",
"GVA",
"GUP",
"CEU",
"GVI",
"CPL",
"CEM",
"CEK",
"GUQ",
"CEE",
"CFB",
"CYG",
"CYK",
"CYN",
"CYT",
"CYR",
"CYO",
"CYP",
"CYW",
"COC",
"VEP",
"BSK",
"SVE",
"FSS",
"HVM",
"TUG",
"ORA",
"KYL",
"ORR",
"YYL",
"ORI",
"ORH",
"ORB",
"CMO",
"DDR",
"CRQ",
"DOB",
"KTV",
"HWR",
"HXC",
"CHZ",
"CHF",
"OPC",
"OPF",
"OPJ",
"KTI",
"CLN",
"CLZ",
"HER",
"HEP",
"CLA",
"SAP",
"COE",
"ELS",
"COL",
"WHL",
"DOL",
"RNG",
"CSH",
"OYG",
"OYA",
"CPE",
"YXS",
"KHG",
"KHE",
"LUM",
"WKS",
"FCP",
"SEZ",
"SCK",
"RDC",
"JDP",
"DCA",
"SDH",
"SDU",
"SDQ",
"RSA",
"RUS",
"DEA",
"DEN",
"DNC",
"DEC",
"DEP",
"DEL",
"DEM",
"DKK",
"BSS",
"SWA",
"TOP",
"GIS",
"RAS",
"SHB",
"ECK",
"ZEI",
"RRU",
"EOI",
"EDY",
"EDT",
"SAF",
"QRQ",
"FOT",
"EHT",
"ANA",
"ANC",
"ANE",
"JAN",
"NPA",
"VET",
"EZM",
"IJX",
"IJY",
"IJZ",
"IKD",
"IKE",
"IKF",
"LAO",
"GPW",
"EPK",
"MYB",
"MWC",
"MYU",
"TTH",
"PEA",
"FPI",
"BOA",
"ETB",
"ETH",
"ETU",
"ETE",
"ETO",
"ETI",
"ETM",
"ETN",
"ETF",
"ETL",
"ETT",
"ETR",
"ETP",
"ETZ",
"ETQ",
"ETX",
"ETK",
"ETJ",
"ETV",
"ETW",
"RRH",
"WRR",
"ORE",
"ICJ",
"IKJ",
"LAF",
"IKL",
"KRI",
"EUZ",
"EUP",
"EMY",
"EYQ",
"EYZ",
"KAW",
"LTA",
"FIH",
"QRR",
"QRS",
"QRT",
"QRU",
"QRW",
"PCO",
"COD",
"GRC",
"TIG",
"GAL",
"GAG",
"GHA",
"SHO",
"GAM",
"GAQ",
"GTH",
"CUS",
"KCP",
"CUC",
"CUB",
"GVT",
"LAE",
"ORX",
"GNC",
"WIT",
"GTE",
"GTK",
"GTI",
"GTD",
"GTJ",
"GTP",
"RGL",
"BUC",
"HCH",
"HCR",
"FGO",
"ORF",
"ORK",
"ORN",
"ORQ",
"ORW",
"HXT",
"CHS",
"HEF",
"HEG",
"HEJ",
"HEM",
"HEK",
"HEQ",
"HEA",
"HEZ",
"OBH",
"HYY",
"HHP",
"HZS",
"HZW",
"SBL",
"HXN",
"HHB",
"HIX",
"FTS",
"PLA",
"HAP",
"HQB",
"HQS",
"HOP",
"HOR",
"JCE",
"HFA",
"JCH",
"HHW",
"HFE",
"JCI",
"JCJ",
"HFF",
"HOZ",
"JCK",
"HFI",
"JCL",
"JCO",
"HFQ",
"JCQ",
"HFN",
"JCW",
"JDB",
"JDD",
"HFC",
"JDE",
"JDG",
"LBA",
"LBE",
"ORY",
"HQI",
"CYA",
"CYH",
"CYZ",
"SVC",
"TIO",
"IDE",
"IDG",
"IDH",
"IDI",
"IDJ",
"LAY",
"ILI",
"EIL",
"SQA",
"SQM",
"SQI",
"IXO",
"ISB",
"ISP",
"HIZ",
"JCF",
"SFA",
"SMA",
"LMA",
"SKJ",
"DOD",
"LNJ",
"LMD",
"POR",
"IDK",
"IDL",
"LAR",
"IKQ",
"IKR",
"IDN",
"IDO",
"LYC",
"CRY",
"GIP",
"NIP",
"YUV",
"LKY",
"LKV",
"ROS",
"SFS",
"MEG",
"LPW",
"DGQ",
"OYD",
"IKT",
"IKU",
"LSZ",
"IDQ",
"IDT",
"IDU",
"IDV",
"ZLP",
"YES",
"DAB",
"ICR",
"OJH",
"OJD",
"OJE",
"SQF",
"SQP",
"SQL",
"CHO",
"SQR",
"IUB",
"OKD",
"IUJ",
"ANG",
"MON",
"MVO",
"FBU",
"RES",
"SNC",
"LYG",
"LYB",
"KXP",
"PRF",
"RHG",
"MRC",
"GRN",
"BUM",
"JFT",
"RJS",
"RJP",
"CAP",
"RMA",
"RMB",
"SQS",
"LMP",
"HAS",
"ZMK",
"HAD",
"CLH",
"WHG",
"HOF",
"MRG",
"HKN",
"HKS",
"HKK",
"PHA",
"HKP",
"HKE",
"HKO",
"HKB",
"NHA",
"HKM",
"EKH",
"IAZ",
"IAJ",
"POS",
"WHB",
"CKM",
"LEM",
"LMO",
"RME",
"RMH",
"RMJ",
"RMK",
"RMM",
"RMU",
"RMN",
"RMT",
"RMO",
"BLI",
"LIN",
"ICE",
"LAK",
"ICF",
"MUF",
"MUT",
"MUR",
"DPC",
"SDS",
"CTI",
"SMD",
"MYL",
"MUS",
"MSM",
"MYG",
"FBT",
"NUX",
"NUK",
"ORZ",
"NGB",
"MYE",
"THG",
"CNN",
"BVC",
"RNS",
"NEK",
"NEP",
"NTC",
"NDG",
"NDH",
"TSQ",
"OKS",
"OUJ",
"OTQ",
"OTY",
"OCQ",
"OFY",
"OQY",
"QDM",
"OQI",
"OCW",
"OQN",
"OKH",
"OKE",
"OCC",
"YHT",
"LOO",
"ODH",
"OFJ",
"PIN",
"CHU",
"COH",
"SOC",
"CHI",
"YHB",
"YHJ",
"UHY",
"OIJ",
"UHK",
"UHR",
"UHB",
"OVK",
"THP",
"ORJ",
"ORT",
"ORO",
"ORV",
"TLM",
"OKA",
"OKL",
"OXB",
"OXC",
"OXY",
"OXZ",
"OXN",
"PAR",
"GSU",
"REA",
"BSC",
"SIP",
"PRA",
"AES",
"SLC",
"BAH",
"MYP",
"DPS",
"QRY",
"OPY",
"OPE",
"OPV",
"TKG",
"POB",
"EHV",
"SCE",
"PEO",
"ABS",
"PNB",
"FLP",
"APS",
"PNI",
"KUP",
"TGS",
"PBA",
"GIT",
"SOP",
"WWP",
"PPS",
"PNT",
"TIP",
"PST",
"PNS",
"PNU",
"PNV",
"PET",
"FPE",
"MSV",
"LAU",
"SEH",
"SER",
"FTD",
"SCA",
"FLE",
"PCA",
"LAA",
"ATK",
"PLE",
"PPW",
"POL",
"POK",
"OYO",
"QRZ",
"QSF",
"QSH",
"QSJ",
"QSK",
"QSQ",
"QSW",
"QSY",
"QSZ",
"QTB",
"QTC",
"ODP",
"QTD",
"ODS",
"TGA",
"OLX",
"OAX",
"QTF",
"QTG",
"QTJ",
"QTK",
"QTM",
"QTW",
"QTS",
"ONU",
"BLU",
"SCD",
"GAZ",
"BSH",
"PPC",
"PPJ",
"PPU",
"PPH",
"RPC",
"RPP",
"RPR",
"RPZ",
"TCL",
"BUP",
"HAI",
"PSK",
"NEC",
"YFL",
"PSE",
"PTM",
"PSG",
"OCJ",
"MPO",
"TID",
"PTG",
"YRM",
"RJH",
"RJC",
"JFE",
"JFY",
"RJE",
"JAI",
"RJM",
"RJU",
"RAB",
"RAG",
"GHL",
"RHN",
"RBC",
"RBX",
"RCT",
"RCP",
"MRB",
"MRM",
"RHT",
"OTO",
"OJU",
"ROA",
"OJP",
"OJT",
"CLJ",
"SAL",
"WMG",
"BEP",
"BON",
"PIL",
"SAA",
"SAG",
"SAM",
"IOS",
"SAE",
"JSS",
"CPI",
"PIA",
"CHP",
"LIG",
"UGU",
"MAS",
"MAC",
"KGM",
"COM",
"GUT",
"SSM",
"NPH",
"SYC",
"SYP",
"SYE",
"SYF",
"SYT",
"MUD",
"YSA",
"YSS",
"YSM",
"SYR",
"OPP",
"REN",
"REG",
"REB",
"BIS",
"TRY",
"MQI",
"IRE",
"EJA",
"EJN",
"EIP",
"EJR",
"EJT",
"IEB",
"WTB",
"EJB",
"EJG",
"EIJ",
"WTC",
"EJE",
"EJL",
"EJK",
"WTG",
"WTH",
"CVT",
"EIQ",
"EJX",
"IAL",
"IAO",
"EIY",
"EJD",
"IAM",
"WTQ",
"EJY",
"CTC",
"IAA",
"IAQ",
"IAR",
"WSP",
"IAH",
"WTA",
"WTK",
"EJH",
"WTR",
"IAE",
"WTZ",
"IAV",
"WTY",
"WTF",
"WSU",
"IAN",
"IEV",
"WTV",
"WSZ",
"WSW",
"WUZ",
"EDZ",
"EDK",
"ILR",
"IEJ",
"WTO",
"IEO",
"WRW",
"ITG",
"ITB",
"ITW",
"IOF",
"IOT",
"IOB",
"IOI",
"IOL",
"IOZ",
"IOR",
"IOQ",
"IIN",
"EZL",
"UHU",
"UHL",
"UHS",
"RSH",
"SOL",
"GSK",
"SON",
"SOR",
"SBG",
"SPL",
"SPK",
"SPJ",
"SPZ",
"RKS",
"CLT",
"CLB",
"SPR",
"QUA",
"QUL",
"DGS",
"QUB",
"QUC",
"QUJ",
"DOP",
"QUN",
"QUK",
"QUR",
"QYW",
"SUA",
"SUF",
"SUG",
"SUU",
"SUC",
"SUD",
"SUO",
"SWV",
"SUJ",
"SUL",
"SZJ",
"SUT",
"AGN",
"SUE",
"SUN",
"SUY",
"OSF",
"OFE",
"JCC",
"JNG",
"KUN",
"JPQ",
"JPR",
"JPT",
"JPU",
"JPW",
"FPP",
"UTK",
"CKI",
"ORS",
"NID",
"ZTP",
"TOL",
"IKV",
"IKW",
"MLS",
"TWM",
"TVG",
"TFQ",
"HLX",
"JDZ",
"ALK",
"ALB",
"YFT",
"SBF",
"BET",
"PBF",
"BFT",
"LOT",
"SNK",
"YUR",
"SQG",
"TFP",
"SQJ",
"SQE",
"TDQ",
"TTR",
"TTO",
"TTV",
"HMC",
"HMG",
"JJM",
"HMM",
"CJM",
"HOM",
"HMZ",
"TRV",
"TUV",
"LHT",
"FGS",
"NOP",
"BIB",
"CKY",
"URB",
"OJN",
"VAZ",
"UWV",
"WTS",
"SWO",
"BOB",
"TIT",
"DPV",
"JOD"
			};
		}

		public static string GetFaoAreaFromCoordinates(Point myLocation, object mAJOR, object cODE)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Find FAO Area from coordinates 
		/// </summary>
		/// <param name="longitud"></param>
		/// <param name="longitudeGrades"></param>
		/// <param name="longitudeMinutes"></param>
		/// <param name="longitudeSeconds"></param>
		/// <param name="latitude"></param>
		/// <param name="latitudeGrades"></param>
		/// <param name="latitudeMinutes"></param>
		/// <param name="latitudeSeconds"></param>
		/// <param name="faoLevel"></param>
		/// <param name="faoField"></param>
		/// <returns></returns>
		public static string GetFaoAreaFromCoordinates(string longitud, string longitudeGrades, string longitudeMinutes, string longitudeSeconds, string latitude, string latitudeGrades, string latitudeMinutes, string latitudeSeconds, FAOLevel faoLevel = FAOLevel.MAJOR, FAOField faoField = FAOField.CODE)
		{
			Point location = new Point(GetLongitude(longitud, longitudeGrades, longitudeMinutes, longitudeSeconds), GetLatitude(latitude, latitudeGrades, latitudeMinutes, latitudeSeconds));
			return GetFaoAreaFromCoordinates(location, faoLevel, faoField);
		}

		/// <summary>
		/// Find FAO Area from coordinates 
		/// </summary>
		/// <param name="location">Coordinates to find its corresponding FAO Area</param>
		/// <param name="faoLevel">Level to retrieve</param>
		/// <param name="faoField">Field to retrieve</param>
		/// <returns></returns>
		public static string GetFaoAreaFromCoordinates(Point location, FAOLevel faoLevel = FAOLevel.MAJOR, FAOField faoField = FAOField.CODE)
		{
			var idxFaoField = 2;
			
			//34 - MAJOR - Atlantic - Atlántico, centro - oriental
			//34.1 - SUBAREA - Atlantic - Subárea costera norte
			//34.1.1 - DIVISION - Atlantic - Costera de Marruecos
			//34.1.12 - SUBDIVISION - Atlantic - Atl EC / 34.1.12			
			switch (faoField)
			{
				case FAOField.FID:
					idxFaoField = 0;
					break;
				case FAOField.CODE:
					idxFaoField = 1;
					break;
				case FAOField.LEVEL:
					idxFaoField = 2;
					break;
				case FAOField.STATUS:
					idxFaoField = 3;
					break;
				case FAOField.OCEAN:
					idxFaoField = 4;
					break;
				case FAOField.SUBOCEAN:
					idxFaoField = 5;
					break;
				case FAOField.AREA:
					idxFaoField = 6;
					break;
				case FAOField.SUBAREA:
					idxFaoField = 7;
					break;
				case FAOField.DIVISION:
					idxFaoField = 8;
					break;
				case FAOField.SUBDIVIS:
					idxFaoField = 9;
					break;
				case FAOField.SUBUNIT:
					idxFaoField = 10;
					break;
				case FAOField.ID:
					idxFaoField = 11;
					break;
				case FAOField.NAME_EN:
					idxFaoField = 12;
					break;
				case FAOField.NAME_FR:
					idxFaoField = 13;
					break;
				case FAOField.NAME_ES:
					idxFaoField = 14;
					break;
				case FAOField.SURFACE:
					idxFaoField = 15;
					break;
				default:
					idxFaoField = 1;
					break;
			}

			IStreamProviderRegistry streamProvider = GetFaoAreasProvider();
			using (var reader = new ShapefileDataReader(streamProvider, new GeometryFactory()))
			{
				int length = reader.DbaseHeader.NumFields;
				while (reader.Read())
				{
					IGeometry geom = reader.Geometry;
					if (geom.Intersects(location))
					{
						if (reader.GetValue(3).ToString().ToUpper().Equals(faoLevel.ToString()))
						{
							return reader.GetValue(idxFaoField + 1).ToString();
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Get all FaoAreas geometry and its code to the respective level
		/// </summary>
		/// <param name="faoLevel">Level to be retrieved</param>
		/// <returns></returns>
		public static Dictionary<IGeometry, string> GetFaoAreas(FAOLevel faoLevel = FAOLevel.MAJOR)
		{
			Dictionary<IGeometry, string> faoZones = new Dictionary<IGeometry, string>();

			GeometryFactory Factory = new GeometryFactory();
			WKTReader Reader = new WKTReader();

			IStreamProviderRegistry streamProvider = GetFaoAreasProvider();
			using (var reader = new ShapefileDataReader(streamProvider, Factory))
			{
				int length = reader.DbaseHeader.NumFields;
				while (reader.Read())
				{
					if (reader.GetValue(3).ToString().ToUpper().Equals(faoLevel.ToString()))
					{
						faoZones.Add(reader.Geometry, reader.GetValue(2).ToString());
					}
					
				}
			}
			return faoZones;
		}

		/// <summary>
		/// Retrieve all FAO areas where an ASFIS 3Code specie has information about its distribution
		/// </summary>
		/// <param name="FAOCode">ASFIS 3code</param>
		/// <param name="faoLevel">Level to be retrieved</param>
		/// <param name="faoField">Field to be retrieved</param>
		/// <returns></returns>
		public static List<string> GetFaoAreaDistribution(string FAOCode, FAOLevel faoLevel = FAOLevel.MAJOR, FAOField faoField = FAOField.CODE)
		{
			if (!GetFAOCodesDistributionAvailable().Contains(FAOCode)) { return null; }

			//var Factory = new GeometryFactory();
			//var Reader = new WKTReader();
			var idxFaoField = 2;

			switch (faoField)
			{
				case FAOField.FID:
					idxFaoField = 0;
					break;
				case FAOField.CODE:
					idxFaoField = 1;
					break;
				case FAOField.LEVEL:
					idxFaoField = 2;
					break;
				case FAOField.STATUS:
					idxFaoField = 3;
					break;
				case FAOField.OCEAN:
					idxFaoField = 4;
					break;
				case FAOField.SUBOCEAN:
					idxFaoField = 5;
					break;
				case FAOField.AREA:
					idxFaoField = 6;
					break;
				case FAOField.SUBAREA:
					idxFaoField = 7;
					break;
				case FAOField.DIVISION:
					idxFaoField = 8;
					break;
				case FAOField.SUBDIVIS:
					idxFaoField = 9;
					break;
				case FAOField.SUBUNIT:
					idxFaoField = 10;
					break;
				case FAOField.ID:
					idxFaoField = 11;
					break;
				case FAOField.NAME_EN:
					idxFaoField = 12;
					break;
				case FAOField.NAME_FR:
					idxFaoField = 13;
					break;
				case FAOField.NAME_ES:
					idxFaoField = 14;
					break;
				case FAOField.SURFACE:
					idxFaoField = 15;
					break;
				default:
					idxFaoField = 1;
					break;
			}
			List<string> faoAreaList = new List<string>();
			IStreamProviderRegistry streamProvider = GetDistributionProviderByFaoCode(FAOCode);
			using (var readerDistribution = new ShapefileDataReader(streamProvider, new GeometryFactory()))
			{
				int length = readerDistribution.DbaseHeader.NumFields;
				IStreamProviderRegistry streamProviderFaos = GetFaoAreasProvider();
				while (readerDistribution.Read())
				{
					IGeometry geomDistribution = readerDistribution.Geometry;
					using (var readerFaos = new ShapefileDataReader(streamProviderFaos, new GeometryFactory()))
					{
						while (readerFaos.Read())
						{
							if (geomDistribution.Intersects(readerFaos.Geometry))
							{
								if (readerFaos.GetValue(3).ToString().ToUpper().Equals(faoLevel.ToString()))
								{
									string value = readerFaos.GetValue(idxFaoField + 1).ToString();
									if (!faoAreaList.Contains(value)) faoAreaList.Add(value);
								}
							}
						}
					}
				}
			}
			return faoAreaList;
		}

		public static string GetFaoDistribution(Point location, string FAOCode, FAODistributionField field = FAODistributionField.PRESENCE)
		{
			if (!GetFAOCodesDistributionAvailable().Contains(FAOCode)) { return null; }

			var idxDistributionField = 3;
			switch (field)
			{
				case FAODistributionField.FID:
					idxDistributionField = 0;
					break;
				case FAODistributionField.ALPHACODE:
					idxDistributionField = 1;
					break;
				case FAODistributionField.DISPORDER:
					idxDistributionField = 2;
					break;
				case FAODistributionField.PRESENCE:
					idxDistributionField = 3;
					break;
				case FAODistributionField.GEOCODE:
					idxDistributionField = 4;
					break;
				case FAODistributionField.SHAPE_LENG:
					idxDistributionField = 5;
					break;
				case FAODistributionField.SHAPE_AREA:
					idxDistributionField = 6;
					break;
				default:
					idxDistributionField = 3;
					break;
			}
			
			IStreamProviderRegistry streamProvider = GetDistributionProviderByFaoCode(FAOCode);
			using (var reader = new ShapefileDataReader(streamProvider, new GeometryFactory()))
			{
				int length = reader.DbaseHeader.NumFields;
				while (reader.Read())
				{
					IGeometry geom = reader.Geometry;
					if (geom.Intersects(location))
					{
						return reader.GetValue(idxDistributionField).ToString();
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Converts FTF to Lambert coordinates
		/// </summary>
		/// <param name="inlat"></param>
		/// <param name="inlng"></param>
		/// <returns></returns>
		public static string NTFToLambert(double inlat, double inlng)
		{
			double Lamb_a = 6378249.2;
			int Lamb_b = 6356515;
			double Lamb_Phi0 = 46.800;
			double Lamb_Lambda0 = 2.596921296 / 200 * 180;
			double Lamb_e = (Math.Sqrt(Math.Pow(Lamb_a, 2) - Math.Pow(Lamb_b, 2))) / Lamb_a;
			double Lamb_Gamma = 0;
			double NTF_Lat = inlat;
			double NTF_Lng = inlng;
			double Lamb_v = Lamb_a / (Math.Sqrt(1 - Math.Pow(Lamb_e, 2) * Math.Pow(Math.Sin(NTF_Lat * Math.PI / 180), 2)));
			double Lamb_LatIso = (Math.Log(Math.Tan((Math.PI / 4 + (NTF_Lat * Math.PI / 360))))) - Lamb_e / 2 * (Math.Log((1 + Lamb_e * Math.Sin(NTF_Lat * Math.PI / 180)) / (1 - Lamb_e * Math.Sin(NTF_Lat * Math.PI / 180))));
			double Lamb_LatIso0 = (Math.Log(Math.Tan((Math.PI / 4 + (Lamb_Phi0 * Math.PI / 360))))) - Lamb_e / 2 * (Math.Log((1 + Lamb_e * Math.Sin(Lamb_Phi0 * Math.PI / 180)) / (1 - Lamb_e * Math.Sin(Lamb_Phi0 * Math.PI / 180))));
			if (NTF_Lng < 180)
			{
				Lamb_Gamma = (NTF_Lng - Lamb_Lambda0) * Math.Sin(Lamb_Phi0 * Math.PI / 180);
			}
			if (NTF_Lng > 180)
			{
				Lamb_Gamma = (NTF_Lng - Lamb_Lambda0 - 360) * Math.Sin(Lamb_Phi0 * Math.PI / 180);
			}
			int Lamb_Ce = 600;
			int Lamb_Cn = 2200;
			double Lamb_v0 = Lamb_a / (Math.Sqrt(1 - Math.Pow(Lamb_e, 2) * Math.Pow(Math.Sin(Lamb_Phi0 * Math.PI / 180), 2)));
			double Lamb_R0 = Lamb_v0 / Math.Tan(Lamb_Phi0 * Math.PI / 180);
			double Lamb_Phi1 = 50.99879884 / 200 * 180;
			double Lamb_Phi2 = 52.99557167 / 200 * 180;
			double Lamb_v01 = Lamb_a / (Math.Sqrt(1 - Math.Pow(Lamb_e, 2) * Math.Pow(Math.Sin(Lamb_Phi1 * Math.PI / 180), 2)));
			double Lamb_v02 = Lamb_a / (Math.Sqrt(1 - Math.Pow(Lamb_e, 2) * Math.Pow(Math.Sin(Lamb_Phi2 * Math.PI / 180), 2)));
			double Lamb_Ro01 = Lamb_a * (1 - Math.Pow(Lamb_e, 2)) / Math.Pow((Math.Sqrt(1 - Math.Pow(Lamb_e, 2) * Math.Pow(Math.Sin(Lamb_Phi1 * Math.PI / 180), 2))), 3);
			double Lamb_Ro02 = Lamb_a * (1 - Math.Pow(Lamb_e, 2)) / Math.Pow((Math.Sqrt(1 - Math.Pow(Lamb_e, 2) * Math.Pow(Math.Sin(Lamb_Phi2 * Math.PI / 180), 2))), 3);
			double Lamb_m1 = 1 + Lamb_Ro01 / 2 / Lamb_v01 * Math.Pow((Lamb_Phi1 - Lamb_Phi0) * Math.PI / 180, 2);
			double Lamb_m2 = 1 + Lamb_Ro02 / 2 / Lamb_v02 * Math.Pow((Lamb_Phi2 - Lamb_Phi0) * Math.PI / 180, 2);
			double Lamb_m = (Lamb_m1 + Lamb_m2) / 2;
			double Lamb_mL = 2 - Lamb_m;
			double Lamb_mLR0 = Lamb_mL * Lamb_R0;
			double Lamb_R = Lamb_mLR0 * Math.Exp(-Math.Sin(Lamb_Phi0 * Math.PI / 180) * (Lamb_LatIso - Lamb_LatIso0));
			double Lamb_E1 = Lamb_R * Math.Sin(Lamb_Gamma * Math.PI / 180);
			double Lamb_EE = Lamb_E1 + Lamb_Ce * 1000;
			double Lamb_NN = Lamb_mLR0 - Lamb_R + Lamb_E1 * Math.Tan(Lamb_Gamma * Math.PI / 360) + Lamb_Cn * 1000;
			double Lamb_EE_Arr = Math.Round(Lamb_EE * 1000) / 1000;
			double Lamb_NN_Arr = Math.Round(Lamb_NN * 1000) / 1000;
			return Lamb_EE_Arr + ";" + Lamb_NN_Arr;
		}
		private static IStreamProviderRegistry GetFaoAreasProvider()
		{
			Assembly assembly = typeof(ServiceFAO).GetTypeInfo().Assembly;
			var shapeStream = assembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", typeof(ServiceFAO).Namespace, "ShapeFiles", "FAO_AREAS.shp"));
			var indexStream = assembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", typeof(ServiceFAO).Namespace, "ShapeFiles", "FAO_AREAS.shx"));
			var dataStream = assembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", typeof(ServiceFAO).Namespace, "ShapeFiles", "FAO_AREAS.dbf"));

			var streamProviderShape = new ByteStreamProvider(StreamTypes.Shape, shapeStream);
			var streamProviderIndex = new ByteStreamProvider(StreamTypes.Index, indexStream);
			var streamProviderData = new ByteStreamProvider(StreamTypes.Data, dataStream);

			IStreamProviderRegistry streamProvider = new ShapefileStreamProviderRegistry(streamProviderShape, streamProviderData, streamProviderIndex);
			return streamProvider;
		}

		private static IStreamProviderRegistry GetDistributionProviderByFaoCode(string FAOCode)
		{
			Assembly assembly = typeof(ServiceFAO).GetTypeInfo().Assembly;
			var shapeStream = assembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", typeof(ServiceFAO).Namespace, "ShapeFiles", "SPECIES_DIST_" + FAOCode + ".shp"));
			var indexStream = assembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", typeof(ServiceFAO).Namespace, "ShapeFiles", "SPECIES_DIST_" + FAOCode + ".shx"));
			var dataStream = assembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", typeof(ServiceFAO).Namespace, "ShapeFiles", "SPECIES_DIST_" + FAOCode + ".dbf"));

			var streamProviderShape = new ByteStreamProvider(StreamTypes.Shape, shapeStream);
			var streamProviderIndex = new ByteStreamProvider(StreamTypes.Index, indexStream);
			var streamProviderData = new ByteStreamProvider(StreamTypes.Data, dataStream);

			IStreamProviderRegistry streamProvider = new ShapefileStreamProviderRegistry(streamProviderShape, streamProviderData, streamProviderIndex);
			return streamProvider;
		}
	}
}
