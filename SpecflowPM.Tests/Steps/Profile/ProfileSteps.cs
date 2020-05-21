using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowPM.Tests.Steps.Profile
{
    [Binding]
    public class ProfileSteps: Config.PageInstances
    {
        private readonly IWebDriver Driver;
        private string featureName;
        public ProfileSteps(FeatureContext featureContext, IWebDriver driver)
        {
            this.Driver = driver;
            profileSection = new Pages.Profile.ProfileSection(Driver);
            string featureName = featureContext.FeatureInfo.Title;
            //InitializePages(featureName);
        }

/*        private void InitializePages(string name)
        {
            switch (name)
            {
                case "Profile":
                    profileSection = new Pages.Profile.ProfileSection(Driver);
                    break;
                case "Language":
                    language = new Pages.Profile.Language(Driver);
                    break;
                case "Skill":
                   skill = new Pages.Profile.Skill(Driver);
                    break;
                case "Education":
                    education = new Pages.Profile.Education(Driver);
                    break;
                case "Certification":
                    certificate = new Pages.Profile.Certificate(Driver);
                    break;
                case "Description":
                    description = new Pages.Profile.Description(Driver);
                    break;
            }

        }*/
       
        [When(@"I update Availability")]
        public void WhenIUpdateAvailability()
        {
            profileSection.UpdateAvailability();
        }

        [Then(@"the result should be updated beside Availability")]
        public void ThenTheResultShouldBeUpdatedBesideAvailability()
        {
            Assert.AreEqual(true, profileSection.AvailableTimeSuccess());
        }

        [When(@"I update Hours")]
        public void WhenIUpdateHours()
        {
            profileSection.UpdateHours();
        }

        [Then(@"the result should be updated beside Hours")]
        public void ThenTheResultShouldBeUpdatedBesideHours()
        {
            Assert.AreEqual(true, profileSection.AvailableHoursSuccess());
        }

        [When(@"I update Earn Target")]
        public void WhenIUpdateEarnTarget()
        {
            profileSection.UpdateEarnTarget();
        }

        [Then(@"the result should be updated beside Earn Target")]
        public void ThenTheResultShouldBeUpdatedBesideEarnTarget()
        {
            Assert.AreEqual(true, profileSection.EarnTargetSuccess());
        }

        #region Language Feature steps

        [Given(@"I click on the language tab")]
        public void GivenIClickOnTheLanguageTab()
        {
            language = profileSection.ClickOnLanguageTab();
        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            language.AddLanguage();
        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            Assert.That(language.AddLangSuccess(), Is.EqualTo(true));
        }

        [Given(@"One or more language is available")]
        public void GivenOneOrMoreLanguageIsAvailable()
        {
            Assert.That(language.ISLangAvailable(), Is.GreaterThan(0));
        }

        [When(@"I edit a lanaguage")]
        public void WhenIEditALanaguage()
        {
            language.EditLanguage();
        }

        [Then(@"I should successfully see the updated lanaguage")]
        public void ThenIShouldSuccessfullySeeTheUpdatedLanaguage()
        {
            Assert.That(language.UpdateEditLangSuccess(), Is.EqualTo(true));
        }

        [When(@"I delete a lanaguage")]
        public void WhenIDeleteALanaguage()
        {
            language.DeleteLanguage();
        }

        [Then(@"that particular language should be deleted successfully")]
        public void ThenThatParticularLanguageShouldBeDeletedSuccessfully()
        {
            Assert.That(language.DeleteLangSuccess(), Is.EqualTo(false));
        }


        [When(@"I click on cancel button")]
        public void WhenIClickOnCancelButton()
        {
            switch (featureName)
            {
                case "Profile":
                   
                    break;
                case "Language":
                    language.CancelLanguage();
                    break;
                case "Skill":
                    skill.CancelSkill();
                    break;
                case "Education":
                    education.CancelEducation();
                    break;
                case "Certification":
                    certificate.CancelCertificate();
                    break;
                case "Description":     
                    break;
            }
            
        }

        [Then(@"that form should successfully reset and hide")]
        public void ThenThatFormShouldSuccessfullyResetAndHide()
        {
            switch (featureName)
            {
                case "Profile":

                    break;
                case "Language":
                    Assert.That(language.CancelLangSuccess(), Is.EqualTo(false));
                    break;
                case "Skill":
                    Assert.That(skill.CancelSkillSuccess(), Is.EqualTo(false));
                    break;
                case "Education":
                    Assert.That(education.CancelEducationSuccess(), Is.EqualTo(false));
                    break;
                case "Certification":
                    Assert.That(certificate.CancelCertificateSuccess(), Is.EqualTo(false));
                    break;
                case "Description":

                    break;
            }
            
        }
        #endregion

        #region Skill Feature Steps
        [Given(@"I click on the Skill tab")]
        public void GivenIClickOnTheSkillTab()
        {
           skill = profileSection.ClickOnSkillTab();
        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            skill.AddSkill();
        }

        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            Assert.That(skill.AddSkillSuccess(), Is.EqualTo(true));
        }

        [Given(@"One or more Skill is available")]
        public void GivenOneOrMoreSkillIsAvailable()
        {
            Assert.That(skill.ISSkillAvailable(), Is.GreaterThan(0));
        }

        [When(@"I edit a skill")]
        public void WhenIEditASkill()
        {
            skill.EditSkill();
        }

        [Then(@"I should successfully see the updated skill")]
        public void ThenIShouldSuccessfullySeeTheUpdatedSkill()
        {
            Assert.That(skill.UpdateEditSkilllSuccess(), Is.EqualTo(true));
        }

        [When(@"I delete skill")]
        public void WhenIDeleteSkill()
        {
            skill.DeleteSkill();
        }

        [Then(@"that particular skill should be deleted successfully")]
        public void ThenThatParticularSkillShouldBeDeletedSuccessfully()
        {
            Assert.That(skill.DeleteSkillSuccess(), Is.EqualTo(false));
        }
        #endregion

        #region Education Feature Steps

        [Given(@"I click on the Education")]
        public void GivenIClickOnTheEducation()
        {
            education = profileSection.ClickOnEducationTab();
        }

        [When(@"I add a new education")]
        public void WhenIAddANewEducation()
        {
            education.AddEducation();
        }

        [Then(@"that education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            Assert.That(education.AddEducationSuccess(), Is.EqualTo(true));
        }

        [Given(@"One or more Education is available")]
        public void GivenOneOrMoreEducationIsAvailable()
        {
            Assert.That(education.IsEducationAvailable(), Is.GreaterThan(0));
        }

        [When(@"I edit a education")]
        public void WhenIEditAEducation()
        {
            education.UpdateEducation();
        }

        [Then(@"I should successfully see the updated education")]
        public void ThenIShouldSuccessfullySeeTheUpdatedEducation()
        {
            Assert.That(education.UpdateEducationSuccess(), Is.EqualTo(true));
        }

        [When(@"I delete education")]
        public void WhenIDeleteEducation()
        {
            education.DeleteEducation();
        }

        [Then(@"that particular education should be deleted successfully")]
        public void ThenThatParticularEducationShouldBeDeletedSuccessfully()
        {
            Assert.That(education.DeleteEducationSuccess(), Is.EqualTo(false));
        }
        #endregion

        #region Certificate feature steps
        [Given(@"I click on the Certification tab")]
        public void GivenIClickOnTheCertificationTab()
        {
            certificate = profileSection.ClickOnCertificateTab();
        }

        [When(@"I add a new certification")]
        public void WhenIAddANewCertification()
        {
            certificate.AddCertificate();
        }

        [Then(@"that certification should be successfully displayed on my listings")]
        public void ThenThatCertificationShouldBeSuccessfullyDisplayedOnMyListings()
        {
            Assert.That(certificate.AddCertificateSuccess(), Is.EqualTo(true));
        }

        [Given(@"One or more Certification is available")]
        public void GivenOneOrMoreCertificationIsAvailable()
        {
            Assert.That(certificate.IsCertificateAvailable(), Is.GreaterThan(0));
        }

        [When(@"I edit a certification")]
        public void WhenIEditACertification()
        {
            certificate.UpdateCertificate();
        }

        [Then(@"I should successfully see the updated certification")]
        public void ThenIShouldSuccessfullySeeTheUpdatedCertification()
        {
            Assert.That(certificate.UpdateCertificateSuccess(), Is.EqualTo(true));
        }

        [When(@"I delete a certification")]
        public void WhenIDeleteACertification()
        {
            certificate.DeleteCertificate();
        }

        [Then(@"that particular certification should be deleted successfully")]
        public void ThenThatParticularCertificationShouldBeDeletedSuccessfully()
        {
            Assert.That(certificate.DeleteCertificateSuccess, Is.EqualTo(false));
        }

        #endregion

        #region Description feature steps
        [Given(@"I click on Edit button beside Description")]
        public void GivenIClickOnEditButtonBesideDescription()
        {
            description = profileSection.ClickOnDescription();
        }

        [When(@"I save a short summary")]
        public void WhenISaveAShortSummary()
        {
            description.AddDescription();
        }

        [Then(@"that short summary should be displayed on my listings")]
        public void ThenThatShortSummaryShouldBeDisplayedOnMyListings()
        {
            Assert.That(description.IsDescriptionSaved(), Is.EqualTo(true));
        }

        [When(@"I update description")]
        public void WhenIUpdateDescription()
        {
            description.UpdateDescription();
        }

        [Then(@"that description should be successfully updated")]
        public void ThenThatDescriptionShouldBeSuccessfullyUpdated()
        {
            Assert.That(description.IsDescriptionUpdated(), Is.EqualTo(true));
        }

        #endregion
    }
}
