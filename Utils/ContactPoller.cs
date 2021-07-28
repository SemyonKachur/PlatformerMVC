using UnityEngine;

namespace PlatformerMVC
{
    public class ContactPoller 
    {
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];

        private const float _colliderTreshold = 0.6f;
        private int _contactCount;
        private Collider2D _collider2D;

        public bool isGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        public ContactPoller(Collider2D collider)
        {
            _collider2D = collider;
        }

        public void Update()
        {
            isGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            _contactCount = _collider2D.GetContacts(_contacts);
            for (int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].normal.y > _colliderTreshold) isGrounded = true;
                if (_contacts[i].normal.x > _colliderTreshold) HasLeftContact = true;
                if (_contacts[i].normal.x > -_colliderTreshold) HasRightContact = true;
            }
        }
    }
}
