using Assets.Game.Interfaces;
using Assets.Game.Sripts;
using UnityEngine;

public class UpdateProvider : MonoBehaviour
{
	private IInput _input;
	public void Initialize(IInput input) => _input = input;
	private void Update()
		{
			EventBus.Instance.ButtonsRegistred?.Invoke(_input.InputRegister());
			EventBus.Instance.Update?.Invoke();
		}
	private void FixedUpdate() => EventBus.Instance.FixedUpdate?.Invoke();
}