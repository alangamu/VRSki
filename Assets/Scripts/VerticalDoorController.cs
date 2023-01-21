using UnityEngine;
using VRSki.Scripts.ScriptableObjects.Events;

namespace VRSki.Scripts
{
    public class VerticalDoorController : MonoBehaviour
    {
        [SerializeField]
        private Transform _doorTransform;
        [SerializeField]
        private GameEvent _openDoorEvent;
        [SerializeField]
        private float _openDistance = 1f;

        private bool _isOpen;

        private void OnEnable()
        {
            _isOpen = false;
            _openDoorEvent.OnRaise += OpenDoor;
        }

        private void OnDisable()
        {
            _openDoorEvent.OnRaise -= OpenDoor;
        }

        private void OpenDoor()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                LeanTween.moveLocalY(_doorTransform.gameObject, _openDistance, 1f);
            }
        }
    }
}