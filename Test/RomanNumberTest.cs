using App;

namespace Test
{
    [TestClass]
    public class RomanNumberTest
    {
        private readonly Dictionary<String, int> _digitValues = new()
        {
            { "N", 0    },
            { "I", 1    },
            { "V", 5    },
            { "X", 10   },
            { "L", 50   },
            { "C", 100  },
            { "D", 500  },
            { "M", 1000 },
        };

        [TestMethod]
        public void ParseTest()
        {
            Dictionary<String, int> testCases = new()
            {
                { "N",    0 },
                { "I",    1 },
                { "II",   2 },
                { "III",  3 },
                { "IIII", 4 },   // цим тестом ми дозволяємо неоптимальну форму числа
                { "IV",   4 },
                { "VI",   6 },
                { "VII",  7 },
                { "VIII", 8 },
                { "IX",   9 },
                { "D",    500 },
                { "M",    1000 },
                { "CM",   900 },
                { "MC",   1100 },
                { "MCM",  1900 },
                { "MM",   2000 },
            };
            foreach (var testCase in testCases)
            {
                RomanNumber rn = RomanNumber.Parse(testCase.Key);
                Assert.IsNotNull(rn);
                Assert.AreEqual(
                    testCase.Value, 
                    rn.Value, 
                    $"{testCase.Key} -> {testCase.Value}"
                );
            }
            Dictionary<String, Object[]> exTestCases = new()
            {
                { "W", ['W', 0] },
                { "Q", ['Q', 0] },
                { "s", ['s', 0] },
                { "sX", ['s', 0] },
                { "Xd", ['d', 1] },
            };
            foreach (var testCase in exTestCases)
            {
                var ex = Assert.ThrowsException<FormatException>(
                    () => RomanNumber.Parse(testCase.Key),
                    $"Parse '{testCase.Key}' must throw FormatException"
                );
                Assert.IsTrue(
                    ex.Message.Contains(
                        $"Invalid symbol '{testCase.Value[0]}' in position {testCase.Value[1]}"
                    ),
                    "FormatException must contain data about symbol and its position"
                    + $"testCase: '{testCase.Key}', ex.Message: '{ex.Message}'"
                );
            }
            Dictionary<String, Object[]> exTestCases2 = new()
            {
                { "IM",  ['I', 'M', 0] },
                { "XIM", ['I', 'M', 1] },
                { "IMX", ['I', 'M', 0] },
                { "XMD", ['X', 'M', 0] },
                { "XID", ['I', 'D', 1] },
            };
            foreach (var testCase in exTestCases2)
            {
                var ex = Assert.ThrowsException<FormatException>(
                    () => RomanNumber.Parse(testCase.Key),
                    $"Parse '{testCase.Key}' must throw FormatException"
                );
                Assert.IsTrue(
                    ex.Message.Contains(
                        $"Invalid order '{testCase.Value[0]}' before '{testCase.Value[1]}' in position {testCase.Value[2]}"
                    ),
                    "FormatException must contain data about mis-ordered symbols and its position"
                    + $"testCase: '{testCase.Key}', ex.Message: '{ex.Message}'"
                );
            }
        }

        [TestMethod]
        public void DigitValueTest()
        {           
            foreach (var testCase in _digitValues)
            {
                Assert.AreEqual(
                    testCase.Value, 
                    RomanNumber.DigitValue(testCase.Key),
                    $"{testCase.Key} -> {testCase.Value}"
                );
            }
            Random random = new();
            for (int i = 0; i < 100; ++i)
            {
                String invalidDigit = ((char) random.Next(256)).ToString();
                if(_digitValues.ContainsKey(invalidDigit))
                {
                    --i;
                    continue;
                }
                ArgumentException ex =
                    Assert.ThrowsException<ArgumentException>(
                        () => RomanNumber.DigitValue(invalidDigit),
                        $"ArgumentException expected for digit = '{invalidDigit}'"
                    );
                // вимагатимемо від винятку
                // - повідомлення, що
                //  = не є порожнім
                //  = містить назву аргументу (digit)
                //  = містить значення аргументу, що призвело до винятку
                //  = назву класу та методу, що викинув виняток
                Assert.IsFalse(
                    String.IsNullOrEmpty(ex.Message),
                    "ArgumentException must have a message"
                );
                Assert.IsTrue(
                    ex.Message.Contains($"'digit' has invalid value '{invalidDigit}'"),
                    "ArgumentException message must contain <'digit' has invalid value ''>"
                );
                Assert.IsTrue(
                    ex.Message.Contains(nameof(RomanNumber)) &&
                    ex.Message.Contains(nameof(RomanNumber.DigitValue)),
                    $"ArgumentException message must contain '{nameof(RomanNumber)}' and '{nameof(RomanNumber.DigitValue)}' "
                );
            }
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
                { 999, "CMXCIX" },   // непрямо - заборона IM
                { 444, "CDXLIV" },
                { 990, "CMXC" },   // непрямо - заборона XM
            };

            _digitValues.Keys.ToList().ForEach(k => testCases.Add(_digitValues[k], k));
            
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
/* Д.З. Збільшити кількість тестових кейсів виняткових ситуацій ParseTest
 * які відстежують неправильне розташування символів (IM, ID, XM, ...)
 * у різних позиціях
 * * додати кейси з іншими неправильними комбінаціями (VV, LL, LC, VX, ...)
 *    внести зміни в алгоритм парсингу
 * 
 * 
 * 
 * 
 * 
 */
