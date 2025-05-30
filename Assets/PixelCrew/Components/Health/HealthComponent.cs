﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace PixelCrew.Components.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] public UnityEvent _onDie;
        [SerializeField] private HealthChangeEvent _onChange;

        public void ModifyHealth(int healDelta)
        {
            if (_health <= 0) return;

            _health += healDelta;
            _onChange?.Invoke(_health);
            if(healDelta < 0)
            {
                _onDamage?.Invoke();
            }
            else if (healDelta > 0)
            {
                _onHeal?.Invoke();
            }
            if(_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
        public void SetHealth(int health)
        {
            _health = health;
        }

        [Serializable]
        public class HealthChangeEvent : UnityEvent<int>
        {

        }
    }
}

