using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPreset",
    menuName = "ScriptableObjects/PlayerPreset")]
public class PlayerPreset : ScriptableObject
{
    [SerializeField]
    private float _walkSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _moveThreshold;
    [SerializeField]
    private float _flyThreshold;
    
    public float WalkSpeed => _walkSpeed;
    public float JumpForce => _jumpForce;
    public float MoveThreshold => _moveThreshold;
    public float FlyThreshold => _flyThreshold;
}