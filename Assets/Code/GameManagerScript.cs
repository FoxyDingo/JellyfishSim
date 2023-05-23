using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public bool UseRealTime;

    // Start is called before the first frame update
    void Start()
    {
        //Generate Jellyfish
        Instantiate(Resources.Load("Jellyfish"), new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (UseRealTime)
        {

        }
        else
        {
            //TODO use input manager
            if (Input.GetKeyDown("space"))
            {

            }

        }
    }
}
