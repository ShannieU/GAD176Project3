using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "New Player Stats", menuName = "Player/New Player")]
    public class PlayerScriptableObject : ScriptableObject
    {
        [Tooltip("Integer for the player's maximum health.")]
        public int maxHealth;
    }
}
