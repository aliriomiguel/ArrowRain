using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float _waitTime = 5f;
    [SerializeField]
    private GameObject _arrowPrefab;
    [SerializeField]
    private GameObject _arrowContainer;
    /*[SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private GameObject _coinPrefab;
    */
    private bool _stopSpawning = false;

    private IEnumerator Coroutine;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started Coroutine");
        StartCoroutine(SpawnArrowRoutine(_waitTime));
    }

    IEnumerator SpawnArrowRoutine(float time) {
        yield return new WaitForSeconds(2.0f);
        while (_stopSpawning == false) {
            Vector3 posToSpawn = new Vector3(Random.Range(-6f, 6f), 4, 0);
            GameObject newObject = Instantiate(_arrowPrefab, posToSpawn, Quaternion.identity);
            newObject.transform.parent = _arrowContainer.transform;
            newObject.transform.Rotate(0, 0, -90);
            yield return new WaitForSeconds(time);
        }
    }

    /*IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawnPowerup = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], posToSpawnPowerup, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }*/

    public void OnPlayerDead()
    {
        _stopSpawning = true;
    }
}
