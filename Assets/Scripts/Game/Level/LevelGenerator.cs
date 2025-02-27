using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _roadPrefab;
    private List<GameObject> _activeTiles = new List<GameObject>();
    private float _spawnPos = 115;
    private float _tileLength = 111f;

    [SerializeField] private Transform _player;
    private int _startTiles = 2;

    private void Start()
    {
        for (int i = 0; i < _startTiles; i++)
        {
            SpawnLevel(Random.Range(0, _roadPrefab.Length));
        }
    }

    private void FixedUpdate()
    {
        if (PlayerController.isPlayerDead == false)
        {
            if (_player.position.z - 20 > _spawnPos - (_startTiles * _tileLength))
            {
                SpawnLevel(Random.Range(0, _roadPrefab.Length));
                DeleteTile();
            }
        }
    }

    private void SpawnLevel(int tileindex)
    {
        GameObject nextTile = Instantiate(_roadPrefab[tileindex], transform.forward * _spawnPos, transform.rotation);
        _activeTiles.Add(nextTile);
        _spawnPos += _tileLength;
    }

    private void DeleteTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }
}