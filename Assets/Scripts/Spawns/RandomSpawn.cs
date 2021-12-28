using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] objects;
    private int random;
    public LightSpecialGreen Light_First;

    private void Start()
    {
        StartCoroutine(RandomCoroutine());
    }

    IEnumerator RandomCoroutine()
    {
        random = Random.Range(3, 6);
        yield return new WaitForSeconds(random);
        random = Random.Range(0, objects.Length);
        RandomSpawns();
        Repeat();
    }

    private void RandomSpawns()
    {
        GameObject GO = Instantiate(objects[random], transform.position, Quaternion.Euler(0,90,0));
        Movie movie = GO.GetComponent<Movie>();
        movie.Light_First = Light_First;
    }
    void Repeat()
    {
        StartCoroutine(RandomCoroutine());
    }
}
