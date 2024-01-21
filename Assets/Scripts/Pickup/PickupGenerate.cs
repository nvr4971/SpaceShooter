using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerate : MonoBehaviour
{
    public static PickupGenerate Instance { get; private set; }

    [SerializeField] private List<Pickup> pickupList;

    private void Awake()
    {
        if (PickupGenerate.Instance != null)
        {
            Destroy(PickupGenerate.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SpawnPickup(Vector3 pos)
    {
        GameObject pickup = RollForPickupSpawn();

        if (pickup)
        {
            Instantiate(pickup, pos, Quaternion.identity);
        }

    } 

    private GameObject RollForPickupSpawn()
    {
        List<Pickup> pickups = pickupList;
        Shuffle(pickups);

        float chance = Random.value;

        foreach (Pickup pickup in pickups)
        {
            if (chance <= pickup.dropChance)
            {
                return pickup.pickupPf;
            }
        }

        return null;
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        System.Random rnd = new();
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
