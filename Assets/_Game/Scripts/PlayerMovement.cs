using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform rayPosition;
    [SerializeField] private LayerMask blockLayer;
    [SerializeField] private float speed;
    [SerializeField] private int somePixelToDeTect;


    private Vector3 newPos;
    private Vector3 endPosition;
    private Vector3 startPos;
    private Vector3 direction;
    private RaycastHit hit;
    private bool fingerDown = false;
    private bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    private void GetEndPosition()
    {
        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }
        if (fingerDown && Input.GetMouseButtonUp(0))
        {

            if (Input.mousePosition.y >= startPos.y + somePixelToDeTect)
            {
                fingerDown = false;
                isMoving = true;
                direction = new Vector3(0, 0, 1);
                playerPosition.rotation = Quaternion.Euler(0, -180, 0);
                //Debug.Log("Swipe up!");
            }
            else if (Input.mousePosition.y <= startPos.y - somePixelToDeTect)
            {
                fingerDown = false;
                isMoving = true;
                direction = new Vector3(0, 0, -1);
                playerPosition.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.mousePosition.x >= startPos.x + somePixelToDeTect)
            {
                fingerDown = false;
                isMoving = true;
                direction = new Vector3(1, 0, 0);
                playerPosition.rotation = Quaternion.Euler(0, -90, 0);
                //Debug.Log("Swipe right!");
            }
            else if (Input.mousePosition.x <= startPos.x - somePixelToDeTect)
            {
                fingerDown = false;
                isMoving = true;
                direction = new Vector3(-1, 0, 0);
                playerPosition.rotation = Quaternion.Euler(0, 90, 0);
                //Debug.Log("Swip left");
            }
            newPos = rayPosition.position;
            //Debug.Log("newpos" + newPos);
            while (Input.GetMouseButtonUp(0))
            {
                Physics.Raycast(newPos, -Vector3.up, out hit, blockLayer);
                if (hit.collider.name.Equals("dimian"))
                {
                    newPos = newPos + (direction);
                    endPosition = hit.point;
                    //Debug.Log("endPos" + endPosition);
                }
                else
                {
                    break;
                }
            }
        }
        Debug.DrawLine(newPos, -Vector3.up, Color.black);

    }
    private void Moving()
    {
        
        GetEndPosition();
        if (isMoving)
        {
            // Kiểm tra xem đến điểm kết thúc chưa
            if (playerPosition.position != endPosition)
            {
                playerPosition.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
                fingerDown = false;
            }
            else
            {
                // Đã đến điểm kết thúc, dừng di chuyển
                isMoving = false;
            }
        }

    }


}
