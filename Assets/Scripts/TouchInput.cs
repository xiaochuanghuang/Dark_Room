using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    public Color startColor;
    public Color darkRoomColor;
    public Light _light;

    public bool hasPhoto = false;
    public bool hadPhoto = false;

    private void Start() {
        _light.color = startColor;     
    }

    

    //public GameObject particle;
    void Update() {
        for (int i = 0; i < Input.touchCount; ++i) {
            //begining of each touch
            if (Input.GetTouch(i).phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hitRay;
                if (Physics.Raycast(ray, out hitRay)) {
                    
                    if (hitRay.collider != null) {
                        //hitRay.collider.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                        if (hitRay.transform.gameObject.layer == 8) {
                            Debug.Log("Player tapped light switch");
                            if (_light.color == startColor)
                            {
                                _light.color = darkRoomColor;
                            }
                            else {
                                _light.color = startColor;
                            }
                        }
                    }
                    //Instantiate(particle, transform.position, transform.rotation);
                }
            }

            //ending a touch
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                if (!hasPhoto && hadPhoto) {
                    hadPhoto = false;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    RaycastHit hitRay;
                    if (Physics.Raycast(ray, out hitRay))
                    {
                        if (hitRay.collider != null)
                        {
                            //hitRay.collider.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                            //player has photo and released on enlarger
                            if (hitRay.transform.gameObject.layer == 10) {
                                hitRay.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
                            }
                        }
                        //Instantiate(particle, transform.position, transform.rotation);
                    }
                }
            }
        }
    }
}
