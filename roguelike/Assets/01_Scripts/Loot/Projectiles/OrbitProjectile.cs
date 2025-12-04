using UnityEngine;

public class OrbitProjectile : Projectile
{


    public void initialize(float damage)
    {
        _damage = damage; 
    }


    protected override void Start()
    {
        
    }
    protected override void UpdateMovement()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Monster monster = other.GetComponent<Monster>();
            Debug.Log($"때린 놈: {other.name} / 데미지 수치: {_damage}");
            monster.TakeDamage(_damage);
        }
    }
}
