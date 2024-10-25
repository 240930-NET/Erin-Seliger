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
        if (player.Name != "" && player.Name != null) {
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

            if (!string.IsNullOrWhiteSpace(player.Name) && player.Name != "string" && searchedPlayer.Name != player.Name)
            {
                searchedPlayer.Name = player.Name;
            }
            if (player.GameEliminatedIn != default && searchedPlayer.GameEliminatedIn != player.GameEliminatedIn)
            {
                searchedPlayer.GameEliminatedIn = player.GameEliminatedIn;
            }
            if (player.Game1 != default && searchedPlayer.Game1 != player.Game1)
            {
                searchedPlayer.Game1 = player.Game1;
            }
            if (player.Game2 != default && searchedPlayer.Game2 != player.Game2)
            {
                searchedPlayer.Game2 = player.Game2;
            }
            if (player.Game3 != default && searchedPlayer.Game3 != player.Game3)
            {
                searchedPlayer.Game3 = player.Game3;
            }
            if (player.Game4 != default && searchedPlayer.Game4 != player.Game4)
            {
                searchedPlayer.Game4 = player.Game4;
            }
            if (player.Game5 != default && searchedPlayer.Game5 != player.Game5)
            {
                searchedPlayer.Game5 = player.Game5;
            }

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