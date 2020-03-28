using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpochHive.Exceptions
{
    public class BaseException : Exception
    {
        public string ErrorMessage { get; set; }
        public List<string> Details = new List<string>();
    }
}
