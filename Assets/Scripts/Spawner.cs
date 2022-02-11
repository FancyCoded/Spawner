using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _points;
    [SerializeField] private Enemy _template;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_points.childCount];
        
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = _points.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForTwoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            yield return waitForTwoSeconds;
            Instantiate(_template, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
