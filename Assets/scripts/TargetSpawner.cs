using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public GameObject targetPrefabs;

    public float generateTime = 3f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = generateTime;

            float xPosition = Random.Range(-10f, 10f);
            Vector3 newPosition = new Vector3(xPosition, 0, 0);
            Instantiate(targetPrefabs, newPosition, Quaternion.identity);
        }
    }
}
