using UnityEngine;

namespace _Project.Scripts.Configs.Difficulties
{
    [CreateAssetMenu(fileName = "DifficultiesConfigs", menuName = "New Difficulties Configs/DifficultiesConfigs")]
    public class DifficultiesConfigs : ScriptableObject
    {
        [field: SerializeField] public int AmountOfSlots {get; private set;}
    }
}