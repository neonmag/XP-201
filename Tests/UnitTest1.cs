using App; // додати залежність (Dependency) від проєкту App
namespace Tests
{
    [TestClass]
    public class UnitTestApp
    {
        [TestMethod]
        public void TestRomanNumberParse()
        {
            Assert.AreEqual(            // RomanNumber.Parse("I").Value == 1
                1,                      // Значення, що очікується (що має бути, правильний варіант)
                RomanNumber             // Актуальнее значення (те, що вирахуване)
                    .Parse("I")         //  
                    .Value,             //
                "1 == I"                //
                );                      // Повідомленя, що з'явиться при провалі тесту
            
        }
    }
}
/* Основу модульних тестів складають твердження (Asserts).
 * У твердженні фігурують два значення: те, що очікується, та
 * те, що одержується.
 * Більшість тестів перевіряють рівність (об'єктну AreSame чи контентну AreEqual),
 * або у скороченій формі (IsTrue, IsNotNull, ....)
 */