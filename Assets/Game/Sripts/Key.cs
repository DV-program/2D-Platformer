using UnityEngine;

namespace Assets.Game.Sripts
{
    public class Key : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) 
            {
                EventBus.Instance.KeyPickedUp?.Invoke();
                Destroy(this.gameObject); 
            }
        }
    }
}
