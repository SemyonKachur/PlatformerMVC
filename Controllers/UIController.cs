using UnityEngine;

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

       
        public UIController(PlayerController playerController)
        {
            _player = playerController;
            _uiFactory = new UIFactory();
            _uiLivesView = new UILivesView(_uiFactory);
            _uiLivesText = new UILivesText(_uiFactory, _uiLivesView.GetRectTransform(), _player.PlayerLives);
            _uiHealhtText = new UIHealthText(_uiFactory);
            _uiHealHealthView = new UIHealthView(_uiFactory,playerController.PlayerView,_player.PlayerHealthPoints, _uiHealhtText.GetRectTransform());

            _player.PlayerView.PlayerHP += PlayerHP;
        }

        private void PlayerHP(int healthPoints, int lives)
        {
            _uiHealHealthView.Update(healthPoints);
            _uiLivesText.Update(lives);
        }

    }
}
