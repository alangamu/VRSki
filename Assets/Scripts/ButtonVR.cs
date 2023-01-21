using UnityEngine;
using UnityEngine.Events;

namespace VRSki.Scripts
{
    public class ButtonVR : MonoBehaviour
    {
        [SerializeField]
        private GameObject _button;
        [SerializeField]
        private UnityEvent _onPress;
        [SerializeField]
        private UnityEvent _onRelease;

        private GameObject _presser;
        private bool _isPressed;

        private void Start()
        {
            _isPressed = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                if (!_isPressed)
                {
                    print($"{other.gameObject.transform.name} enter");
                    _button.transform.localPosition= new Vector3(0,0,-0.03f);
                    _presser = other.gameObject;
                    _onPress.Invoke();
                    _isPressed = true;
                }
            }
        }

        private void OnTriggerExit(Collider other) 
        { 
            if (other.gameObject == _presser)
            {
                print($"{other.gameObject.transform.name} exit");
                _button.transform.localPosition = Vector3.zero;
                _onRelease.Invoke();
                _isPressed = false;
            } 
        }
    }
}