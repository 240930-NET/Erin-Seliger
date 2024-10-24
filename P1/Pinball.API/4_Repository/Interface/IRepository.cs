using Pinball.API.Model;

namespace Pinball.API.Repository;

public interface IPlayerRepository {

    public IEnumerable<Player> GetAllPlayers();

    public Player GetPlayerById(int id);

    public void AddPlayer(Player player);

    public void UpdatePlayer(Player player);

    public void DeletePlayer(Player player);

}