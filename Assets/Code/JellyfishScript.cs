using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishScript : MonoBehaviour
{
    public const int MaxEnergy = 9;
    public int Energy { get; set; }

    private bool _hasFlashed;

    public bool Energize()
    {
        if (_hasFlashed)
        {
            return false;
        }

        Energy++;

        if (Energy > MaxEnergy)
        {
            Glow();
            return true;
        }

        return false;
    }

    public void ResetFlash() 
    {
        _hasFlashed = false;
        GetComponent<GlowScript>().Darken();
    }

    private void Glow()
    {
        Energy = 0;
        _hasFlashed = true;
        GetComponent<GlowScript>().Glow();
    }

}
