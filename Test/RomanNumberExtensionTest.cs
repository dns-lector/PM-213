using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class RomanNumberExtensionTest
    {
        [TestMethod]
        public void PlusTest()
        {
            RomanNumber
                rn0 = new(0),
                rn1 = new(1),
                rn2 = new(2);

            Assert.AreEqual(
                3,
                rn1.Plus(rn2).Value
            );
            Assert.AreEqual(
                5,
                rn1.Plus(rn2).Plus(rn2).Value
            );
            Assert.AreEqual(
                4,
                rn1.Plus(rn1).Plus(rn2).Value
            );
            Assert.AreEqual(
                4,
                rn1.Plus(rn1, rn2, rn0).Value
            );
            Assert.AreNotSame(rn1, rn1.Plus(rn1));
            Assert.AreNotSame(rn1, rn1.Plus(rn0));
        }
    }
}
