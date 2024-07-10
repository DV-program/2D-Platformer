using TMPro;
using UnityEngine;

namespace Assets.Game.Sripts
{
    public class KeysView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _value;
        private int _countKeys = 0;
        private int _maxCount = 4;
        public void OnEnable()
        {
            EventBus.Instance.KeyPickedUp += OnChang;
            _value.text = $"Ключей: {_countKeys}/{_maxCount}";
        }
        public void OnDisable()
        {
            EventBus.Instance.KeyPickedUp -= OnChang;
        }
        private void OnChang()
        {
            _countKeys++;
            _value.text = $"Ключей: {_countKeys}/{_maxCount}";
            if ( _countKeys >= _maxCount ) { EventBus.Instance.AllKeyPickedUp?.Invoke(); }
        }
    }
}
