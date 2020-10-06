using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    //public Transform theDest;
    public TouchInput TI;

    //private void OnMouseDown()
    //{
    //    GetComponent<Collider>().enabled = false;
    //    GetComponent<Rigidbody>().useGravity = false;
    //    this.transform.position = theDest.position;
    //    this.transform.parent = GameObject.Find("Destination").transform;
    //    if (this.gameObject.layer == 9)
    //    {
    //        TI.hasPhoto = true;
    //        TI.hadPhoto = true;
    //    }
    //}
    //private void OnMouseUp()
    //{
    //    this.transform.parent = null;
    //    GetComponent<Rigidbody>().useGravity = true;
    //    GetComponent<Collider>().enabled = true;
    //    if (this.gameObject.layer == 9)
    //    {
    //        TI.hasPhoto = false;
    //    }
    //}
    private Vector3 mOffset;



    private float mZCoord;



    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;


        mOffset = gameObject.transform.position - GetFingerAsWorldPoint();

    }



    private Vector3 GetFingerAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {

        transform.position = GetFingerAsWorldPoint() + mOffset;

    }


}
