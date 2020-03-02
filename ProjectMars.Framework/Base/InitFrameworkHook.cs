using System;
using System.Text;
using System.Collections.Generic;
using ProjectMars.Framework.Config;
using BoDi;

namespace ProjectMars.Framework.Base
{
    public class InitFrameworkHook
    {
       
        public void InitFramework(IObjectContainer objectContainer)
        {
            _ = new InitConfig();
            _ = new WebDriverContext(objectContainer);
            _ = new ExtendReportContext();

        }

    }
}
