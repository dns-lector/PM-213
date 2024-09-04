using App;

namespace Test
{
    [TestClass]
    public class RomanNumberTest
    {
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
        }

        [TestMethod]
        public void DigitValueTest()
        {
            Dictionary<String, int> testCases = new()
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
            foreach (var testCase in testCases)
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
    }
}
/* Д.З. Збільшити кількість тестових кейсів для ParseTest
 * Використовувати як оптимальні, так і неоптимальні форми чисел.
 * Перевірити працездатність шляхом включення неправильних кейсів
 * 
 * 
 * 
 * 
 * 
 * 
 */
