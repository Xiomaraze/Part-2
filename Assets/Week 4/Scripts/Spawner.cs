using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plane;
    float ran;
    float timer;
    Quaternion rotate;
    void Start()
    {
        Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
        ran = Random.Range(0, 5);
        rotate = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ran)
        {
            Instantiate(plane, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), rotate);
            timer = 0;
            ran = Random.Range(0, 5);
            rotate = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
    }
}
