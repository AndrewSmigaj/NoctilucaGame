using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoctilucaSpawning : MonoBehaviour
{

    private List<GameObject> swarm;

    public Transform playerTransform;

    public GameObject noctilucaPrefab;


    // Start is called before the first frame update
    void Start()
    {
        swarm = new List<GameObject>();

        SpawnNoctilucas();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int numNoctiluca = 5;
    void SpawnNoctilucas()
    {
        for(int i = 0; i <= numNoctiluca; i++)
        {
            Vector3 noctilucaPosition = playerTransform.position + new Vector3((i+1)*5, 0, 0);
            Instantiate(noctilucaPrefab, noctilucaPosition, playerTransform.rotation);
        }
    }
}
