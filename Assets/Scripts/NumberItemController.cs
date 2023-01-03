using System;
using UnityEngine;
using VRSki.Scripts.Interfaces;
using VRSki.Scripts.ScriptableObjects.Variables;

namespace VRSki.Scripts
{

    public class NumberItemController : MonoBehaviour, IDigitDisplay
    {
        public event Action OnSelect;
        public event Action OnDeselect;
        public event Action<int> OnSetDigit;

        public int X => _x;
        public int Y => _y;

        [SerializeField]
        private IntVariable _winNumberLength;

        private int _x;
        private int _y;

        private bool _isActive;

        public void SetXY(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Select()
        {
            _isActive = true;
            OnSelect?.Invoke();
        }

        public void Deselect()
        {
            _isActive = false;
            OnDeselect?.Invoke();
        }

        public void SetDigit(int digit)
        {
            OnSetDigit?.Invoke(digit);
        }
    }
}