using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public List<GameObject> prefabs = new List<GameObject>();
    public GameObject finalObject;
    public float delay = 2f;

    [HideInInspector] public bool isWork = true;

    private int _lastPref = 0;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (isWork)
        {
            int rand = 0;
            bool ok = false;
            while (!ok)
            {
                rand = Random.Range(0, prefabs.Count);
                if (rand != _lastPref)
                {
                    _lastPref = rand;
                    ok = true;
                }
            }

            Instantiate(prefabs[rand], spawnPoint.position, prefabs[rand].transform.rotation);
            
            yield return new WaitForSeconds(delay);
        }
        
        // Спавним finalObject
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        prefabs.Clear();
    }
}