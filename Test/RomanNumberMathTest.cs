using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class RomanNumberMathTest
    {
        [TestMethod]
        public void PlusTest()
        {
            RomanNumber
                rn1 = new(1),
                rn2 = new(2),
                rn3 = new(3);

            Assert.AreEqual(
                6,
                RomanNumberMath.Plus(rn1, rn2, rn3).Value
            );
            Assert.AreEqual(
                6,
                RomanNumberMath.Plus([rn1, rn2, rn3]).Value
            );
        }
    }


    //[TestMethod]
    //public void PlusTest()
    //{
    //    RomanNumber rn1 = new(1);
    //    RomanNumber rn2 = new(2);
    //    var rn3 = rn1.Plus(rn2);
    //    Assert.IsNotNull(rn3);
    //    Assert.IsInstanceOfType(rn3, typeof(RomanNumber), 
    //        "Plus result mast have RomanNumber type");
    //    Assert.AreNotSame(rn3, rn1, 
    //        "Plus result is new instance, neither (v)first, nor second arg");
    //    Assert.AreNotSame(rn3, rn2, 
    //        "Plus result is new instance, neither first, nor (v)second arg");
    //    Assert.AreEqual(rn1.Value + rn2.Value, rn3.Value, 
    //        "Plus arithmetic");
    //}
}
