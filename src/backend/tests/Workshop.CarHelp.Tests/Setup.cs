using AutoMapper;
using NUnit.Framework;
using Workshop.Api.MappingProfiles;

namespace Workshop.CarHelp.Tests
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public void ConfigureAutomapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new CarHelpProfile());
            });
        }
    }
}
