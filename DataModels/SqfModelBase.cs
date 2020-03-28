using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpochHive.DataModels
{
    public class SqfModelBase
    {
        public bool Success { get; set; }
        public string ModelResult { get; set; }
        public static SqfModelBase ParseInput(string child, string sqfArray)
        {
            //TODO: Handle no Array Parameter - for parameterless calls
            if (sqfArray == "")
                return new SqfModelBase();

            //TODO: Sqf Data Models
            SqfModelBase model;
            switch(child)
            {
                
            }

            return new SqfModelBase();
        }
    }
}
