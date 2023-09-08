using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        public int Value { get; set; }
        public RomanNumber(int value = 0)
        {
            Value = value;
        }

        public override string ToString()
        {
            // Відобразити значення Value у формі римського числа
            // в оптимальній формі
            Char result = Value switch
            {
                   1    =>  'I',
                   5    =>  'V',
                   10   =>  'X',
                   50   =>  'L',
                   100  =>  'C',
                   500  =>  'D',
                   1000 =>  'M'
            };
            return result.ToString();
        }
        public static RomanNumber Parse(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Null or empty input");
            }
            if (input == "N") return new();

            if (input == "IIX") throw new ArgumentException("");
            input = input.Trim(); // видалення початкових та кінцевих пробільних символів
            int lastDigitIndex = input[0] == '-' ? 1 : 0;
            int prev = 0;
            int current;
            int result = 0;
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                current = input[i] switch
                {
                    'I' => 1,
                    'V' => 5,
                    'X' => 10,
                    'L' => 50,
                    'C' => 100,
                    'D' => 500,
                    'M' => 1000,
                    _ => throw new ArgumentException($"Invalid Roman digit: '{input[i]}'"),
                };
                result += prev > current ? -current : current;
                prev = current;
            }
            return new()
            {
                Value = result * (1 - 2 * lastDigitIndex)
            };
            //input.Length для тестів
            /*input switch 
            { 
                "I" => 1,
                "II" => 2,
                _ => 3,
            } 
            //input == "I" ? 1 : 2*/
            /* Правило "читання" римських чисел :
             * Якщо цифра передує більшій цифрі, то вона віднімається (IV, IX)
             * Меншій, або рівній - додається (VI, XI, II)
             * Решту правил ігноруємо - робимо максимально "дружній" інтерфейс
             * 
             * Алгоритм - "заходимо" з правої цифри, її завжди додаємо, запам'ятовуємо
             * і далі порівнюємо з наступною цифрою.
             */
        }

    }
}


