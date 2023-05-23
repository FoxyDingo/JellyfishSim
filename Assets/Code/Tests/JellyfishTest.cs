using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JellyfishTest
{
    [Test]
    public void JellyfishTestSimplePasses()
    {
        var jellyfish = new JellyfishScript();

        var hasGlow = jellyfish.Energize();

        Assert.IsFalse(hasGlow);
        Assert.AreEqual(1, jellyfish.Energy);

    }

    [Test]
    public void JellyfishTestMultipleEnergize()
    {
        var jellyfish = new JellyfishScript();

        var hasGlow = jellyfish.Energize();
        var hasGlow2 = jellyfish.Energize();

        Assert.IsFalse(hasGlow);
        Assert.IsFalse(hasGlow2);

        Assert.AreEqual(2, jellyfish.Energy);
    }


    [Test]
    public void JellyfishTestGlow()
    {
        var jellyfish = new JellyfishScript();
        jellyfish.Energy = 9;

        var hasGlow = jellyfish.Energize();

        Assert.IsTrue(hasGlow);
        Assert.AreEqual(0, jellyfish.Energy);
    }

    [Test]
    public void JellyfishTestMultipleGlows()
    {
        var jellyfish = new JellyfishScript();
        jellyfish.Energy = 9;

        var hasGlow = jellyfish.Energize();
        var hasGlow2 = jellyfish.Energize();

        Assert.IsTrue(hasGlow);
        Assert.IsFalse(hasGlow2);

        Assert.AreEqual(0, jellyfish.Energy);

        jellyfish.ResetFlash();
        var hasGlow3 = jellyfish.Energize();

        Assert.IsFalse(hasGlow3);
        Assert.AreEqual(1, jellyfish.Energy);
    }



}
