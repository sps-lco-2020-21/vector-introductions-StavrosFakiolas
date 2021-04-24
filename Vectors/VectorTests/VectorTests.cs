using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vectors.App;
using System;

namespace VectorTests
{
    [TestClass]
    public class UnitTest1
    {

        List<double> l1 = new List<double> { 2, 5, 6 };
        List<double> l2 = new List<double> { 1, 5 };
        List<double> l3 = new List<double> { 0, 5, 10 };
        List<double> l4 = new List<double> { 3, 4};

        [TestMethod]
        public void VectorAddition()
        {
            List<double> expectedSum = new List<double> { 3, 10, 6 };
            Vector myVector1 = new Vector(l1);
            Vector myVector2 = new Vector(l2);
            Vector addition = myVector1.Add(myVector2);
            Assert.IsTrue(addition.SameVector(new Vector(expectedSum)));
            Assert.IsTrue(myVector2.SameVector(new Vector(l2)));
        }
        
        [TestMethod]
        public void VectorScalar()
        {
            List<double> expectedResult = new List<double> { 6, 15, 18 };
            Vector myVector1 = new Vector(l1);
            Vector scale = myVector1.ScalarMultiple(3);
            Assert.IsTrue(scale.SameVector(new Vector(expectedResult)));
        }
        
        [TestMethod]
        public void DotProduct()
        {
            double expectedResult = 85;
            Vector myVector1 = new Vector(l1);
            Vector myVector3 = new Vector(l3);
            double dotprod = myVector1.DotProductA(myVector3);
            Assert.AreEqual(dotprod, expectedResult);
        }

        [TestMethod]
        public void MagnitudeCheck()
        {
            Vector myVector4 = new Vector(l4);
            Assert.AreEqual(5,myVector4.Magnitude);
        }
        
        [TestMethod]
        public void CheckSizeCorrection()
        {
            Vector myVector2 = new Vector(l2);
        }
    }
}
