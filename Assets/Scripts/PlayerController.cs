using JoostenProductions;
using UnityEngine;

public class PlayerController : BaseController
{
    private readonly ContactsPoller _contactsPoller;
    private readonly PlayerMoveController _playerMoveController;
    private readonly PlayerJumpController _playerJumpController;

    public PlayerController(PlayerView playerView, GameModel model,
        Transform placeSpawnPlayer)
    {
        var platform = new PlatformFactory().Create(Application.platform);
        var playerViewInstance = CreateView(playerView, placeSpawnPlayer);

        _contactsPoller = new ContactsPoller(playerViewInstance.Collider);

        _playerMoveController = new PlayerMoveController(playerViewInstance, model, _contactsPoller, platform.Input);
        AddController(_playerMoveController);
        _playerJumpController = new PlayerJumpController(playerViewInstance, model, _contactsPoller, platform.Input);
        AddController(_playerJumpController);

        UpdateManager.SubscribeToFixedUpdate(FixedUpdate);
    }

    protected override void OnDispose()
    {
        UpdateManager.UnsubscribeFromFixedUpdate(FixedUpdate);
    }

    private void FixedUpdate()
    {
        _contactsPoller.FixedUpdate();
        _playerMoveController.FixedUpdate();
        _playerJumpController.FixedUpdate();
    }

    private PlayerView CreateView(PlayerView playerView, Transform placeSpawnPlayer)
    {
        var playerViewInstance = Object.Instantiate(playerView, placeSpawnPlayer);
        AddGameObject(playerViewInstance.gameObject);

        return playerViewInstance;
    }
}