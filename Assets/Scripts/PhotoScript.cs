using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoScript : MonoBehaviour
{

    public int id;
    public int stage;
    // Start is called before the first frame update
    void Start()
    {

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
                //photo is developed
                //load different texture for each photo
                switch (id) {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }

                break;
            case 2:
                //first bath
                switch (id)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
                break;
            case 3:
                //second bath
                switch (id)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
                break;
            case 4:
                //final bath
                switch (id)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
                break;
            case 5:
                //photo is hung up
                switch (id)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
                break;
        }

    }
}
