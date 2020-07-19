using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IItem
    {
        void Use(GameObject player);
        bool CanBeUsed();
        bool IsFullyUsed();
    }
}