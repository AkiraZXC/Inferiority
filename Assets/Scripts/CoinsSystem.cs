using JoostenProductions;
using ObjectPool;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinsSystem : MonoBehaviour
{
    [SerializeField]
    private CoinView _coinView;

    [SerializeField]
    private List<Vector2> _coinsPositions;

    private PrefabPool _prefabPool;

    public void Init(PrefabPool prefabPool)
    {
        _prefabPool = prefabPool;

        foreach (var pointSpawn in _coinsPositions)
            CreateCoin(pointSpawn);

        UpdateManager.SubscribeToUpdate(Tick);
    }

    private void Tick()
    {
        if (Input.GetKeyDown(KeyCode.L))
            CreateCoin(_coinsPositions.FirstOrDefault());
    }

    private void CreateCoin(Vector2 pointSpawn)
    {
        var initialCoinView = _prefabPool.Get(_coinView);
        initialCoinView.transform.position = pointSpawn;
    }
}