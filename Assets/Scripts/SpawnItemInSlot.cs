using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItemInSlot : MonoBehaviour
{
    public GameObject[] bags;
    public Transform[] pos,spawnPoints;
    public GameObject item , player;
    public GameObject panel;
    public Canvas canvas;
    public int howMuchItems;
    public int howMuchMainItems;

    private void Awake()
    {
        Instantiate(bags[Bridge.i],canvas.transform);
        FindAllPosToSpawn();
        SpawnMainAndItems(item, howMuchItems, pos);
        SpawnMainAndItems(player, howMuchMainItems, spawnPoints);
    }

    private void FindAllPosToSpawn()
    {
        pos = GameObject.FindGameObjectWithTag("Container").GetComponentsInChildren<Transform>().Skip(1).ToArray();
    }

    private void Start()
    {
    }

    private void SpawnMainAndItems(GameObject obj,int howMuchItems,Transform[] arr)
    {
        Transform position = obj.transform;
        for (int i = 0; i < howMuchItems; i++)
        {
            Transform positionToSpawn = arr[Random.Range(0, arr.Length)];

            if (position.transform.position != positionToSpawn.position)
            {
                GameObject item = Instantiate(obj, canvas.transform);
                item.transform.position = positionToSpawn.position;
                position = positionToSpawn;
            }
        }
    }
}
