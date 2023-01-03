using UnityEngine;
using VRSki.Scripts.Interfaces;
using VRSki.Scripts.ScriptableObjects.Sets;
using VRSki.Scripts.ScriptableObjects.Variables;

namespace VRSki.Scripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private IntVariable _winNumberLength;
        [SerializeField]
        private IntVariable _activeNumberIndex;
        [SerializeField]
        private IntVariable _activeNumberRowIndex;
        [SerializeField]
        private IntVariable _activeNumberDigit;
        [SerializeField]
        private DigitsDisplaySet _digitsDisplaySet;
        [SerializeField]
        private BoolVariable _canEvaluateVariable;

        private void OnEnable()
        {
            _activeNumberIndex.OnValueChanged += ActiveNumberIndexOnValueChanged;
            _activeNumberRowIndex.OnValueChanged += ActiveNumberRowIndexOnValueChanged;
            _activeNumberDigit.OnValueChanged += ActiveNumberDigitOnValueChanged;
            _canEvaluateVariable.OnValueChanged += CanEvaluateVariableOnValueChanged;
        }

        private void OnDisable()
        {
            _activeNumberIndex.OnValueChanged -= ActiveNumberIndexOnValueChanged;
            _activeNumberRowIndex.OnValueChanged -= ActiveNumberRowIndexOnValueChanged;
            _activeNumberDigit.OnValueChanged -= ActiveNumberDigitOnValueChanged;
            _canEvaluateVariable.OnValueChanged -= CanEvaluateVariableOnValueChanged;
        }

        private void CanEvaluateVariableOnValueChanged(bool canEvaluate)
        {
            if (canEvaluate)
            {
                _digitsDisplaySet.DeselectAll();
            }
        }

        private void ActiveNumberDigitOnValueChanged(int newDigit)
        {
            IDigitDisplay digitDisplay = _digitsDisplaySet.GetDigitDisplay(_activeNumberRowIndex.Value, _activeNumberIndex.Value);
            
            if (digitDisplay != null)
            {
                digitDisplay.SetDigit(newDigit);
            }

            if (_activeNumberIndex.Value == _winNumberLength.Value - 1)
            {
                _canEvaluateVariable.SetValue(true);
                return;
            }

            _activeNumberIndex.SetValue(_activeNumberIndex.Value + 1);
        }

        private void ActiveNumberRowIndexOnValueChanged(int newRowIndex)
        {
            _activeNumberIndex.SetValue(0);
            _canEvaluateVariable.SetValue(false);
        }

        private void ActiveNumberIndexOnValueChanged(int newIndex)
        {
            IDigitDisplay digitDisplay = _digitsDisplaySet.GetDigitDisplay(_activeNumberRowIndex.Value, _activeNumberIndex.Value);

            if (digitDisplay != null)
            {
                _digitsDisplaySet.Select(digitDisplay);
            }
        }

        private void Start()
        {
            _activeNumberRowIndex.SetValue(0);
        }
    }
}