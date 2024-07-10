using Assets.Game.Sripts;
using Assets.Game.Sripts.Interfaces;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
	private int _value = 0;
	private int _maxValue = 100;
	public void Initialize(int value)
	{
		_value = value;
		_maxValue = value;
	}
	public void TakeDamage(int value)
	{
		if (value < 0)
			Debug.Log("������������� ����");
		_value -= value;
		if (_value <= 0) { EventBus.Instance.PlayerDied?.Invoke(); }
		EventBus.Instance.Damaged?.Invoke();
		EventBus.Instance.HealthChanged?.Invoke((float)_value/_maxValue);
	}
	public void Heal(int value)
	{
		if (value < 0)
			Debug.Log("������������� ���");
		_value += value;
		if (_value >= _maxValue)
			_value = _maxValue;
		EventBus.Instance.HealthChanged?.Invoke((float)_value/_maxValue);
	}
	public int GetMaxHealth() => _maxValue;
}
