using Moq;
using ClientData.Domain.Models;
using ClientData.Application.Services;
using ClientData.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace ClientData.Tests.Controllers;

public class ClientsDataControllerTest
{
    //https://code-maze.com/unit-testing-controllers-aspnetcore-moq/

    private readonly Mock<IClientDataService> _mockservice;
    private readonly ClientsDataController _controller;
    public ClientsDataControllerTest()
    {
        _mockservice = new Mock<IClientDataService>();
        _controller = new ClientsDataController(_mockservice.Object);
    }
    //we create a mock object of type IClientDataService
    //since we want to test controller logic, we create an instance of that controller with
    //the mock object as a required paramatere (dependency injection)
    [Fact]
    public async Task Get_GetAllClientsAsync_ReturnTheExactNumberOfClients()
    {
        //Arrange
        var clientslist = new List<Client>() { new Client(), new Client(), new Client() };
        _mockservice.Setup(repo => repo.GetAllClientsAsync())
            .ReturnsAsync(clientslist);

        //Act
        var result = await _controller.Get();

        //Asseert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedClients = Assert.IsType<List<Client>>(okResult.Value); //sprawdza typ zawartości okResult
        Assert.Equal(clientslist.Count, returnedClients.Count); //sprawdza czy wartość jest typu List<Client>
    }

    [Fact]
    public async Task Get_GetAllClientsAsync_ShouldReturnTrue()
    {
        //Arrange 
        var clients = new List<Client>() { new Client(), new Client(), new Client() };
        _mockservice.Setup(repo => repo.GetAllClientsAsync())
            .ReturnsAsync(clients);
        //używam mocka wtedy gdy korzystam z metod IProductService
        //Act
        var result = await _controller.Get();
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result); //typ zwracanego rezultatu
                                                              //ma być typu OkObjectResult - jeślie nie będzie tego typu test nie przejdzie

        Assert.Equal(clients, okResult.Value);
    }

    [Fact]
    public async Task Get_InvalidId_ReturnsNotFound()
    {
        //Arrange
        _mockservice.Setup(m => m.GetClientAsync(It.IsAny<int>())) //wykorzystuje jakikolwiek parametr o typie int
            .ReturnsAsync((Client)null);
        //Act
        var result = await _controller.Get(344);
        //Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }
    [Fact]
    public async Task Get_ValidId_ReturnOkResult()
    {
        //Arrange  
        var newClient = new Client() { Id = 13 };
        _mockservice.Setup(m => m.GetClientAsync(It.IsAny<int>()))
            .ReturnsAsync(newClient);
        //Act
        var result = await _controller.Get(13);
        //Assert 
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(newClient, okResult.Value);
    }
    [Fact]
    public async Task Post_AddClientAsync_ReturnsOkResult()
    {
        //Arrange
        var client = new Client() { Id = 12 };
        _mockservice.Setup(m => m.AddClientAsync(It.IsAny<Client>()))
            .ReturnsAsync(client);
        //Act
        var result = await _controller.Post(client);
        //Assert
        _mockservice.Verify(p => p.AddClientAsync(It.IsAny<Client>()), Times.Once);
        Assert.IsType<OkObjectResult>(result);
    }
    [Fact]
    public async Task Delete_DeleteCLientAsync_ClientIsDeleted()
    {
        //Arrange
        var client = new Client() { Id = 12 };
        _mockservice.Setup(m => m.GetClientAsync(client.Id))
            .ReturnsAsync(client);
        _mockservice.Setup(m=> m.DeleteClientAsync(client.Id))
            .ReturnsAsync(true);
        //Act
        var result = await _controller.Delete(client.Id);
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.True((bool)okResult.Value);

    }
    //put 

}
