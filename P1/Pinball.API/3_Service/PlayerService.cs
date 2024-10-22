using Pinball.API.Model;
using Pinball.API.Repository;

namespace Pinball.API.Service;

public class PlayerService : IPlayerService {

    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository) => _playerRepository = playerRepository;

    public IEnumerable<Player> GetAllPlayers() {
        return _playerRepository.GetAllPlayers();
    }
}