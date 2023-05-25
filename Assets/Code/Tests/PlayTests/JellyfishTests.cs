using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.XR;

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
        var jellyFish = (GameObject)Object.Instantiate(Resources.Load("Jellyfish"), new Vector3(0, 0, 0), Quaternion.identity);
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
        var jellyFish = (GameObject)Object.Instantiate(Resources.Load("Jellyfish"), new Vector3(0, 0, 0), Quaternion.identity);
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

    //TODO add test for advent of code example
}
