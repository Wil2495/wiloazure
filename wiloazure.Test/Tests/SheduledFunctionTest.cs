using System;
using wiloazure.Functions.Function;
using wiloazure.Test.Helpers;
using Xunit;

namespace wiloazure.Test.Tests
{
    public class SheduledFunctionTest
    {




        [Fact]
        public void ScheduledFuction_Should_Log_Message()
        {
            //Arrange
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);
            //Act

            ScheduledFunction.Run(null, mockTodos, logger);
            string message = logger.logs[0];

            // Asert
            Assert.Contains("Deleting completed", message);

        }
    }
}
