using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BC.NET;

namespace BC.NETWebAppTest
{
    public partial class _Default : System.Web.UI.Page
    {
        private DAX2009ConnectorServer dax = new DAX2009ConnectorServer();

        protected void Page_Load(object sender, EventArgs e)
        {
            string className = "ZFS_TestXML";
            string methodName = "getResultTable";

            object obj = dax.CallAxMethod(className, methodName, null);
        }
    }
}
