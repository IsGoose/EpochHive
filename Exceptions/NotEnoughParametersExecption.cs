using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpochHive.Exceptions
{
    public class NotEnoughParametersExecption : BaseException
    {
        
        public NotEnoughParametersExecption(int given,int expected)
        {
            ErrorMessage = "Not enough Parameters Supplied to Child Exectuction";
            Details.Add($"Given {given} parameters, expected at least {expected}");
        }
    }
}
