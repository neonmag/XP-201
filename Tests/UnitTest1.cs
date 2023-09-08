using App; // додати залежність (Dependency) від проєкту App
using NuGet.Frameworks;

namespace Tests
{
    [TestClass]
    public class UnitTestApp
    {
        [TestMethod]
        public void TestToString()
        {
            Dictionary<int, String> testCases = new()
            {
                { 1, "I" },
                { 2, "II" },
                { 3, "III" },
                { 4, "IV" },
                { 5, "V" },
                { 51, "LI" },
                { 52, "LII" },
                { 105, "CV" },
                { 115, "CXV" },
                { 107, "CVII" },
                { 1007, "MMVII" },
                { 2107, "MMMMCVII" },
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(testCase.Value, new RomanNumber(testCase.Key).ToString());
            }
        }
        private static Dictionary<String, int> parseTests = new()
        {
            { "I"          , 1    },
            { "II"         , 2    },
            { "III"        , 3    },
            { "IIII"       , 4    }, // Особливі твердження - з них ми визначаємо про
            { "IV"         , 4    }, // підтримку неоптимальних записів чисел
            { "V"          , 5    },
            { "VI"         , 6    },
            { "VII"        , 7    },
            { "VIII"       , 8    },
            { "IX"         , 9    },
            { "X"          , 10   },
            { "VV"         , 10   },  // Ще одне наголошення неоптимальності
            { "IIIIIIIIII" , 10   },  // Ще одне наголошення неоптимальності
            { "VX"         , 5    },  // Ще одне наголошення неоптимальності
            { "N"          , 0    },  // Доповнюємо множину чисел нулем
            { "-L"         , -50  },
            { "-XL"        , -40  },
            { "-IL"        , -49  },  // Неоптимальність
            { "-D"         , -500 },
            { "-C"         , -100 },
            { "-M"         , -1000 },
            { "D"          , 500 },
            { "C"          , 100 },
            { "M"          , 1000 },
            { "IM"         , 999 },
            { "-IM"        , -999 },
            { "IC"         , 99 },
            { "-IC"        , -99 },
            { "ID"         , 499 },
            { "-ID"        , -499 },
            { "VM"         , 995 },
            { "-VM"        , -995 },
            { "VC"         , 95 },
            { "-VC"        , -95 },
            { "VD"         , 495 },
            { "-VD"        , -495 },
            { "XM"         , 990 },
            { "-XM"        , -990 },
            { "XC"         , 90 },
            { "-XC"        , -90 },
            { "XD"         , 490 },
            { "-XD"        , -490 },
            { "MI"         , 1001 },
            { "-MI"        , -1001 },
            { "CI"         , 101 },
            { "-CI"        , -101 },
            { "DI"         , 501 },
            { "-DI"        , -501 },
            { "MV"         , 1005 },
            { "-MV"        , -1005 },
            { "CV"         , 105 },
            { "-CV"        , -105 },
            { "DV"         , 505 },
            { "-DV"        , -505 },
            { "MX"         , 1010 },
            { "-MX"        , -1010 },
            { "CX"         , 110 },
            { "-CX"        , -110 },
            { "DX"         , 510 },
            { "-DX"        , -510 },/////////////  
            {"LX"          , 60 },
            {"LXII"        , 62 },
            {"CCL"         , 250 },
            {"-CCIII"      , -203 },
            {"-LIV"        ,  -54},
            {"MDII"        , 1502 },
            //{"-CCM"        , -800 },
            {"DD"          ,1000 },
            {"CCCCC"       ,500 },
            {"IVIVIVIVIV"  ,20 },
            {"CDIV"        ,404},
            {"CDIV\t"        ,404},
            {"CDIV\n"        ,404},
            {"CDIV "        ,404},
            {" CDIV "        ,404},
            {"\tCDIV\n"        ,404},
            { "CCCC"         , 400 },
            { "LM"         , 950 },
            { "CDX"         , 410 },
            { "DDD"         , 1500 },
            { "MDCC"         , 1700 },
            { "DDDIV"         , 1504 },
            { "MMMM"         , 4000 },
            { "-MMMM"         , -4000 },
            { "-MMM"         , -3000 },
            { "MMM"         , 3000 },
            { "MMMMI"         , 4001 },
            { "-MMMMI"         , -4001 },
            { "-MMMI"         , -3001 },
            { "MMMI"         , 3001 },
            { "MMMMV"         , 4005 },
            { "-MMMMV"         , -4005 },
            { "-MMMV"         , -3005 },
            { "MMMV"         , 3005 },
            { "MMMMX"         , 4010 },
            { "-MMMMX"         , -4010 },
            { "-MMMX"         , -3010 },
            { "MMMX"         , 3010 },
            { "MMMMXV"         , 4015 },
            { "-MMMMXV"         , -4015 },
            { "-MMMXV"         , -3015 },
            { "MMMXV"         , 3015 },
        };

        [TestMethod]
        public void TestRomanNumberParseValid()
        {
            /*Assert.AreEqual(            // RomanNumber.Parse("I").Value == 1
                1,                      // Значення, що очікується (що має бути, правильний варіант)
                RomanNumber             // Актуальнее значення (те, що вирахуване)
                    .Parse("I")         //  
                    .Value,             //
                "1 == I"                //
                );                      // Повідомленя, що з'явиться при провалі тесту
            Assert.AreEqual(
                2,
                RomanNumber
                    .Parse("II")
                    .Value,
                "2 == II"
                );
            Assert.AreEqual(
                3,
                RomanNumber
                    .Parse("III")
                    .Value,
                "3 == III"
                );*/
            foreach (var pair in parseTests)
            {
                Assert.AreEqual(
               pair.Value,
               RomanNumber
                   .Parse(pair.Key)
                   .Value,
               $"{pair.Key} == {pair.Value}"
               );
            }

        }

        [TestMethod]
        public void TestRomanNumberParseNonValid()
        {
            // Тестування з неправильними формами чисел
            Assert.ThrowsException<ArgumentException>(
            () => RomanNumber.Parse(""),
            "'' -> Exception");
            Assert.ThrowsException<ArgumentException>(
            () => RomanNumber.Parse(null!),
            "null -> Exception");
            Assert.ThrowsException<ArgumentException>(
            () => RomanNumber.Parse("   "),
            "\"    \"    -> Exception");
            // Саме виключення, що виникло у лямбді, повертається як рез-т
            var ex = Assert.ThrowsException<ArgumentException>(
            () => RomanNumber.Parse("XBC"),
            "ABC -> Exception");
            Assert.IsTrue(ex.Message.Contains('B'), "ex.Message.Contains 'B' ");
            ex = Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse("ABC"),
                "'' -> Exception");
            Assert.IsTrue(ex.Message.Contains('A') || ex.Message.Contains('B'),
                "'ABC' ex.Message should contain either 'A' or 'B'");
            // вимагаємо, щоб відомості про неправильну цифру ("В") було
            // включено у повідомлені виключення
            Assert.IsFalse(
                   ex.Message.Length < 15,
                   "ex.Message.Length min 15"
                   );
            Dictionary<String, char> testCases = new()
            {
                { "Xx", 'x' },
                { "Xy", 'y' },
                { "AX", 'A' },
                { "X C", ' ' },
                { "X\tC", '\t' },
                { "X\nC", '\n' },
            };
            foreach (var pair in testCases)
            {
                // Виключаємо змінну ex, робимо вкладені вирази
                Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse(pair.Key),
                $"'{pair.Key}' -> ArgumentException").Message.Contains($"'{pair.Value}'"),
                $"'{pair.Key}' ex.Message sould contains '{pair.Value}'");
            }
        }

        [TestMethod]
        public void TestRomanNumberParseIllegal()
        {
            Assert.ThrowsException<ArgumentException>(
             () => RomanNumber.Parse("IIX"),
             "IIX -> Exception");
        }
    }
}
/* Тестування виключень
 * У системі тестування виключення - провали тесту.
 * Тому вирази, що мають завершуватись виключеннями, оточують 
 * функціональними виразами (лямбдами). Це дозволяє перенести
 * появу виключення у середину тестового методу, де воно буде 
 * оброблене належним чином.
 * Особливості: 
 * - перевіряється суворий збіг типів виключень, більш загальний
 *      тип не зараховується як проходження тесту
 * - тест повертає викинуте виключення, це дозволяє накласти
 *      умови на повідомлення, причину, тощо
 *      
 *      
 * Слухання?
 * які з комбінацій вважати правильними, які ні
 * 'X C', 'XC', 'XC ', 'XC\t', '\nXC', 'XC\n', 'X\nC'
 *   x      v     v       v        v       v       x
 */
/* Основу модульних тестів складають твердження (Asserts).
 * У твердженні фігурують два значення: те, що очікується, та
 * те, що одержується.
 * Більшість тестів перевіряють рівність (об'єктну AreSame чи контентну AreEqual),
 * або у скороченій формі (IsTrue, IsNotNull, ....)
 */