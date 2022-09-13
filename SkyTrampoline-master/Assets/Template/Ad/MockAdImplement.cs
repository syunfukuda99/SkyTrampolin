using System;
using UniRx;
using UnityEngine;

namespace Ad
{
    public class MockAdImplement : IAdImplement
    {
        public void Setup()
        {
            
        }

        public IInterstitial StageInterstitial()
        {
            return new MockInterstitial("StageInterstitial");
        }

        public IRewardAd<bool> SkipReward()
        {
            return new MockReward("Skip");
        }
    }

    public class MockInterstitial : IInterstitial
    {
        private string _name;

        public MockInterstitial(string name)
        {
            _name = name;
        }

        public void Show(Action onFinished)
        {
            Debug.Log($"Ad Showed: {_name}");
            onFinished();
        }
    }
    
    public class MockReward : IRewardAd<bool>
    {
        private string _name;

        public MockReward(string name)
        {
            _name = name;
        }
        public bool Available()
        {
            return true;
        }

        public void Show(Action<bool> onUserEarnedReward)
        {
            Debug.Log($"Ad Showed: {_name}");
            onUserEarnedReward(true);
        }
    }    
}