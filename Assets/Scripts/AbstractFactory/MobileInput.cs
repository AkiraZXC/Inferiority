using UnityEngine;

public class MobileInput : IInput
{
    public string Name => nameof(MobileInput);

    public float XAxisInput => Input.gyro.userAcceleration.x;

    public float YAxisInput => Input.gyro.userAcceleration.y;
}
