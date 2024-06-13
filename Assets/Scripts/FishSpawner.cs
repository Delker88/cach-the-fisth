using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public static FishSpawner instance;
    private GameObject[] prefabFishes;
    private Transform myTransform;
    private int randomFish;
    private float randomFishPositionX;
    [SerializeField] 
    private float _delayFishSpawn;
    public float DelayFishSpawn { set => _delayFishSpawn = value; }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    

    public void GetFishes()
    {
        prefabFishes = GameObject.FindGameObjectsWithTag("Fish");
        foreach (var item in prefabFishes)
        {
            item.SetActive(false);
            item.transform.parent = myTransform;
        }
    }
    private void SpawnFish()
    {
        randomFish = Random.Range(0, prefabFishes.Length);
        randomFishPositionX = Random.Range(0.05f,0.95f) ;
        GameObject tempFishPrefab = Instantiate(prefabFishes[randomFish], new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(randomFishPositionX, 0, 0)).x,
                                                Camera.main.ViewportToWorldPoint(Vector3.one).y + 2f,
                                                0
                                                ), Quaternion.identity);
        tempFishPrefab.SetActive(true);

    }

 IEnumerator SpawnFishes()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnFish();
            yield return new WaitForSeconds(_delayFishSpawn);
        }
    }
    public void StarSpawnFishes()
    {
        StartCoroutine("SpawnFishes");
    }

    public void StopSpawnFishes()
    {
        
        StopCoroutine("SpawnFishes");
    }
    
}
