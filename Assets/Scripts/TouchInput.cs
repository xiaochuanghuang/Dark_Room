using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    //public GameObject particle;
    void Update() {
        for (int i = 0; i < Input.touchCount; ++i) {
            if (Input.GetTouch(i).phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hitRay;
                if (Physics.Raycast(ray, out hitRay)) {
                    if (hitRay.collider != null) {
                        hitRay.collider.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                    }
                    //Instantiate(particle, transform.position, transform.rotation);
                }
            }
        }
    }
}
