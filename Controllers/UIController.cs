using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class UIController
    {
        private PlayerController _player;
        private UIFactory _uiFactory;
        private UIHealthText _uiHealhtText;
        private UIHealthView _uiHealHealthView;
        private UILivesText _uiLivesText;
        private UILivesView _uiLivesView;
        private BulletView _bulletView;
       
        public UIController(PlayerController playerController)
        {
            _bulletView = GameObject.FindObjectOfType<BulletView>();
            _player = playerController;
            _uiFactory = new UIFactory();
            _uiHealhtText = new UIHealthText(_uiFactory);
            _uiHealHealthView = new UIHealthView(_uiFactory,playerController.PlayerView,_player.PlayerHealthPoints, _uiHealhtText.GetRectTransform());
            _uiLivesView = new UILivesView(_uiFactory);
            _uiLivesText = new UILivesText(_uiFactory, _uiLivesView.GetRectTransform(),_player.PlayerLives);

            _bulletView.Damage += _uiHealHealthView.Damage;
        }

    }
}
