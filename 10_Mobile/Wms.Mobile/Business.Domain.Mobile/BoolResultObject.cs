using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile
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
