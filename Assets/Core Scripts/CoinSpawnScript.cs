using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnScript : MonoBehaviour
{
    public GameObject _coinPrefab;
    private bool _spawnCoinCheck;
    void Update()
    {
        if (!_spawnCoinCheck)
        {
            Instantiate(_coinPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            _spawnCoinCheck = true;
        }
    }
}
