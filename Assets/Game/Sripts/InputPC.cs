using Assets.Game.Interfaces;
using UnityEngine;
namespace Assets.Game.Sripts
{
    public class InputPC : IInput
    {
        public Vector2 InputRegister()
        {
            float horizontalMove = Input.GetAxis("Horizontal");
            int jumpIsPress = Input.GetKeyDown(KeyCode.W) ? 1: 0;
            return new Vector2(horizontalMove, jumpIsPress);
        }
    }
}
