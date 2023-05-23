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
            Energy = 0;
            _hasFlashed = true;
            return true;
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
