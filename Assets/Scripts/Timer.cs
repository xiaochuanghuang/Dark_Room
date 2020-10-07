using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int secondLeft = 4;
    public AudioSource process;
    public AudioSource ring;
    bool play = true;
    // Start is called before the first frame update
    void Start()
    {
        process.volume = 0.2f;
        ring.volume = 0.2f;
  



    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= secondLeft; i++)
        {
            if (play == false && (secondLeft >= 0&&secondLeft<2))
                process.Play();
            else if (play == false && (secondLeft >=2 && secondLeft <= 4))
                ring.Play();
            new WaitForSeconds(1);
        }
    }


}
