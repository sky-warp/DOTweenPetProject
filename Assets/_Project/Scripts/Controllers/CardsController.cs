using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Project.Scripts.Configs.Difficulties;
using _Project.Scripts.Models;
using _Project.Scripts.Views;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Controllers
{
    public class CardsController
    {
        private DifficultiesConfigs[] _difficulties;
        private List<CardData> _cards;
        private CardsView _cardsView;
        
        private string _rightCard;
        private TaskCompletionSource<bool> _tcs;
        
        private int _currentAmountOfCards;
        
        public CardsController(CardData[] cards, CardsView cardsView, DifficultiesConfigs[] difficulties)
        {
            _currentAmountOfCards = 0;
            _cards = cards.ToList();
            _cardsView = cardsView;
            _difficulties = difficulties;

            cardsView.OnCardClicked += CheckRightCard;
            
            CreateLevel();
        }

        private async void CreateLevel()
        {
            for (int i = 0; i < _difficulties.Length; i++)
            {
                //_cardsView.NewLevelReached();
                
                ShuffleCards();
                
                int slotsAmountToSpawn = _difficulties[i].AmountOfSlots - _currentAmountOfCards;

                for (int j = 0; j < slotsAmountToSpawn; j++)
                {
                    _cardsView.CreateCard(_cards[j].Sprite, _cards[j].Identifier);
                    
                    _currentAmountOfCards++;
                }
                
                _rightCard = ChooseRightCard();
            
                DrawRightCardText();
                
                _tcs = new TaskCompletionSource<bool>();
                
                await _tcs.Task;
            }
        }
        
        private void CheckRightCard(string cardIdentifier)
        {
            if (cardIdentifier == _rightCard)
            {
                _tcs.SetResult(true);
            }
        }
        
        private void ShuffleCards()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                var temp = _cards[i];
                int j = Random.Range(i, _cards.Count);
                _cards[i] = _cards[j];
                _cards[j] = temp;
            }
        }

        private string ChooseRightCard()
        {
            int randomIndex = Random.Range(0, _currentAmountOfCards);
            
            string rightCard = _cards[randomIndex].Identifier;
            
            return rightCard;
        }

        private void DrawRightCardText()
        {
            _cardsView.DrawRightCardText(_rightCard);
        }
    }
}