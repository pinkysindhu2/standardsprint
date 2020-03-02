using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowPM.Tests.Pages
{
    public class BasePage
    {

        public T As<T>() where T : BasePage {
            return (T)this;
        }
    }
}
