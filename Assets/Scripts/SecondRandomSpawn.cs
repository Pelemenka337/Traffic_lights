using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRandomSpawn : MonoBehaviour
{
    public GameObject[] objects;
    private int random;

    private void Start()
    {
        StartCoroutine(RandomCoroutine());
    }

    IEnumerator RandomCoroutine()
    {
        random = Random.Range(1, 4);
        yield return new WaitForSeconds(random);
        random = Random.Range(0, objects.Length);
        RandomSpawns();
        Repeat();
    }

    private void RandomSpawns()
    {
        Instantiate(objects[random], transform.position, Quaternion.Euler(0, 0, 0));
    }
    void Repeat()
    {
        StartCoroutine(RandomCoroutine());
    }
}