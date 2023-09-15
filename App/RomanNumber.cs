using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace App
{
    public class RomanNumber
    {
        private const char ZERO_DIGIT = 'N';
        private const char MINUS_DIGIT = '-';
        private const char QUOTE_DIGIT = '\'';
        private const String INVALID_ROMAN_DIGIT = "Invalid Roman digits(s):";
        private const String EMPTY_INPUT_MESSAGE = "Null or empty input";
        private const String DIGITS_SEPARATOR = ", ";
        private const String ADD_NULL_MESSAGE = "Cannot Add null object";
        private const String NULL_MESSAGE_PATTERN = "{0}: '{1}'";

        public int Value { get; set; }
        public RomanNumber(int value = 0)
        {
            Value = value;
        }

        public override string ToString()
        {
            // Відобразити у оптимальному виді
            Dictionary<int, string> parts = new()
            {
                { 1000, "M" },
                { 900, "CM" },
                { 600, "DC" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 6, "VI" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" }
            };
            if (Value == 0) return ZERO_DIGIT.ToString();
            bool isNegative = Value < 0;
            var number = isNegative ? -Value : Value;
            StringBuilder sb = new();
            if (isNegative) sb.Append(MINUS_DIGIT);
            foreach (var part in parts)
            {
                while (number >= part.Key)
                {
                    sb.Append(part.Value);
                    number -= part.Key;
                }
            }
            return sb.ToString();
        }
        private static int DigitValue(char digit)
        {
            return digit switch
            {
                ZERO_DIGIT => 0,
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException($"{INVALID_ROMAN_DIGIT}{digit}{QUOTE_DIGIT}")
            } ;
        }

        private static void CheckLegalityOrThrow(String input)
        {
            int maxDigit = 0;
            int lessDigitsCount = 0;
            int lastDigitIndex = input.StartsWith(MINUS_DIGIT) ? 1 : 0;
            int digitValue = 0;

            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                digitValue = DigitValue(input[i]);
                if (digitValue < maxDigit && ++lessDigitsCount > 1)
                    throw new ArgumentException(input);

                maxDigit = digitValue > maxDigit ? digitValue : maxDigit;
                lessDigitsCount = digitValue < maxDigit ? 1 : 0;
            }
        }

        private static void CheckValidityOrThrow(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException(EMPTY_INPUT_MESSAGE);
            }
            if (input.StartsWith(MINUS_DIGIT))
                input = input[1..];
            List<char> invalidChars = new();
            foreach (char c in input)
            {
                try { DigitValue(c); }
                catch { invalidChars.Add(c); }
            }
            if (invalidChars.Count > 0)
            {
                String chars = String.Join(DIGITS_SEPARATOR, invalidChars.Select(
                    c => $"'{QUOTE_DIGIT}{c}{QUOTE_DIGIT}'"));
                throw new ArgumentException($"Invalid Roman didgit in digits: {chars}");
            }
        }
        public RomanNumber Add(RomanNumber other)
        {
            if (other is null)
                throw new ArgumentNullException(String.Format(NULL_MESSAGE_PATTERN, ADD_NULL_MESSAGE, nameof(other)));
            return new (this.Value + other.Value );
        }
        public static RomanNumber Parse(String input)
        {

            input = input?.Trim()!; // видалення початкових та кінцевих пробільних символів

            CheckValidityOrThrow(input);
            CheckLegalityOrThrow(input);
            if (input == ZERO_DIGIT.ToString()) return new();

            int lastDigitIndex = input[0] == MINUS_DIGIT ? 1 : 0;

            int prev = 0;
            int result = 0;
            int current = 0;


            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {

                //if (current == 0)
                //    throw new ArgumentException($"Invalid Roman digit in parse: '{input[i]}'");
                current = DigitValue(input[i]);
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


