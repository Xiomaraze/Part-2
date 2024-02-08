using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject weapon;
    public Transform spawnPoint;
    public void spawn(GameObject weapon)
    {
        Instantiate(weapon, spawnPoint);
    }
}
