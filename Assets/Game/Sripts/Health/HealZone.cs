using Assets.Game.Sripts.Interfaces;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    [SerializeField] private int _heal = 50;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Heal(_heal);
            Destroy(gameObject);
        }
    }
}
