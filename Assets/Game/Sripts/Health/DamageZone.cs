using Assets.Game.Sripts.Interfaces;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int _damage = 50;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
        }
    }
}
