using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public bool UseRealTime;
    public bool SkipStart;
    public Vector3 RangeMin;
    public Vector3 RangeMax;
    public float RoundMilliseconds;
    public float NeighbourRadius;
    
    public List<GameObject> Jellyfishes = new List<GameObject>();
    private float _currentTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        //Generate Jellyfish
        for(var x = RangeMin.x; x <= RangeMax.x; x++)
        {
            for(var y = RangeMin.y; y <= RangeMax.y; y++)
            {
                for (var z = RangeMin.z; z <= RangeMax.z; z++)
                {
                    var jellyFish = (GameObject)Instantiate(Resources.Load("Jellyfish"), new Vector3(x, y, z), Quaternion.identity);
                    var jellyScript = jellyFish.GetComponent<JellyfishScript>().Energy = Random.Range(0, JellyfishScript.MaxEnergy+1);
                    Jellyfishes.Add(jellyFish);
                }
            }
        }
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
                HandleRound();  
            }

        }
    }

    void HandleRound()
    {
        ResetJellyfishes(Jellyfishes);

        EnergizeJelllyfishes(Jellyfishes);

    }

    void ResetJellyfishes(List<GameObject> jellyfishes)
    {
        foreach (var jellyfish in jellyfishes)
        {
            var jellyScript = jellyfish.GetComponent<JellyfishScript>();
            jellyScript.ResetFlash();
        }
    }

    void EnergizeJelllyfishes(List<GameObject> jellyfishes)
    {
        foreach(var jellyfish in jellyfishes)
        {
            var jellyScript = jellyfish.GetComponent<JellyfishScript>();
            var hasGlow = jellyScript.Energize();

            if (hasGlow)
            {
                var neighbours = FindNeighbours(jellyfish);
                neighbours.ForEach(n => n.GetComponent<JellyfishScript>().Energize());
            }
        }
    }

    private List<GameObject> FindNeighbours(GameObject jellyfish)
    {
        var colliders = Physics.OverlapSphere(jellyfish.transform.position, NeighbourRadius);

        return colliders.Select(c => c.gameObject).ToList();
    }
}
