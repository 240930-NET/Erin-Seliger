using Pinball.API.Data;
using Pinball.API.Model;

namespace Pinball.API.Repository;

public class PlayerRepository : IPlayerRepository {

    private readonly PinballContext _playerContext;

    public PlayerRepository(PinballContext playerContext) => _playerContext = playerContext;

    public IEnumerable<Player> GetAllPlayers() {
        return _playerContext.Players.ToList();
    }

    public Player GetPlayerById(int id) {
        return _playerContext.Players.Find(id)!;
    }

    public void AddPlayer(Player player) {
        _playerContext.Add(player);
        _playerContext.SaveChanges();
    }

    public void UpdatePlayer(Player player) {
        _playerContext.Update(player);
        _playerContext.SaveChanges();
    }

    public void DeletePlayer(Player player) {
        _playerContext.Remove(player);
        _playerContext.SaveChanges();
    }
    
}