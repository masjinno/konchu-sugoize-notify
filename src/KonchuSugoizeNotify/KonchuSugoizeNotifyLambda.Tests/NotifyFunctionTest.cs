using Amazon.Lambda.TestUtilities;
using KonchuSugoizeNotifyLambda.Models;
using KonchuSugoizeNotifyLambda.Resources;
using Moq;
using System.Diagnostics;
using System.Text.Json;
using Xunit;

namespace KonchuSugoizeNotifyLambda.Tests
{
    public class NotifyFunctionTest
    {
        [Fact]
        public void NotifyOfFreeTVTest()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new NotifyFunction();
            var context = new TestLambdaContext();

            //// mock settings
            //string inputJsonPath = @"..\..\..\Resources\NhkNotifyObjectSample1.json";
            //string fullPath = Path.GetFullPath(inputJsonPath);
            //NhkProgramObject retValue = JsonSerializer.Deserialize<NhkProgramObject>(ResourceReader.ReadTextFile(inputJsonPath));
            //var mock = new Mock<INhkApiCaller>();
            //mock.Setup(x => x.GetNhkProgramFromServices(It.IsAny<List<NhkService>>())).Returns(retValue);

            // Execute function
            var upperCase = function.NotifyOfFreeTV("hello world", context);

            // Evaluate result
            Assert.Equal("HELLO WORLD", upperCase);
        }

        [Fact]
        public void NotifyOfPremiumTVTest()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new NotifyFunction();
            var context = new TestLambdaContext();
            var upperCase = function.NotifyOfPremiumTV("hello world", context);

            Assert.Equal("HELLO WORLD", upperCase);
        }

        [Fact]
        public void NotifyOfRadioTest()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new NotifyFunction();
            var context = new TestLambdaContext();
            var upperCase = function.NotifyOfRadio("hello world", context);

            Assert.Equal("HELLO WORLD", upperCase);
        }
    }
}
