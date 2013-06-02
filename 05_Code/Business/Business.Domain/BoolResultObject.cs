using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain
{
    public class BoolResultObject
    {
        public bool Result { get; set; }

        public BoolResultObject()
        {
        }

        public BoolResultObject(bool result)
        {
            this.Result = result;
        }
    }
}
