using System;
using UnityEngine;

namespace PlatformerMVC
{
    public class QuestController
    {
        private CoinController _coinController;
        private PlayerController _playerController;

        private bool _isCoinCollected = false;
        private bool _isDoorOpened = false;
        private bool _isDoubleJumpLearned = false;

        public bool IsCoinCollected => _isCoinCollected;
        public bool IsDoorOpened => _isDoorOpened;
        public bool IsDoubleJumpLearned => _isDoubleJumpLearned;

        public QuestController(CoinController coinController, PlayerController playerController)
        {
            _coinController = coinController;
            _playerController = playerController;
            _coinController.AllCoinCollected += CoinsCollected;
        }

        public void CoinsCollected(bool isCoinsCollected)
        {
            _isCoinCollected = isCoinsCollected;
        }
    }
}
