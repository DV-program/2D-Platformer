using UnityEngine;

namespace Assets.Game.Sripts
{
    public class DoorIn : MonoBehaviour
    {
        private bool _isCollected = false;
        private Animator _animatorDoor;
        public void OnEnable()
        {
            EventBus.Instance.AllKeyPickedUp += OnCollect;
            _animatorDoor = GetComponent<Animator>();
        }
        public void OnDisable()
        {
            EventBus.Instance.AllKeyPickedUp -= OnCollect;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && _isCollected)
            {
                EventBus.Instance.PlayerEntering?.Invoke();
            }
        }
        private void OnCollect()
        {
            _isCollected = true;
            _animatorDoor.SetBool("IsCollected", _isCollected);
        }
    }
}
