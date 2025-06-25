using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientData.Domain.Repositories; 
using ClientData.Domain.Models;
using ClientData.Application.Services;
using Moq;
using Xunit;
using ClientData.Domain.Exceptions;

namespace ClientData.Application.Tests.Services;

public class ClientDataServiceTests
{
    /*    
    public async Task<Client> AddClientAsync(Client client)
    {
        return await _repository.AddClientAsync(client);
    }
    */
    [Fact]
    public async Task AddClientAsync_ShouldReturnAddedClient()
    {
        // Arrange
        var client = new Client {
            Id = 25,
            Username = "Martin",
            Email = "Password",
            PasswordHash = "Email"
        };  
        var mockRepository = new Mock<IRepository>();
        mockRepository.Setup(m => m.AddClientAsync(It.IsAny<Client>()))
            .ReturnsAsync((Client c) => c);
        var service = new ClientDataService(mockRepository.Object);
        //Act 
        var actual = await service.AddClientAsync(client);
        //Assert
        Assert.Equal(client, actual);
        mockRepository.Verify(m => m.AddClientAsync(client), Times.Once());
    }
    /*
    public async Task<bool> DeleteClientAsync(int id)
    {
        return await _repository.DeleteClientAsync(id);
    }
     */
    [Fact]
    public async Task DeleteClientAsync_shouldRemoveClient()
    {
        //Arrange
        var client = new Client
        {
            Id = 25,
            Username = "Martin",
            Email = "Password",
            PasswordHash = "Email"
        };
        var mockRepository = new Mock<IRepository>();
        mockRepository.Setup(m => m.DeleteClientAsync(It.IsAny<int>()))
            .ReturnsAsync(true);
        var service = new ClientDataService(mockRepository.Object);
        //Act
        var actual = await service.DeleteClientAsync(client.Id);
        //Assert
        Assert.True(actual); 
        mockRepository.Verify(m=> m.DeleteClientAsync(client.Id), Times.Once());

    }
    

    [Fact]
    public async Task GetClientAsync_ShouldReturnExpected()
    {
        //Arrange
        var client = new Client {
        Id = 24,
        Username = "Alice",
        Email = "alice@email.com",
        PasswordHash = "hash#ed"
        };
        var mockRepository = new Mock<IRepository>();
        mockRepository.Setup(m => m.GetClientAsync(It.IsAny<int>())) //i provide an id 
            .ReturnsAsync(client); //return a client --> Task<Client> GetClientAsync
        var service = new ClientDataService(mockRepository.Object);

        //Act
        var actual = await service.GetClientAsync(client.Id);
        //Assert
        Assert.Equal(client, actual);
        mockRepository.Verify(m => m.GetClientAsync(client.Id), Times.Once());

    }


    [Fact]
    public async Task GetClientAsync_ClientDoesNotExist_ShouldReturnNull()
    {
        //Arrange

        var client = new Client() { Id = 33 };
        var mockRepository = new Mock<IRepository>();
        mockRepository.Setup(m => m.GetClientAsync(client.Id))
            .ReturnsAsync((Client)null); //client's not found
        var service = new ClientDataService(mockRepository.Object);

        //Act
        var actual = await service.GetClientAsync(client.Id);
        //Assert
        Assert.Null(actual);
        mockRepository.Verify(m => m.GetClientAsync(client.Id), Times.Once());
    }
    [Fact]
    public async Task GetAllClientsAsync_ShouldReturnList()
    {
        //Arrange
        var list = new List<Client>() {
            new Client() { Id = 21, Username = "Martha" },
            new Client() { Id = 22, Username = "Tabitha"},
            new Client() { Id = 23, Username = "Betty"},
            new Client() { Id = 24, Username = "Bettany"}
        };
        var mockRepository = new Mock<IRepository>();
        mockRepository.Setup(m => m.GetAllClientsAsync())
            .ReturnsAsync(list);
        var service = new ClientDataService(mockRepository.Object);
        //Act
        var actual = await service.GetAllClientsAsync();
        Assert.Equal(list, actual);
    }
    [Fact]
    public async Task GetAllClientsAsync_EmptyListException_IsThrown()
    {
        // Arrange
        var mockRepository = new Mock<IRepository>();
        mockRepository.Setup(r => r.GetAllClientsAsync())
                      .ReturnsAsync(new List<Client>()); 

        var service = new ClientDataService(mockRepository.Object);

        // Act & Assert
        await Assert.ThrowsAsync<EmptyListException>(() => service.GetAllClientsAsync());
    }
    [Fact]
    public async Task GetAllClientsAsync_ShouldThrowEmptyListException_NullList()
    {
        // Arrange
        var mockRepository = new Mock<IRepository>();
        var expectedClients = new List<Client>
        {
            new Client { Id = 1, Username = "Alice" },
            new Client { Id = 2, Username = "Bob" }
        };
        mockRepository.Setup(r => r.GetAllClientsAsync())
                      .ReturnsAsync((List<Client>)null); // Null list

        var service = new ClientDataService(mockRepository.Object);

        // Act & Assert
        await Assert.ThrowsAsync<EmptyListException>(() => service.GetAllClientsAsync());
    }

}
