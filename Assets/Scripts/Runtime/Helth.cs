using System;
using UnityEngine;

namespace Game.Runtime
{
    public class Helth : MonoBehaviour
    {
        public float maxHelth=100.0f;
        public float _currentHelth;

        private void Start()
        {
            _currentHelth = maxHelth;
        }

        public void TakeDamage(float damage)
        {
            _currentHelth -= damage;
        }
    }
}
