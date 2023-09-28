using UnityEngine;

public class PlatformFactory
{
    private readonly InputFactory _inputFactory;

    public PlatformFactory()
    {
        _inputFactory = new InputFactory();
    }

    public IPlatform Create(RuntimePlatform platform)
    {
        return new Platform(_inputFactory.CreateInput(platform));
    }
}
