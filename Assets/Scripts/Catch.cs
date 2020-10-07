using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public GameManager GM;
    private Vector3 mOffset;
    private float mZCoord;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    void OnMouseDown() {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetFingerAsWorldPoint();
        if (this.gameObject.layer == 9) {
            GM.hasPhoto = true;
            GM.hadPhoto = true;
            GM.photoObj = this.gameObject;
        }
    }

    private Vector3 GetFingerAsWorldPoint() {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag() {
        transform.position = GetFingerAsWorldPoint() + mOffset;

    }

    void OnMouseUp() {
        if (this.gameObject.layer == 9) {
            GM.hasPhoto = false;
        }
    }


}
