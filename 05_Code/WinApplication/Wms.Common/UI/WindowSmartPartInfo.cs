using System.Collections.Generic;

namespace Wms.Common.UI
{
    public class WindowSmartPartInfo : Microsoft.Practices.CompositeUI.WinForms.WindowSmartPartInfo
    {
        private readonly Dictionary<string, object> _keys = new Dictionary<string, object>();
        public IDictionary<string, object> Keys
        {
            get { return _keys; }
        }
    }
}
