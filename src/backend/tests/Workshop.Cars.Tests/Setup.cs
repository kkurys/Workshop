using AutoMapper;
using NUnit.Framework;
using Workshop.Api.MappingProfiles;

namespace Workshop.Cars.Tests
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public void ConfigureAutomapper()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile(new CarProfile()); });
        }
    }
}