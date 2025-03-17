using _Project.Scripts.Models;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CardConfig", menuName = "Create new Config/Card Config")]
    public class CardConfig : ScriptableObject
    {
        [SerializeField] private CardData[] _cardData;
    
        public CardData[] CardData => _cardData;
    }
}