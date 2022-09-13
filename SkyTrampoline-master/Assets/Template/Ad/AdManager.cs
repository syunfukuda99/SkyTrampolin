using System;
using UniRx;

namespace Ad
{
    public class AdManager : SingletonMonoBehaviour<AdManager>
    {
        public IAdImplement Implement = new MockAdImplement();

        protected override void Awake()
        {
            base.Awake();
            Implement.Setup();
        }    
    
    }

    public interface IAdImplement
    {
        void Setup();
        IInterstitial StageInterstitial();
        IRewardAd<bool> SkipReward();
    }
    
    public interface IInterstitial
    {
        void Show(Action onFinished);
    }    
    
    public interface IRewardAd<T>
    {
        bool Available();
        void Show(Action<T> onUserEarnedReward);
    }
}
