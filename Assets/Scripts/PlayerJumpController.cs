using UnityEngine;

public class PlayerJumpController : BaseController
{
    private readonly PlayerView _view;
    private readonly PlayerModel _model;
    private readonly ContactsPoller _contactsPoller;
    private readonly IInput _input;
    
    public PlayerJumpController(PlayerView view, GameModel model, 
        ContactsPoller contactsPoller, IInput input)
    { 
        _view = view;
        _model = model.CurrentPlayer;
        _contactsPoller = contactsPoller;
        _input = input;
    }

    public void FixedUpdate()
    {
        var doJump = _input.YAxisInput > 0;
        var isFly = Mathf.Abs(_view.Rigidbody.velocity.y) > _model.FlyThreshold;

        if (_contactsPoller.IsGrounded && doJump && !isFly)
        {
            _view.Rigidbody.velocity = new Vector2(_view.Rigidbody.velocity.x, _model.JumpForce);
        }
    }
}