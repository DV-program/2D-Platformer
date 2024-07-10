using Assets.Game.Interfaces;
using UnityEngine;
namespace Assets.Game.Sripts
{
    public class InputPC : MonoBehaviour, IInput
    {
        private void Update()
        {
            EventBus.Instance.ButtonsRegistred?.Invoke(InputRegister());
            EventBus.Instance.Update?.Invoke();
        }
        private void FixedUpdate() => EventBus.Instance.FixedUpdate?.Invoke();
        private Vector2 InputRegister()
        {
            float horizontalMove = Input.GetAxis("Horizontal");
            int jumpIsPress = Input.GetKeyDown(KeyCode.W) ? 1: 0;
            return new Vector2(horizontalMove, jumpIsPress);
        }
    }
}
