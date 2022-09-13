using System;
using UnityEngine;

public class InstantGameObject : MonoBehaviour
{
    [SerializeField] private float timer = 3f;

    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
