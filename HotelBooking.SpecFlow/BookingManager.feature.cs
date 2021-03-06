﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace HotelBooking.SpecFlow
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CreateBookingExamplesFeature : Xunit.IClassFixture<CreateBookingExamplesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "BookingManager.feature"
#line hidden
        
        public CreateBookingExamplesFeature(CreateBookingExamplesFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Create Booking Examples", "\tIn order to create a hotel booking\r\n\tas a customer i want to know if the\r\n\troom " +
                    "is already booked.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.TheoryAttribute(DisplayName="Create Booking")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Booking Examples")]
        [Xunit.TraitAttribute("Description", "Create Booking")]
        [Xunit.InlineDataAttribute("\'1/1/2018\'", "\'1/2/2018\'", "true", new string[0])]
        [Xunit.InlineDataAttribute("\'1/5/2018\'", "\'1/6/2018\'", "true", new string[0])]
        [Xunit.InlineDataAttribute("\'1/1/2018\'", "\'1/5/2018\'", "false", new string[0])]
        [Xunit.InlineDataAttribute("\'1/1/2018\'", "\'1/3/2018\'", "false", new string[0])]
        [Xunit.InlineDataAttribute("\'1/1/2018\'", "\'1/4/2018\'", "false", new string[0])]
        [Xunit.InlineDataAttribute("\'1/3/2018\'", "\'1/3/2018\'", "false", new string[0])]
        [Xunit.InlineDataAttribute("\'1/4/2018\'", "\'1/4/2018\'", "false", new string[0])]
        [Xunit.InlineDataAttribute("\'1/3/2018\'", "\'1/4/2018\'", "false", new string[0])]
        [Xunit.InlineDataAttribute("\'1/4/2018\'", "\'1/3/2018\'", "false", new string[0])]
        [Xunit.InlineDataAttribute("\'1/4/2018\'", "\'1/5/2018\'", "false", new string[0])]
        [Xunit.InlineDataAttribute("\'1/3/2018\'", "\'1/5/2018\'", "false", new string[0])]
        public virtual void CreateBooking(string startDate, string endDate, string outcome, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Booking", null, exampleTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 testRunner.Given(string.Format("I have entered a {0} and {1}", startDate, endDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("a room is already booked from \'1/3/2018\' to \'1/4/2018\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I press create booking", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then(string.Format("the result should be \'{0}\'", outcome), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CreateBookingExamplesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CreateBookingExamplesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
