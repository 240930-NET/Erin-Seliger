using Pinball.API.Model;

namespace Pinball.API.Service;

public interface IPlayerService {
    public IEnumerable<Player> GetAllPlayers();

    public Player GetPlayerById(int id);

    public string AddPlayer(Player player);

    public string UpdatePlayer(Player player);

    public string DeletePlayer(int id);

}