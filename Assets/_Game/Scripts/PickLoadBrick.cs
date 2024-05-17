using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickLoadBrick : MonoBehaviour
{
    [SerializeField] private List<GameObject> bricks;

    //private bool canPick = true;
    //private bool canLoad = true;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < bricks.Count; i++)
        {
            Collider brickCollider = bricks[i].GetComponent<Collider>();
            if (brickCollider == other)
            {
                MeshRenderer meshRenderer = bricks[i].GetComponent<MeshRenderer>();
                if (other.CompareTag("Brick") && meshRenderer.enabled)
                {
                    meshRenderer.enabled = false;
                }
                else if (other.CompareTag("UnBrick"))
                {
                    meshRenderer.enabled = true;
                }
                
            }

        }

    }


}
