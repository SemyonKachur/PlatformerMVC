using UnityEngine;

namespace PlatformerMVC
{

    public class CoinController
    {
        private CoinKeeper[] _coins;
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
        }
    }
}
