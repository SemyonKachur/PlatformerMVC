using UnityEngine;
using System;
using System.Linq;

namespace PlatformerMVC
{

    public class CoinController
    {
        private CoinKeeper[] _coins;
        private bool _isCoinsCollected = false;

        public bool IsCoinCollected => _isCoinsCollected;
        public event Action<bool> AllCoinCollected = delegate (bool isCoinColledted) { };
        public CoinController()
        {
            _coins = GameObject.FindObjectsOfType<CoinKeeper>();
            for (int i = 0; i < _coins.Length; i++)
            {
                _coins[i].CoinContact += CoinContact;
            }
        }
        private void CoinContact(GameObject gameObject)
        {
            gameObject.SetActive(false);
            if (_coins.All(value => value.IsDone)==true)
            {
                _isCoinsCollected = true;
                AllCoinCollected.Invoke(_isCoinsCollected);
            }
        }
    }
}
