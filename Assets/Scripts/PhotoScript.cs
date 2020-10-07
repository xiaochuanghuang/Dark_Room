using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PhotoScript : MonoBehaviour
{

    public int id;
    public int stage;
    // Start is called before the first frame update
    void Start() {

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
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
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
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
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
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);
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
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;                       
            case 1:                          
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;                                                              
            case 2:                                                                 
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;                                                              
            case 3:                                                                 
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;                                                             
            case 4:                                                                
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                break;
        }
    }
}
