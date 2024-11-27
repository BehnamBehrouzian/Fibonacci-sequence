
class Program
{
    static void Main()
    {
        Console.WriteLine("enter number 1:");
        int num1 = int.Parse(Console.ReadLine());

        Console.WriteLine("enter number2:");
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("enter number 3:");
        int num3 = int.Parse(Console.ReadLine());

        Console.WriteLine($"the number between {num1} and {num2} are:");

        bool found = GenerateFibonacci(ref num2, num1, num3);

        if (found)
        {
            Console.WriteLine($"{num3} is in.");
        }
        else
        {
            Console.WriteLine($"{num3} not in.");
            bool canBeInSequence = AdjustSecondNumber(ref num2, num1, num3);
            if (canBeInSequence)
            {
                Console.WriteLine($"number 2 changed to {num2}:");
                GenerateFibonacci(ref num2, num1, num3);
            }
            else
            {
                bool canBeInSequenceAfterFirst = AdjustFirstNumber(ref num1, ref num2, num3);
                if (canBeInSequenceAfterFirst)
                {
                    Console.WriteLine($"number1 changed to {num2}");
                    GenerateFibonacci(ref num2, num1, num3);
                }
                else
                {
                    Console.WriteLine($"the number 3 cannot be in the sequence");
                }
            }
        }
    }
    static bool GenerateFibonacci(ref int num2, int start, int target)
    {
        int a = start, b = num2;
        bool found = false;

        while (b < start)
        {
            int temp = a + b;
            a = b;
            b = temp;
        }
        while (b <= target)
        {
            Console.WriteLine(b);

            if (b == target)
            {
                found = true;
            }

            int temp = a + b;
            a = b;
            b = temp;
        }

        return found;
    }
    static bool AdjustSecondNumber(ref int num2, int start, int target)
    {
        int a = start;
        bool found = false;
        for (int newNum2 = start + 1; newNum2 <= target; newNum2++)
        {
            int b = newNum2;
            int i = 0;
            while (b < target)
            {
                int temp = a + b;
                a = b;
                b = temp;

                if (b == target)
                {
                    found = true;
                    num2 = newNum2;
                    break;
                }
            }

            if (found)
                break;
        }

        return found;
    }
    static bool AdjustFirstNumber(ref int num1, ref int num2, int target)
    {
        bool found = false;
        for (int newNum1 = target - num2; newNum1 <= target; newNum1++)
        {
            int a = newNum1;
            int b = num2;

            while (b < target)
            {
                int temp = a + b;
                a = b;
                b = temp;

                if (b == target)
                {
                    found = true;
                    num1 = newNum1;
                    break;
                }
            }

            if (found)
                break;
        }

        return found;
    }
}