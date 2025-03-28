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
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;

        public void ModifyHealth(int healDelta)
        {
            _health += healDelta;
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
    }
}

