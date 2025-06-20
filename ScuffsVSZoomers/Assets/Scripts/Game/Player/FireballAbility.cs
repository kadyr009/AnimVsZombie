using UnityEngine;

public class FireballAbility : AbilityBehaviour
{
    public float speed = 10f;
    public float damage = 20f;

    private Vector3 _direction;

    public void SetDirection(Vector3 dir)
    {
        _direction = dir.normalized;
    }

    public override void Activate(GameObject caster)
    {
        // Тут можно применить силу, например Rigidbody или движение вручную
        // В данном примере просто летим вперёд
    }

    void Update()
    {
        transform.position += _direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // Тут можно обработать урон
        if (other.CompareTag("Player")) return;
        
        Destroy(gameObject);
    }
}
