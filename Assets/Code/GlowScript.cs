using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowScript : MonoBehaviour
{
    public void Glow()
    {
        this.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void Darken()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }
}
