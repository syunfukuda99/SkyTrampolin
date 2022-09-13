using System;
using UniRx;
using UnityEngine;

public class CannonEffect : MonoBehaviour
{
    [SerializeField] private GameObject firstEffect;
    [SerializeField] private GameObject secondEffect;

    [SerializeField] private float span = 0.5f;

    private void OnEnable()
    {
        firstEffect.SetActive(false);
        secondEffect.SetActive(false);

        Observable.NextFrame().Subscribe(_ => Effect());
    }

    private void Effect()
    {
        firstEffect.SetActive(true);
        Observable.Timer(TimeSpan.FromSeconds(3f)).Subscribe(_ => firstEffect.SetActive(false));

        Observable.Timer(TimeSpan.FromSeconds(span)).Subscribe(_ =>
        {
            secondEffect.SetActive(true);
            Observable.Timer(TimeSpan.FromSeconds(3f)).Subscribe(__ =>
            {
                secondEffect.SetActive(false);
                gameObject.SetActive(false);
            });
        });
    }
}