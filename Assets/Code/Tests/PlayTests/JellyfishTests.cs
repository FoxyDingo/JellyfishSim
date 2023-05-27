using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.XR;
using UObject = UnityEngine.Object;

public class JellyfishTests
{
    [OneTimeSetUp]
    public void Setup()
    {
        SceneManager.LoadScene("TestScene");
    }

    [UnityTest]
    public IEnumerator JellyfishGlowTest()
    {
        var jellyFish = (GameObject)UObject.Instantiate(Resources.Load("Jellyfish"), new Vector3(0, 0, 0), Quaternion.identity);
        var jellyScript = jellyFish.GetComponent<JellyfishScript>();
        jellyScript.Energy = 9;

        var gm = GameObject.Find("/GameManager");
        gm.GetComponent<GameManagerScript>().Jellyfishes = new List<GameObject>() { jellyFish };
        gm.SendMessage("HandleRound");

        Assert.AreEqual(0, jellyScript.Energy);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator JellyfishNoGlowTest()
    {
        var jellyFish = (GameObject)UObject.Instantiate(Resources.Load("Jellyfish"), new Vector3(0, 0, 0), Quaternion.identity);
        var jellyScript = jellyFish.GetComponent<JellyfishScript>();
        jellyScript.Energy = 8;

        var gm = GameObject.Find("/GameManager");
        gm.GetComponent<GameManagerScript>().Jellyfishes = new List<GameObject>() { jellyFish };
        gm.SendMessage("HandleRound");

        Assert.AreEqual(9, jellyScript.Energy);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator JellyfishExampleTest()
    {
        int[,] initData = 
        {
            {1, 1, 1, 1, 1 },
            {1, 9, 9, 9, 1 },
            {1, 9, 1, 9, 1 },
            {1, 9, 9, 9, 1 },
            {1, 1, 1, 1, 1 }
        };

        JellyfishScript[,] jellyScripts = new JellyfishScript[initData.GetLength(0), initData.GetLength(1)];
        List<GameObject> jellyfishes = new List<GameObject>();

        for(int l = 0; l < initData.GetLength(0); l++)
        {
            for(int c = 0; c < initData.GetLength(1); c++)
            {
                var jellyfish = (GameObject)UObject.Instantiate(Resources.Load("Jellyfish"), new Vector3(l, c, 0), Quaternion.identity);
                var jellyScript = jellyfish.GetComponent<JellyfishScript>();
                jellyScript.Energy = initData[l,c];

                jellyScripts[l,c] = jellyScript;
                jellyfishes.Add(jellyfish);
            }
        }        

        var gm = GameObject.Find("/GameManager");
        gm.GetComponent<GameManagerScript>().Jellyfishes = jellyfishes;
        gm.SendMessage("HandleRound");

        Assert.AreEqual(3, jellyScripts[0, 0].Energy);
        Assert.AreEqual(4, jellyScripts[0, 1].Energy);

        Assert.AreEqual(4, jellyScripts[1, 0].Energy);
        Assert.AreEqual(0, jellyScripts[1, 1].Energy);
        Assert.AreEqual(0, jellyScripts[1, 2].Energy);
        Assert.AreEqual(0, jellyScripts[1, 3].Energy);
        Assert.AreEqual(4, jellyScripts[1, 4].Energy);

        Assert.AreEqual(5, jellyScripts[2, 0].Energy);
        Assert.AreEqual(0, jellyScripts[2, 1].Energy);
        Assert.AreEqual(0, jellyScripts[2, 2].Energy);
        Assert.AreEqual(0, jellyScripts[2, 3].Energy);
        Assert.AreEqual(5, jellyScripts[2, 4].Energy);

        Assert.AreEqual(4, jellyScripts[4, 3].Energy);
        Assert.AreEqual(3, jellyScripts[4, 4].Energy);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

}
