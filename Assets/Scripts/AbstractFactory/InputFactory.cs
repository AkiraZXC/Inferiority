using System;
using UnityEngine;

public class InputFactory
{
    public IInput CreateInput(RuntimePlatform platform)
    {
        switch (platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                return new PCInput();

            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                return new MobileInput();

            default:
                throw new ArgumentOutOfRangeException(nameof(platform));
        }
    }
}
