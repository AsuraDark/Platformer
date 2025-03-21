using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class ChangeJumpComponent : MonoBehaviour
    {
        [SerializeField] private float _value;
        [SerializeField] private float _duration;
        [SerializeField] private EnterJunp _action;
        private float _startTime;
        private bool _isUsed = false;
        public void ChangeJump()
        {
            _action.Invoke(_value);
            _startTime = Time.time;
            _isUsed = true;
        }

        public void Update()
        {
            if (_isUsed && (Time.time > _startTime + _duration))
            {
                _action.Invoke(1 / _value);
                _isUsed = false;
            }
        }
    }
    [Serializable]
    public class EnterJunp : UnityEvent<float>
    {

    }
}


