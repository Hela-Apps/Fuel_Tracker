using ClassifiedAds.Tools.ExtractExcel.ViewModels;
using ExcelDataReader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ClassifiedAds.Tools.ExtractExcel.Readers
{
    public class CityReader
    {
        private readonly ILogger<CityReader> logger;
        private readonly IConfiguration configuration;

        public CityReader(ILogger<CityReader> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public void Read()
        {
            string filePath = configuration.GetValue<string>("File:City");

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            FilterRow = (rowReader) =>
                            {
                                int progress = (int)Math.Ceiling(rowReader.Depth / (decimal)rowReader.RowCount * 100);
                                // progress is in the range 0..100
                                return true;
                            },
                            UseHeaderRow = true
                        }
                    });

                    // The result of each spreadsheet is in result.Tables
                    int count = 0;
                    List<CityViewModel> cities = new List<CityViewModel>();

                    foreach (DataTable table in result.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            var id = row.Field<double>(0);
                            var districtId = row.Field<double>(1);
                            var name = row.Field<string>(2);
                            var postcode = row.Field<double>(3);
                            var latitude = row.Field<double>(4);
                            var longitude = row.Field<double>(5);

                            logger.LogInformation("id: {0}, districtId: {1}, postcode: {2}, latitude: {3}, longitude: {4} ", id, districtId, postcode, latitude, longitude);

                            var city = new CityViewModel
                            {
                                //Id = Convert.ToInt32(id),
                                DistrictId = Convert.ToInt32(districtId),
                                IsActive = true,
                                Name = name,
                                PostCode = postcode.ToString(),
                                Latitude = (float)latitude,
                                Longitude = (float)longitude

                            };
                            cities.Add(city);
                        }
                    }

                    var json = JsonConvert.SerializeObject(cities, Formatting.Indented);

                    string path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        configuration.GetValue<string>("File:Results"),
                        "cities.json");

                    logger.LogInformation("Writing countries to {0}", path);

                    File.WriteAllText(path, json);
                }
            }
        }
    }
}
