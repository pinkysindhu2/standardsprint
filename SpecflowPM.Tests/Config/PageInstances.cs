using SpecflowPM.Tests.Pages.Account;
using SpecflowPM.Tests.Pages.Home;
using SpecflowPM.Tests.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowPM.Tests.Config
{
    public class PageInstances
    {
        public Login login { get; set; }
        public Logout logout { get; set; }
        public static Profile profile { get; set; }
        public ProfileSettings profileSettings { get; set; }
        public HomePage home { get; set; }
        public ProfileSection profileSection { get; set; }
        public Language language { get; set; }
        public Education education { get; set; }
        public Description description { get; set; }
        public Certificate certificate { get; set; }
        public Skill skill { get; set; }
    }
}
