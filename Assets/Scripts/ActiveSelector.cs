using UnityEngine;
using VRSki.Scripts.Interfaces;

namespace VRSki.Scripts
{
    public class ActiveSelector : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _meshRenderer;
        [SerializeField]
        private Material _activeMaterial;
        [SerializeField]
        private Material _normalMaterial;

        private IDigitDisplay _digitDisplay;

        private void OnEnable()
        {
            if (TryGetComponent(out _digitDisplay))
            {
                _digitDisplay.OnSelect += DigitDisplayOnSelect;
                _digitDisplay.OnDeselect += DigitDisplayOnDeselect;
            }
        }

        private void OnDisable()
        {
            if (_digitDisplay != null)
            {
                _digitDisplay.OnSelect -= DigitDisplayOnSelect;
                _digitDisplay.OnDeselect -= DigitDisplayOnDeselect;
            }
        }

        private void DigitDisplayOnDeselect()
        {
            _meshRenderer.material = _normalMaterial;
        }

        private void DigitDisplayOnSelect()
        {
            _meshRenderer.material = _activeMaterial;
        }
    }
}