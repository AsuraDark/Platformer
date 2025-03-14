using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;

        public void ChangeHealth(int Value, bool isDamage)
        {
            if(isDamage)
            {
                _health -= Value;
                _onDamage?.Invoke();
            }
            else
            {
                _health += Value;
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
    }
}

