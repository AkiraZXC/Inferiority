using UnityEngine;

public class PCInput : IInput
{
    public string Name => nameof(PCInput);

    public float XAxisInput => Input.GetAxis(Consts.Horizontal);

    public float YAxisInput => Input.GetAxis(Consts.Vertical);
}
