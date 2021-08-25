using System;
using UnityEngine;

namespace PlatformerMVC
{
    public class WinGame : MonoBehaviour
    {
        public event Action<bool> IsGameWin = delegate (bool isGameWin) { };

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IsGameWin.Invoke(true);
            }
        }
    }
}
