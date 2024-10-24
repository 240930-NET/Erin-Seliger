using Pinball.API.Model;
using Pinball.API.Repository;

namespace Pinball.API.Service;

public class PlayerService : IPlayerService {

    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository) => _playerRepository = playerRepository;

    public IEnumerable<Player> GetAllPlayers() {
        return _playerRepository.GetAllPlayers();
    }

    public Player GetPlayerById(int id) {

        Player player = _playerRepository.GetPlayerById(id);
        if(player != null) {
            return player;
        }
        else {
            throw new Exception($"There is no player with id: {id}");
        }
    }

    public string AddPlayer(Player player) {
        if (player.Name != "") {
            _playerRepository.AddPlayer(player);
            return $"Player {player.Name} added successfully!";
        }
        else {
            throw new Exception("Player must have a name");
        }

    }

    public string UpdatePlayer(Player player) {
        Player searchedPlayer = _playerRepository.GetPlayerById(player.Id);
        if (searchedPlayer != null) {

            searchedPlayer.Name = player.Name;
            searchedPlayer.GameEliminatedIn = player.GameEliminatedIn;
            searchedPlayer.Game1 = player.Game1;
            searchedPlayer.Game2 = player.Game2;
            searchedPlayer.Game3 = player.Game3;
            searchedPlayer.Game4 = player.Game4;
            searchedPlayer.Game5 = player.Game5;

            _playerRepository.UpdatePlayer(searchedPlayer);
            return "Player updated successfully!";
        }
        else {
            throw new Exception("Player does not exist");
        }
    }

    public string DeletePlayer(int id) {
        Player searchedPlayer = _playerRepository.GetPlayerById(id);
        if (searchedPlayer != null) {
            _playerRepository.DeletePlayer(searchedPlayer);
            return $"Player {searchedPlayer.Name} deleted successfully!";
        }
        else {
            throw new Exception($"Player with id: {id} does not exist");
        }
    }
}