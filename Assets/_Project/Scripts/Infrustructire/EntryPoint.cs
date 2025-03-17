using _Project.Scripts.Configs;
using _Project.Scripts.Configs.Difficulties;
using _Project.Scripts.Controllers;
using _Project.Scripts.Views;
using UnityEngine;

namespace _Project.Scripts.Infrustructire
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private DifficultiesConfigs[] _difficulties;
        [SerializeField] private CardConfig _cardConfig;
        [SerializeField] private CardsView _cardsView;

        private void Awake()
        {
            CardsController cardsController = new(_cardConfig.CardData, _cardsView, _difficulties);
        }
    }
}