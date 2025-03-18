using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class CollectCoinComponent : MonoBehaviour
    {
        [SerializeField] private string _tagSilverCoin;
        [SerializeField] private string _tagGoldCoin;
        [SerializeField] private EnterCoin _action;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tagGoldCoin))
            {
                _action?.Invoke(10);
            }
            else if (other.gameObject.CompareTag(_tagSilverCoin))
            {
                _action?.Invoke(1);
            }
        }


    }
    [Serializable]
    public class EnterCoin : UnityEvent<int>
    {

    }

}
