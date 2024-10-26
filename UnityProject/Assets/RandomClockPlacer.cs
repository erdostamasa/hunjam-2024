using System.Collections.Generic;
using UnityEngine;

public class RandomClockPlacer : MonoBehaviour
{

    [SerializeField] private List<GameObject> clockPrefabs;

    [SerializeField] private float clockSize = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Select a random clock prefab
        int randomIndex = Random.Range(0, clockPrefabs.Count);
        GameObject clockPrefab = clockPrefabs[randomIndex];

        //Instantiate the clock prefab
        GameObject clock = Instantiate(clockPrefab, transform.position, Quaternion.identity);

        //Set clock size 0.2
        clock.transform.localScale = new Vector3(clockSize, clockSize, clockSize);
    }


}
