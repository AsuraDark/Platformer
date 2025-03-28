using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components
{
    public class SpawnCoinComponent : MonoBehaviour
    {
        [SerializeField] private float _dropRateSilverCoin;
        [SerializeField] private float _dropRateGoldenCoin;
        [SerializeField] private int _countCoins;
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefabSilverCoin;
        [SerializeField] private GameObject _prefabGoldenCoin;

        public void SpawnCoin()
        {
            for (int i = 0; i < _countCoins; i++)
            {
                var rate = Random.value;
                if (_dropRateSilverCoin > _dropRateGoldenCoin)
                {
                    if (rate < _dropRateSilverCoin)
                    {
                        var instantiate = Instantiate(_prefabSilverCoin, _target.position, Quaternion.identity);
                        instantiate.transform.localScale = _target.lossyScale;
                        _target.position = new Vector3(_target.position.x + 0.5f, _target.position.y, _target.position.z);
                    }
                    else
                    {
                        var instantiate = Instantiate(_prefabGoldenCoin, _target.position, Quaternion.identity);
                        instantiate.transform.localScale = _target.lossyScale;
                        _target.position = new Vector3(_target.position.x + 0.5f, _target.position.y, _target.position.z);
                    }
                }
                else
                {
                    if (rate < _dropRateGoldenCoin)
                    {
                        var instantiate = Instantiate(_prefabGoldenCoin, _target.position, Quaternion.identity);
                        instantiate.transform.localScale = _target.lossyScale;
                        _target.position = new Vector3(_target.position.x + 0.5f, _target.position.y, _target.position.z);
                    }
                    else
                    {
                        var instantiate = Instantiate(_prefabSilverCoin, _target.position, Quaternion.identity);
                        instantiate.transform.localScale = _target.lossyScale;
                        _target.position = new Vector3(_target.position.x + 0.5f, _target.position.y, _target.position.z);
                    }
                }

            }
        }
    }
}

