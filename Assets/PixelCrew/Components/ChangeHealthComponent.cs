using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components
{
    public class ChangeHealthComponent : MonoBehaviour
    {
        [SerializeField] private bool _isDamage;
        [SerializeField] private int _value;

        public void ChangeHealth(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.ChangeHealth(_value, _isDamage);
            }
        }
    }
}


