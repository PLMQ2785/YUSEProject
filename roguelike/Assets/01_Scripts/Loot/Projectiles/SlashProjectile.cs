using UnityEngine;

public class SlashProjectile :Projectile
{
    private float _duration;

    public void Initialize(float damage, float duration)
    {

        _duration = duration;
        _damage = damage;
    }


    protected override void Start()
    {
        Destroy(gameObject, _duration);
    }
    protected override void UpdateMovement()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Monster monster = other.GetComponent<Monster>();
            monster.TakeDamage(_damage);
        }
    }
}
