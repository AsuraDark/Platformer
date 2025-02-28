using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components
{
    public class CollectCoinComponent : MonoBehaviour
    {
        private int _countMoney = 0;
        [SerializeField] private string _tagSilverCoin;
        [SerializeField] private string _tagGoldCoin;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tagGoldCoin))
            {
                _countMoney += 10;
                Debug.Log(_countMoney);
            }
            else if (other.gameObject.CompareTag(_tagSilverCoin))
            {
                _countMoney += 1;
                Debug.Log(_countMoney);
            }
        }

    }

}
