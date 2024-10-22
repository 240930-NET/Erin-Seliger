using Pinball.API.Model;

namespace Pinball.API.Repository;

public interface IPlayerRepository {

    public IEnumerable<Player> GetAllPlayers();

}