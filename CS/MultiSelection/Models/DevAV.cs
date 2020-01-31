using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiSelection.Models {
    public class DevAV {
        readonly static string[] regions = new string[] { "DevAV North", "DevAV South", "DevAV West", "DevAV East", "DevAV Central" };
        static Dictionary<string, List<string>> categorizedProducts;

        public static Dictionary<string, List<string>> CategorizedProducts {
            get {
                if (categorizedProducts == null) {
                    categorizedProducts = new Dictionary<string, List<string>>();
                    categorizedProducts["Cameras"] = new List<string>() { "Camera", "Camcorder", "Binoculars", "Flash", "Tripod" };
                    categorizedProducts["Cell Phones"] = new List<string>() { "Smartphone", "Mobile Phone", "Smart Watch", "Sim Card" };
                    categorizedProducts["Computers"] = new List<string>() { "Desktop", "Laptop", "Tablet", "Printer" };
                    categorizedProducts["TV, Audio"] = new List<string>() { "Television", "Home Audio", "Headphone", "DVD Player" };
                    categorizedProducts["Vehicle Electronics"] = new List<string>() { "GPS Unit", "Radar", "Car Alarm", "Car Accessories" };
                    categorizedProducts["Multipurpose Batteries"] = new List<string>() { "Battery", "Charger", "Converter", "Tester", "AC/DC Adapter" };
                }
                return categorizedProducts;
            }
        }
        public static List<DevAVDataItem> GetSales() {
            List<DevAVDataItem> list = new List<DevAVDataItem>(15);
            int prevYear = DateTime.Now.Year - 1;

            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "Asia", 4.2372M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "Australia", 1.7871M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "Europe", 3.0884M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "North America", 3.4855M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "South America", 1.6027M));

            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "Asia", 4.7685M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "Australia", 1.9576M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "Europe", 3.3579M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "North America", 3.7477M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "South America", 1.8237M));

            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "Asia", 5.2890M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "Australia", 2.2727M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "Europe", 3.7257M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "North America", 4.1825M));
            list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "South America", 2.1172M));

            return list;
        }
    }
    public class DevAVDataItem {
        public static DevAVDataItem CreateByYearRegionSales(int year, string region, decimal sales) {
            DevAVDataItem item = new DevAVDataItem();
            item.Year = year;
            item.Region = region;
            item.Sales = sales;
            return item;
        }
        public int Year { get; private set; }
        public string Region { get; private set; }
        public decimal Sales { get; private set; }
        public decimal Cost { get; private set; }
        public string ProductCategory { get; private set; }
        public string ProductName { get; private set; }
        public string Company { get; private set; }
        public DateTime SaleDate { get; private set; }
        public decimal Charges { get; private set; }
        public decimal Penalties { get; private set; }

        DevAVDataItem() { }
    }
}