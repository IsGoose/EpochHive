using EpochHive.DataModels;
using EpochHive.Exceptions;
using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EpochHive
{
    class Entry
    {
        [DllExport("_RVExtension@12", CallingConvention = CallingConvention.Winapi)]
        public static void RVExtension(StringBuilder output, int outputSize, [MarshalAs(UnmanagedType.LPStr)] string function)
        {
            try
            {
                outputSize--;
                string[] functionSplit = function.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                //Minimum 2 Parameters: "CHILD" & ChildKey
                if (functionSplit.Length < 2)
                {
                    throw new NotEnoughParametersExecption(functionSplit.Length, 2);
                }

                Configuration.Load();

                var result = MySqlInterface.ConnectToDatabase();

                var sqfModel = SqfModelBase.ParseInput(functionSplit[1], functionSplit.Length > 2 ? functionSplit[2] : "");

                if (!result.Success)
                {
                    //TODO: Append Output
                }

                output.Append(result.Success);


            }
            catch (BaseException e)
            {
                //TODO: Log
                output.Append(e.Message);
                //TODO: Append Output
            }
        }
    }
}
