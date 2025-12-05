using UnityEngine;

public class SplitProjectile : Projectile
{

    [Header("Split Setting")]

    [SerializeField] private float _rotationSpeed = 360f;
    [SerializeField] private bool _clockTurn = true;
    private Vector3 _moveDirection;


    public void initialize(float damage, float speed)
    {
        _damage = damage;
        _speed = speed; 
    }


    protected override void Start()
    {
        base.Start();
        _moveDirection = transform.right;

        if (Random.value > 0.5f)
        {
            _clockTurn = true;
        }
        else
        {
            _clockTurn = false;
        }
    }



    protected override void UpdateMovement()
    {
        transform.position += _moveDirection * _speed * Time.deltaTime;

        float rotAmount= _rotationSpeed * Time.deltaTime;
        if (_clockTurn)
            rotAmount *= -1;

        transform.Rotate(0,0,rotAmount);
    }

}
