using System.Collections.Generic;
using UnityEngine;

public class RandomClockPlacer : MonoBehaviour
{

    [SerializeField] private List<GameObject> clockPrefabs;

    [SerializeField] private float chanceToSpawn = 0.25f;

    [SerializeField] private float minSizeMultiplier = 0.9f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Randomly spawn a clock
        // if (Random.value > chanceToSpawn)
        // {
        //     return;
        // }


        //Select a random clock prefab
        int randomIndex = Random.Range(0, clockPrefabs.Count);
        GameObject clockPrefab = clockPrefabs[randomIndex];

        //Instantiate the clock prefab
        GameObject clock = Instantiate(clockPrefab, transform.position, Quaternion.identity);

        //Randomly scale the clock 
        float randomSizeMultiplier = Random.Range(minSizeMultiplier, 1f);
        clock.transform.localScale = new Vector3(clock.transform.localScale.x * randomSizeMultiplier, clock.transform.localScale.y * randomSizeMultiplier, clock.transform.localScale.z * randomSizeMultiplier);


    }


}
