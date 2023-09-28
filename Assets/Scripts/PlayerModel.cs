public class PlayerModel
{
    public float WalkSpeed { get;}
    public float JumpForce { get; }
    public float MoveThreshold { get; }
    public float FlyThreshold { get; }

    public PlayerModel(PlayerPreset playerPreset)
    {
        WalkSpeed = playerPreset.WalkSpeed;
        JumpForce = playerPreset.JumpForce;
        MoveThreshold = playerPreset.MoveThreshold;
        FlyThreshold = playerPreset.FlyThreshold;
    }
}