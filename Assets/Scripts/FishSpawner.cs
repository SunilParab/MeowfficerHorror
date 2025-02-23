using UnityEngine;

namespace Systems {

public class FishSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fishPrefab;

    [SerializeField]
    private float timer;
    [SerializeField]
    private float spawnRange;
    [SerializeField]
    private float spawnHeight = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FishSpawn",timer,timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FishSpawn()
    {
        Instantiate(fishPrefab,new Vector3(Random.Range(-spawnRange,spawnRange),spawnHeight,Random.Range(-spawnRange,spawnRange)), Quaternion.identity);
    }
}

}