using System;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Views
{
    public class CardsView : MonoBehaviour
    {
        public event Action<string> OnCardClicked;
        public event Action OnNewLevelReached;

        
        [SerializeField] CardView _cardViewPrefab;
        [SerializeField] Transform _cardsContainer;
        [SerializeField] TextMeshProUGUI _rightCardText;
        
        public void CreateCard(Sprite sprite, string cardID)
        {
            var card = Instantiate(_cardViewPrefab, _cardsContainer);

            card.OnCardClicked += OnCardClicked;
            OnNewLevelReached += card.ClearSprite;
            
            card.Draw(sprite);
            card.GetCardName(cardID);
        }
        
        public void DrawRightCardText(string text)
        {
            _rightCardText.text = $"Find the {text}";
        }

        public void NewLevelReached()
        {
            OnNewLevelReached?.Invoke();
        }
    }
}