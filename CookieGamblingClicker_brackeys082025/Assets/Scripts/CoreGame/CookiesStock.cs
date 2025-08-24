using UnityEngine;
namespace CookieGambler
{
    public class CookiesStock
    {
        private static CookiesStock _instance;
        public static CookiesStock Instance { get => _instance ??= new CookiesStock(); }

        public int CookiesCount { get; private set; }

        private CookiesStock()
        {
            CookiesCount = 0;
        }

        public void UpdateCurrentCookiesCount(int cookiesCount)
        {
            CookiesCount += cookiesCount;
        }

    }
}

