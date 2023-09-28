public class Platform : IPlatform
{
    public IInput Input { get; }

    public Platform(IInput input)
    {
        Input = input;
    }
}
