using Pinball.API.Data;
using Pinball.API.Model;

namespace Pinball.API.Repository;

public class PlayerRepository : IPlayerRepository {

    private readonly PinballContext _playerContext;

    public PlayerRepository(PinballContext playerContext) => _playerContext = playerContext;

    public IEnumerable<Player> GetAllPlayers() {
        return _playerContext.Players.ToList();
    }
    
}