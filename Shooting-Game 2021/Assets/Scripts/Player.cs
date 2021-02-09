using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject laserprefab;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] float projectSpeed = 10f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    void Start()
    {
        setBoundries();
    }

    private void setBoundries()
    {
        Camera cameraMain = Camera.main;
        xMin = cameraMain.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = cameraMain.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;

        yMin = cameraMain.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
        yMax = cameraMain.ViewportToWorldPoint(new Vector3(1,1,0)).y - padding;
    }

   

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();

    }


    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject laser =
            Instantiate(laserprefab,
            transform.position,
            Quaternion.identity)
            as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectSpeed);
        }
    }



    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newnexPos = Mathf.Clamp(transform.position.x + deltaX, xMin,xMax);
        var newneyPos = Mathf.Clamp(transform.position.y + deltaY, yMin,yMax);
        transform.position = new Vector2(newnexPos,newneyPos);
    }
}


