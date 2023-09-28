using System;
using ObjectPool;
using UnityEngine;
public class CoinView : MonoBehaviour, IInitializableMonoBehaviour
{ 
    public Action OnDispose { get; set; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<PlayerView>())
            OnDispose?.Invoke();
    }

    public void Dispose()
    {
    }
}
