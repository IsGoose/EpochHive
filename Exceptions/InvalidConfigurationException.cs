using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpochHive.Exceptions
{
    public class InvalidConfigurationException : BaseException
    {
        public static InvalidConfigurationException FileNotFound(string[] paths)
        {
            var ex = new InvalidConfigurationException();
            ex.ErrorMessage = "Configuration File not Found. Searched in directories:";
            ex.Details.AddRange(paths);

            return ex;
        }

        public static InvalidConfigurationException AccessDenied(string path)
        {
            var ex = new InvalidConfigurationException();
            ex.ErrorMessage = "Access Denied to Directory:";
            ex.Details.Add(path);

            return ex;
        }
        public static InvalidConfigurationException JsonException(JsonException jsonException)
        {
            var ex = new InvalidConfigurationException();
            ex.ErrorMessage = "An error occured when deserializing the Configuration File. Please ensure JSON is Valid";
            ex.Details.Add("JsonExpection Error:");
            ex.Details.Add("\t" + jsonException.Message);
            ex.Details.Add("Check JSON Validity: https://jsonlint.com/");

            return ex;
        }

        public InvalidConfigurationException(bool unknown = false,Exception exception = null)
        {
            if (unknown)
            {
                ErrorMessage = "Configuration Appears Invalid. Please check the location of the Configuration File and that the JSON is correct";
                Details.Add("For JSON Validity, please paste Configuration JSON into this site: https://jsonlint.com/");
                if (exception != null)
                    Details.Add(exception.Message);
            }
        }

        
    }
}
