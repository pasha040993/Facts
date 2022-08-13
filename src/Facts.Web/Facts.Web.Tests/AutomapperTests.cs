using Facts.Web.Infrastructure.Mappers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facts.Web.Tests
{
    public class AutomapperTests
    {
        [Fact]
        [Trait("Automapper", "Mapper Configuration")]
        public void ItShouldCorrectlyConfigured()
        {
            // arrange

           var config = MapperRegistration.GetMapperConfiguration();

            // act

            // assert
            config.AssertConfigurationIsValid();
        }
    }
}
