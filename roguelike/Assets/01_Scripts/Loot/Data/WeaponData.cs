using UnityEngine;
/// <summary>
/// 무기 전용 데이터 (ScriptableObject)
/// </summary>
[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Scriptable Objects/Equipment/Weapon Data")]
public class WeaponData : EquipmentData
{
    [Header("Weapon Stats")]
    [SerializeField] private GameObject _prefab; // 무기 프리팹 (Weapon 컴포넌트가 붙어있어야 함)
    [SerializeField] private GameObject _projectilePrefab; // 투사체 프리팹 (Projectile 컴포넌트가 붙어있어야 함)
    [SerializeField] private float _baseDamage = 10f;
    [SerializeField] private float _baseCooldown = 1f;
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private int _penetration = 1;
    
    public GameObject Prefab => _prefab;
    public GameObject ProjectilePrefab => _projectilePrefab;
    public float BaseDamage => _baseDamage;
    public float BaseCooldown => _baseCooldown;
    public float ProjectileSpeed => _projectileSpeed;
    public int Penetration => _penetration;
}