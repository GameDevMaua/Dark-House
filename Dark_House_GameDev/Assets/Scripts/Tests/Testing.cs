using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class Testing
{
    
    [Test]
    public void Hello_World_Test() {
        int kappa = 42;

        Assert.AreEqual(42, kappa);

    }


}
