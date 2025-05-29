using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Sripts.Key
{
    public class KeyModel
    {
        private int _maxCount;
        private int _countKeys = 0;
        public int CountKeys => _countKeys;
        public int MaxCount => _maxCount;
        public event Action<int, int> OnKeyCountChanged;

        public KeyModel(int maxCount)
        {
            _maxCount = maxCount;
            EventBus.Instance.KeyPickedUp += PickUpKey;
        }
        public void PickUpKey()
        {
            if (_countKeys >= _maxCount)
                return;

            _countKeys++;
            OnKeyCountChanged?.Invoke(_countKeys, _maxCount);
            if (_countKeys >= _maxCount)
            {
                EventBus.Instance.AllKeyPickedUp?.Invoke();
            }
        }
        public void Unsubscribe()
        {
            EventBus.Instance.KeyPickedUp -= PickUpKey;
        }
    }
}
