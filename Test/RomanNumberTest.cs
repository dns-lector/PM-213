using App;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Reflection;

namespace Test
{
    [TestClass]
    public class RomanNumberTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var rn = new RomanNumber("IX");
            Assert.IsNotNull(rn);

            rn = new RomanNumber(3);
            Assert.IsNotNull(rn);
        }

        [TestMethod]
        public void ConvertTest()
        {
            var rn = new RomanNumber("IX");
            Assert.IsInstanceOfType<Int32>(rn.ToInt());
            Assert.IsInstanceOfType<UInt32>(rn.ToUnsignedInt());
            Assert.IsInstanceOfType<Int16>(rn.ToShort());
            Assert.IsInstanceOfType<UInt16>(rn.ToUnsignedShort());
            Assert.IsInstanceOfType<Single>(rn.ToFloat());
            Assert.IsInstanceOfType<Double>(rn.ToDouble());

        }

        [TestMethod]
        public void ToStringTest()
        {
            Dictionary<int, String> testCases = new() {   // Append / Concat
                { 2, "II" },
                { 3343, "MMMCCCXLIII" },
                { 4, "IV" },
                { 44, "XLIV" },
                { 9, "IX" },
                { 90, "XC" },
                { 1400, "MCD" },
                { 999, "CMXCIX" },   // ������� - �������� IM
                { 444, "CDXLIV" },
                { 990, "CMXC" },   // ������� - �������� XM
            };

            foreach (var (k, v) in RomanNumberFactoryTest.DigitValues)
            {
                testCases.Add(v, k);
            }
            
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    new RomanNumber(testCase.Key).ToString(),
                    $"ToString({testCase.Key}) --> {testCase.Value}"
                );
            }
        }

    }
}
/* �.�. �������� ������� �������� ����� ���������� �������� ParseTest
 * �� ���������� ����������� ������������ ������� (IM, ID, XM, ...)
 * � ����� ��������
 * * ������ ����� � ������ ������������� ����������� (VV, LL, LC, VX, ...)
 *    ������ ���� � �������� ��������
 * 
 * 
 * 
 * 
 * 
 */
