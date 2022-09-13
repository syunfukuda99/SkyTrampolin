// using System;
// using Model;
// using UnityEngine;
//
// namespace Ad
// {
//     public interface IInterstitialScheduler
//     {
//         void ShowAdOrSkip(Action afterAd);
//     }
//
//     public class StageInterstitialScheduler : IInterstitialScheduler
//     {
//         private IInterstitial _ad;
//         private bool _display;
//         public StageInterstitialScheduler(StageCounter counter)
//         {
//             if (IsDisplay(counter))
//             {
//                 _ad = AdManager.Instance.Implement.StageInterstitial();
//             }
//         }
//         public void ShowAdOrSkip(Action afterAd)
//         {
//             if (_ad != null)
//             {
//                 _ad.Show(afterAd);
//             }
//             else
//             {
//                 afterAd();
//             }
//         }
//
//         private const string CounterKey = "StageInterstitialScheduler-Counter";
//         private bool IsDisplay(StageCounter counter)
//         {
//             if (counter.Value <= 10) return false;
//             var c = PlayerPrefs.GetInt(CounterKey, 0);
//             c = (c+1)%5;
//             PlayerPrefs.SetInt(CounterKey, c);
//
//             return c == 0;
//         }
//     }
// }