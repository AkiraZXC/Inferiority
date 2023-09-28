using UnityEngine;

public class ContactsPoller
{
    private const float CollisionThreshold = 0.5f;

    private readonly ContactPoint2D[] _contacts = new ContactPoint2D[10];

    private int _contactsCount;
    private readonly Collider2D _collider;

    public bool IsGrounded { get; private set; }
    public bool HasLeftContacts { get; private set; }
    public bool HasRightContacts { get; private set; }

    public ContactsPoller(Collider2D collider)
    {
        _collider = collider;
    }

    public void FixedUpdate()
    {
        IsGrounded = false;
        HasLeftContacts = false;
        HasRightContacts = false;

        _contactsCount = _collider.GetContacts(_contacts);

        for (var i = 0; i < _contactsCount; i++)
        {
            var normal = _contacts[i].normal;

            if (normal.y > CollisionThreshold)
                IsGrounded = true;

            switch (normal.x)
            {
                case > CollisionThreshold:
                    HasLeftContacts = true;
                    break;
                case < -CollisionThreshold:
                    HasRightContacts = true;
                    break;
            }
        }
    }
}