using System.Globalization;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BingMapsChallenge
{
    public class Challenge
    {
        /* Bing Maps Challenge
         * 
         * In this challenge you need to use the Bing Maps API to resolve an address, postal code and country to a geolocation (latitude and longitude).
         * 
         * You will receive three inputs for your method: [1] an address line, [2] a postalcode [3] and a country code.
         * 
         * You must return a double array of length 2. Index 0 of the array shall be the latitude and index 1 shall be the longitude.
         * 
         * Example: If the input were to be the values below:
         *          
         *          addressLine = "Tuborg Boulevard 12"
         *          postalCode  = "2900"
         *          countryCode = "DK"
         *          
         *          Then the result should be a double array (e.g., resultArray) with the following values:
         *          
         *          resultArray[0] = 55.7271614
         *          resultArray[1] = 12.5807505
         *          
         * You need to use the Locations API and create an "Unstructured URL". Read more here: http://msdn.microsoft.com/en-us/library/ff701714.aspx
         * 
         * You also need to sign up for a Bing Maps API key. You can do that here: http://www.microsoft.com/maps/create-a-bing-maps-key.aspx
         * 
         * Good luck!
         */

        public double[] Execute(string addressLine, string postalCode, string countryCode)
        {
            double[] resultArray = new double[2];

            string url = string.Format("http://dev.virtualearth.net/REST/v1/Locations?o=xml&CountryRegion={0}&postalCode={1}&addressLine={2}&key=Ap9OgtL5VSuWuG7qTgroqq13Hxqge5qFXHM1im7hr7x4FowZlIick-omaC2Tdxzq", 
                HttpUtility.UrlEncode(countryCode),
                HttpUtility.UrlEncode(postalCode), 
                HttpUtility.UrlEncode(addressLine) 
                );


            //requesting the particular web page
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            //geting the response from the request url
            var response = (HttpWebResponse)httpRequest.GetResponse();

            //create a stream to hold the contents of the response (in this case it is the contents of the XML file
            var streamToString = StreamToString(response.GetResponseStream());

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(streamToString);

            var xmlNode = doc.GetElementsByTagName("Point")[0];
            var lat = Convert.ToDouble(xmlNode.ChildNodes[0].InnerText, CultureInfo.InvariantCulture);
            var lon = Convert.ToDouble(xmlNode.ChildNodes[1].InnerText, CultureInfo.InvariantCulture);

            resultArray[0] = lat;
            resultArray[1] = lon;

            return resultArray;
        }

        public static string StreamToString(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
