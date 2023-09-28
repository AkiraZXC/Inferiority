using UnityEngine;

public class PlayerMoveController : BaseController
{
    private readonly PlayerView _view;
    private readonly PlayerModel _model;
    private readonly ContactsPoller _contactsPoller;
    private readonly IInput _input;

    public PlayerMoveController(PlayerView view, GameModel model, 
        ContactsPoller contactsPoller, IInput input)
    {
        _view = view;
        _model = model.CurrentPlayer;
        _contactsPoller = contactsPoller;
        _input = input;
    }

    public void FixedUpdate()
    {
        var xAxisInput = _input.XAxisInput;
        var isGoSideWay = Mathf.Abs(xAxisInput) > _model.MoveThreshold;

        if (isGoSideWay)
            _view.SpriteRenderer.flipX = xAxisInput > 0;

        var newVelocity = 0f;

        if (isGoSideWay &&
            (xAxisInput > 0 || !_contactsPoller.HasLeftContacts) &&
            (xAxisInput < 0 || !_contactsPoller.HasRightContacts))
        {
            newVelocity = Time.fixedDeltaTime * _model.WalkSpeed * (xAxisInput < 0 ? -1 : 1);
        }

        _view.Rigidbody.velocity = new Vector2(newVelocity, _view.Rigidbody.velocity.y);
    }
}