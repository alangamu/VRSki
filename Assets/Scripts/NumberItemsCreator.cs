using UnityEngine;
using VRSki.Scripts.Interfaces;
using VRSki.Scripts.ScriptableObjects.Sets;
using VRSki.Scripts.ScriptableObjects.Variables;

namespace Assets.Scripts
{
    public class NumberItemsCreator : MonoBehaviour
    {
        [SerializeField]
        private float _displaySize;
        [SerializeField]
        private float _xSeparation;
        [SerializeField]
        private float _ySeparation;
        [SerializeField]
        private IntVariable _winNumberLength;
        [SerializeField]
        private IntVariable _opportunitiesVariable;
        [SerializeField]
        private GameObject _digitDisplayPrefab;
        [SerializeField]
        private GameObject _rowButtonsDisplayPrefab;
        [SerializeField]
        private DigitsDisplaySet _digitsDisplaySet;

        private void Start()
        {
            int winNumberLength = _winNumberLength.Value;
            int opportunities = _opportunitiesVariable.Value;

            for (int i = 0; i < opportunities; i++)
            {
                GameObject rowButtonsDisplay = Instantiate(_rowButtonsDisplayPrefab, transform);
                for (int j = 0; j < winNumberLength; j++)
                {
                    IDigitDisplay digitDisplay;
                    GameObject digitalDisplayObject = Instantiate(_digitDisplayPrefab, rowButtonsDisplay.transform);
                    digitalDisplayObject.name = $"Display {j}_{i}";
                    if (digitalDisplayObject.TryGetComponent(out digitDisplay))
                    {
                        digitDisplay.SetXY(j, i);
                        _digitsDisplaySet.Add(digitDisplay);
                    }
                }
            }
        }
    }
}