using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Test.PingTests
{
    public class NetworkServiceTest
    {
        private readonly IDNS _dns;
        private readonly NetworkService _pingService;
        //SUT: System under testing
        public NetworkServiceTest()
        {
            //Dependencies
            _dns = A.Fake<IDNS>();

            //SUT
            _pingService = new NetworkService(_dns);
        }
        [Fact]
        public void NetworkServiceTest_SendPing_ReturnString()
        {
            // Arrange
            A.CallTo(() => _dns.SendDNS()).Returns(true);
            // Act
            var result = _pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2, 2,4)]

        public void NetworkServiceTest_PingTimeOut_ReturnInt(int a, int b, int expected)
        {
            //Arrange
            
            //Act
            var result = _pingService.PingTimeOut(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        [Fact]
        public void NetworkServiceTest_LastPingDate_ReturnDate()
        {
            // Arrange
            
            // Act
            var result = _pingService.LastPingDate();

            //Assert 
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkServiceTest_GetPingOptions_ReturnObject()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = _pingService.GetPingOptions();

            //Assert 
            //When testing for an object, we use "BeEquivalent"
            //When testing for values, we use "Be"
            //When testing for values, we use use an expected value
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        public void NetworkServiceTest_MostRecentPing_ReturnList()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = _pingService.MostRecentPing();

            //Assert 
            result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
