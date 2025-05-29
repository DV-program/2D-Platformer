using System;
using TMPro;
using UnityEngine;

namespace Assets.Game.Sripts.Key
{
    public class KeysView : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _value;
        [SerializeField, Range(1, 100)] 
        private int _maxCount;
        private KeyModel _keyModel;

        private void OnEnable()
        {
            _keyModel = new(_maxCount);
            _keyModel.OnKeyCountChanged += UpdateView;
            UpdateView(_keyModel.CountKeys, _keyModel.MaxCount);
        }

        private void OnDisable()
        {
            _keyModel.OnKeyCountChanged -= UpdateView;
            _keyModel.Unsubscribe();
        }

        private void UpdateView(int count, int max)
        {
            _value.text = $"Ключей: {count}/{max}";
        }
    }
    
}
