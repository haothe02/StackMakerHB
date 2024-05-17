using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class StackBrick : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private List<GameObject> listSpawnBrick;
    [SerializeField] private Transform parentSpawnPos;
    [SerializeField] private Transform currentPos;
    [SerializeField] private Transform playerPos;

    private void Start()
    {
      
    }
    private void AddBrick()
    {
        GameObject newBrick = Instantiate(brickPrefab, parentSpawnPos.position, Quaternion.Euler(-90, 0, -180));
        listSpawnBrick.Add(brickPrefab);
        playerPos.position = new Vector3(playerPos.position.x, playerPos.position.y + 0.3f, playerPos.position.z);

        newBrick.transform.SetParent(parentSpawnPos, playerPos);
        Vector3 pos = currentPos.position;
        pos.y -= 0.3f;
        newBrick.transform.position = pos;
    }
    private void RemoveBrick()
    {
        playerPos.position = new Vector3(playerPos.position.x, playerPos.position.y - 0.3f, playerPos.position.z);
        for (int i = 0; i < listSpawnBrick.Count; i++)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            AddBrick();
            
        }
        else if (other.CompareTag("UnBrick"))
        {
            RemoveBrick();
        }
    }

}
