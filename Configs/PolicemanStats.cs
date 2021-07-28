using UnityEngine;

namespace PlatformerMVC
{
    [CreateAssetMenu (fileName = "PolicemanStats", menuName ="UnitStats/Policeman")]
    public class PolicemanStats : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private int _healhPoints;

        public float Speed => _speed;
        public int Damage => _damage;
        public int HealthPoints => _healhPoints;
    }
}