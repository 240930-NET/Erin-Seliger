using System.Data.Common;
using Moq;
using Pinball.API.Model;
using Pinball.API.Repository;
using Pinball.API.Service;

namespace Pinball.TEST;

public class UnitTest1
{
    [Fact]
    public void GetAllPlayersReturnsProperList()
    {
        //Arrange
        Mock<IPlayerRepository> mockRepo = new();
        PlayerService playerService = new(mockRepo.Object);

        List<Player> playerList = [
            new Player {Name = "Jack"},
            new Player {},
            new Player {}
        ];

        mockRepo.Setup(repo => repo.GetAllPlayers())
            .Returns(playerList);

        //Act
        var result = playerService.GetAllPlayers();
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());
        Assert.Contains(result, e => e.Name!.Equals("Jack"));

    }

    [Fact]
    public void GetPlayerByIdReturnsProperPlayer() 
    {
        //Arrange
        Mock<IPlayerRepository> mockRepo = new();
        PlayerService playerService = new(mockRepo.Object);

        Player player = new Player {Id = 1, Name = "Kevin"};

        mockRepo.Setup(repo => repo.GetPlayerById(1))
            .Returns(player);

        //Act
        Player returnedPlayer = playerService.GetPlayerById(1);

        //Assert
        Assert.Equal(player, returnedPlayer);
    }

    [Fact]
    public void AddPlayerWithoutNameThrowsException()
    {
        //Arrange
        Mock<IPlayerRepository> mockRepo = new();
        PlayerService playerService = new(mockRepo.Object);

        Player player = new Player {};

        //Act / Assert
        Assert.Throws<Exception>(() => playerService.AddPlayer(player));
    }

    [Fact]
    public void UpdatePlayerWorksProperly()
    {
        //Arrange
        Mock<IPlayerRepository> mockRepo = new();
        PlayerService playerService = new(mockRepo.Object);

        Player player = new Player {Id = 2, Name = "Sue"};
        Player update = new Player {Id = 2, Name = "Sally", Game1 = 1};

        mockRepo.Setup(r => r.GetPlayerById(player.Id)).Returns(player);

        //Act
        var result = playerService.UpdatePlayer(update);

        //Assert
        Assert.Equal("Player updated successfully!", result);
        mockRepo.Verify(r => r.UpdatePlayer(It.Is<Player>(p => p.Name == update.Name && p.Game1 == update.Game1)), Times.Once);
    }

    [Fact]
    public void DeltePlayerWorksProperly() 
    {
        //Arrange
        Mock<IPlayerRepository> mockRepo = new();
        PlayerService playerService = new(mockRepo.Object);

        Player player = new Player { Id = 1, Name = "Billy Bob" };

        mockRepo.Setup(r => r.GetPlayerById(player.Id)).Returns(player);

        // Act
        var result = playerService.DeletePlayer(player.Id);

        // Assert
        Assert.Equal($"Player {player.Name} deleted successfully!", result);
        mockRepo.Verify(r => r.DeletePlayer(It.Is<Player>(p => p.Id == player.Id)), Times.Once);
    }
}