using UnityEngine;

namespace Patterns.StructuralPatterns.Flyweight
{
    // 공유하는 데이터
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Patterns/Structrual/Flyweight/Weapon")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private string weaponName;
        [SerializeField] private int strength;
        [SerializeField] private Sprite icon;
        [SerializeField] private AudioClip attackSfx;
        // ...

        public string WeaponName => weaponName;
        public int Strength => strength;
        public Sprite Icon => icon;
        public AudioClip AttackSfx => attackSfx;
        // ...
    }
}