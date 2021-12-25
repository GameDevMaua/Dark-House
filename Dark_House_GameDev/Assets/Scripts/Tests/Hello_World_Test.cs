using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class Hello_World_Test
{
    
    [Test]
    public void hello_world_test() {
        int theAnswer = 42;

        Assert.AreEqual(42, theAnswer);

    }


}
