using Pinball.API.Model;

namespace Pinball.API.Service;

public interface IPlayerService {
    public IEnumerable<Player> GetAllPlayers();
    
}