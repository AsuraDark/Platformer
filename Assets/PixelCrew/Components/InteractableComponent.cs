using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class InteractableComponent : MonoBehaviour
    {
        [SerializeField] UnityEvent _action;

        public void Interact()
        {
            _action?.Invoke();
        }
    }
}

