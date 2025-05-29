using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Sripts.Health
{
	public class HealthView : MonoBehaviour
	{
		private float _maxHealth;
		private Slider _slider;
		public void OnEnable()
		{
			_slider = GetComponent<Slider>();
			EventBus.Instance.HealthChanged += OnChanged;
			_slider.value = 1;
		}
		public void OnDisable()
		{
			EventBus.Instance.HealthChanged -= OnChanged;
		}
		private void OnChanged(float value)
		{
			_slider.value = value;
		}
	}
}
