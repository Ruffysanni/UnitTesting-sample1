using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Test.PingTests
{
    public class NetworkServiceTest
    {
        [Fact]
        public static void NetworkServiceTest_SendPing_ReturnString()
        {
            // Arrange
            var pingService = new NetworkService();

            // Act
            var result = pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2, 2,4)]

        public static void NetworkServiceTest_PingTimeOut_ReturnInt(int a, int b, int expected)
        {
            //Arrange
            var pingTime = new NetworkService();

            //Act
            var result = pingTime.PingTimeOut(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }
    }
}
