using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Color startColor;
    public Color darkRoomColor;
    public Light _light;
    public int numPhotos;

    public AudioSource src;

    public bool hasPhoto = false;
    public bool hadPhoto = false;
    public bool previewingPhoto = false;

    public GameObject photoObj;
    public GameObject heldPhoto;
    public GameObject textObj;

    private Vector3 oldPhotoPos;

    //float t = 5;

    private void Start() {
        src.volume = 0.5f;
        src.time = 1f;
        heldPhoto = null;
        textObj.SetActive(false);
        _light.color = startColor;
        //hard coded spawning of one item
        Instantiate(photoObj, new Vector3(-3.64f, .65f, 4.382f), Quaternion.identity);
        photoObj.GetComponent<PhotoScript>().id = 0;
        photoObj.GetComponent<PhotoScript>().stage = 0;
        //use this to spawn multiple photos - don't  delete
        /*for (int i=0; i<numPhotos; i++) {
            Instantiate(photoObj, new Vector3(-3.64f, yVal, 4.382f), Quaternion.identity);
            yVal += .05f;
            photoObj.GetComponent<PhotoScript>().id = i;
            photoObj.GetComponent<PhotoScript>().stage = 0;
        }*/
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
                            PhotoScript ps = heldPhoto.GetComponent<PhotoScript>();
                            //player has photo and released on enlarger
                            if (hitRay.transform.gameObject.layer == 10) {
                                //hitRay.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
                                if (ps.stage == 0)
                                {

                                    //src.Play();
                                    //put timer code here
                                    heldPhoto.GetComponent<Rigidbody>().isKinematic = true;
                                    //advance stage of photo
                                    StartCoroutine(counter(ps));
                                }
                            }
                            //collided with bath 1
                            else if (hitRay.transform.gameObject.layer == 11) {
                                //hitRay.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
                                if (ps.stage == 1)
                                {
                                    
                                    //put timer code here
                                    heldPhoto.GetComponent<Rigidbody>().isKinematic = true;
                                    //advance stage of photo
                                    StartCoroutine(counter(ps));
                                }
                            }
                            //collided with bath 2
                            else if (hitRay.transform.gameObject.layer == 12) {
                                //hitRay.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
                                
                                if (ps.stage == 2)
                                {
                                    //put timer code here

                                    //advance stage of photo
                                   
                                    //put photo in specific spot 
                                    heldPhoto.GetComponent<Rigidbody>().isKinematic = true;
                                    //advance stage of photo
                                    StartCoroutine(counter(ps));
                                }
                            }
                            //collided with bath 3
                            else if (hitRay.transform.gameObject.layer == 13) {
                                //hitRay.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
                                
                                
                                if (ps.stage == 3)
                                {
                                    //put timer code here

                                    //advance stage of photo
                                    
                                    //put photo in specific spot 
                                    heldPhoto.GetComponent<Rigidbody>().isKinematic = true;
                                    //advance stage of photo
                                    StartCoroutine(counter(ps));
                                }
                            }
                            //collided with wire
                            else if (hitRay.transform.gameObject.layer == 14) {
                                //hitRay.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
                                if (ps.stage == 4)
                                {
                                    //advance stage of photo

                                        ps.stage++;
                                        //src.Play();
                                    
                                    //put photo in specific spot 
                                    heldPhoto.transform.position = PositionPhoto(ps.id, ps.stage);
                                    heldPhoto.transform.eulerAngles = new Vector3(-90, 0 , 0);
                                    heldPhoto.GetComponent<Rigidbody>().useGravity = false;
                                    heldPhoto.GetComponent<Rigidbody>().velocity = Vector3.zero;
                                    heldPhoto.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                                }
                            }

                            if (hitRay.transform.gameObject.layer == 9 && heldPhoto.GetComponent<PhotoScript>().stage == 5)
                            {
                                if (previewingPhoto)
                                {
                                    previewingPhoto = false;
                                    hitRay.transform.position = oldPhotoPos;
                                    textObj.SetActive(false);
                                }
                                else
                                {
                                    previewingPhoto = true;
                                    oldPhotoPos = hitRay.transform.position;
                                    hitRay.transform.position = new Vector3(-3.55f, 0.8f, 4.37f);
                                    textObj.SetActive(true);
                                    changePreviewDescription(heldPhoto.GetComponent<PhotoScript>().id);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void changePreviewDescription(int photoID) {
        switch (photoID)
        {
            case 0:
                textObj.GetComponent<TextMeshPro>().text = "The Bonytail Chub is native to the mountain west states, and is categorized as critically endangered. Because of invasive, non-native fish and habitat alterations its population continues to shrink despite nearly 40 years of conservation efforts.";
                break;
            case 1:
                textObj.GetComponent<TextMeshPro>().text = "The Utah Prairie Dog has been categorized as threatened since 1984. They are at risk from human urban expansion, invasive plants and climate change. Despite efforts to relocate the species, 70% of Utah Prairie Dogs reside on private lands.";
                break;
            case 2:
                textObj.GetComponent<TextMeshPro>().text = "The Gunnison Grouse is native to Colorado and Utah, and has been listed as endangered since 2014. It is estimated that there are less than 5,000 Gunnison Grouse in existence, with 85% of the species living in the Gunnison Basin.";
                break;
            case 3:
                textObj.GetComponent<TextMeshPro>().text = "Description 4!!!!!!!";
                break;
            case 4:
                textObj.GetComponent<TextMeshPro>().text = "Description 5!!!!!!!";
                break;
        }
    }

    public Vector3 PositionPhoto(int PhotoID, int stage) {
        switch (stage) {
            //after enlargment
            case 1:
                return new Vector3(-3.978f, .652f, 4.398f);
            //after first bath
            case 2:
                return new Vector3(-3.397f, .67f, 4.434f);
            //after second bath
            case 3:
                return new Vector3(-3.23f, .67f, 4.434f);
            //after third bath
            case 4:
                return new Vector3(-3.0587f, .67f, 4.4299f);
            //final spot - based off ID - each one gets a specific spot on the wire
            case 5:
                switch (PhotoID) {
                    case 0:
                        return new Vector3(-3.3538f, 0.9536f, 4.858f);
                    case 1:
                        return new Vector3(-3.3961f, 0.9563f, 4.8615f);
                    case 2:
                        return new Vector3(-3.207f, 0.9321f, 4.899f);
                    case 3:
                        return new Vector3(-2.808f, 0.884f, 4.888f);
                    case 4:
                        return new Vector3(-2.925f, 1.029f, 4.812f);
                }
                return new Vector3();
            default:
                return new Vector3();
        }
    }
    IEnumerator counter(PhotoScript ps) {

        yield return new WaitForSeconds(3);

        ps.stage++;
        src.Play();
        //put photo in specific spot 
        heldPhoto.GetComponent<Rigidbody>().velocity = Vector3.zero;
        heldPhoto.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        heldPhoto.transform.position = PositionPhoto(ps.id, ps.stage);

        heldPhoto.GetComponent<Rigidbody>().isKinematic = false;
    }

}
