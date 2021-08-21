using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using wiloazure.Common.Models;
using wiloazure.Function.Entities;
using wiloazure.Function.Functions;
using wiloazure.Test.Helpers;
using Xunit;

namespace wiloazure.Test.Tests
{
    public class TodoApiTest
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void CreateTodo_Should_Return_200()
        {
            //Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoRequest);
            //Act
            IActionResult response = await TodoApi.CreateTodo(request, mockTodos, logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
        /*
        [Fact]
        public async void GetAllTodos_Should_Return_200()
        {
            //Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoRequest);
            //Act
            IActionResult response = await TodoApi.GetAllTodos(request, mockTodos, logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async void GetAllTodoById_Should_Return_200()
        {
            //Arrenge
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoId, todoRequest);
            TodoEntity todoEntity = TestFactory.GetTodoEntity();
            //Act
            IActionResult response = await TodoApi.GetAllTodoById(request, todoEntity, todoId.ToString(), logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
        */







        [Fact]
        public async void UpdateTodo_Should_Return_200()
        {
            //Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoId, todoRequest);
            //Act
            IActionResult response = await TodoApi.UpdateTodo(request, mockTodos, todoId.ToString(), logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }





        [Fact]
        public async void DeleteTodo_Should_Return_200()
        {
            //Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoId, todoRequest);
            TodoEntity todoEntity = TestFactory.GetTodoEntity();
            //Act
            IActionResult response = await TodoApi.DeleteTodo(request,todoEntity, mockTodos, todoId.ToString(), logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}

