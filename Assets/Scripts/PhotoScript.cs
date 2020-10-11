using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;

public class PhotoScript : MonoBehaviour
{

    public int id;
    public int stage;
    public bool lightError = false;
    public bool otherError = false;
    Renderer rend;

    public Material[] textures;

    // Start is called before the first frame update
    void Start()
    {
        if (stage == 0)
        {
            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = textures[0];
            lightError = false;
            otherError = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update texture for different stages here!!
        switch (stage) {
            case 0:
                //prob do nothing here - photo isn't developed or enlarged
                break;
            case 1:
                //photo is enlarged
                EnlargePic(id);
                break;
            case 2:
                //first bath
                FirstBath(id);
                break;
            case 3:
                //second bath
                SecondBath(id);
                break;
            case 4:
                //final bath
                ThirdBath(id);
                break;
            case 5:
                //photo is hung up
                HangingPicture(id);
                break;
        }
    }

    void EnlargePic(int picID) {
        switch (picID) {
            case 0:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
                //change to negative
                rend.sharedMaterial = textures[1];
                break;
            case 1:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
                break;
            case 2:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
                break;
            case 3:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
                break;
            case 4:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
                break;
        }
    }

    void FirstBath(int picID) {
        switch (picID) {
            case 0:
                //change to high blur
                rend.sharedMaterial = textures[2];
                break;
            case 1:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                break;
            case 2:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                break;
            case 3:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                break;
            case 4:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                break;
        }
    }

    void SecondBath(int picID) {
        switch (picID) {
            case 0:
                //change to low blur
                rend.sharedMaterial = textures[3];
                break;
            case 1:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                break;
            case 2:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                break;
            case 3:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                break;
            case 4:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                break;
        }
    }

    void ThirdBath(int picID) {
        switch (picID) {
            case 0:
                //change to picture
                rend.sharedMaterial = textures[4];
                break;
            case 1:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);
                break;
            case 2:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);
                break;
            case 3:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);
                break;
            case 4:
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);
                break;
        }
    }

    void HangingPicture(int picID) {
        switch (picID) {
            case 0:
                //this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                if (lightError)
                {
                    rend.sharedMaterial = textures[5];
                }
                else if (otherError)
                {
                    rend.sharedMaterial = textures[6];
                }
                else {
                    rend.sharedMaterial = textures[4];
                }
                break;                       
            case 1:                          
                //this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;                                                              
            case 2:                                                                 
                //this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;                                                              
            case 3:                                                                 
                //this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;                                                             
            case 4:                                                                
                //this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;
        }
    }
}
