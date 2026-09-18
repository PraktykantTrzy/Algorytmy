using System;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine());

        while (T-- > 0)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
                sum += a[i];
            }

            bool[] dp = new bool[2 * sum + 1];
            int offset = sum;

            dp[offset] = true;

            int currentSum = 0;

            foreach (int x in a)
            {
                bool[] next = new bool[2 * sum + 1];

                for (int v = -currentSum; v <= currentSum; v++)
                {
                    if (!dp[v + offset])
                        continue;

                    next[v - x + offset] = true;
                    next[v + x + offset] = true;
                }

                dp = next;
                currentSum += x;
            }

            int min = int.MaxValue;
            int max = 0;

            for (int v = -sum; v <= sum; v++)
            {
                if (!dp[v + offset])
                    continue;

                int abs = Math.Abs(v);

                min = Math.Min(min, abs);
                max = Math.Max(max, abs);
            }

            Console.WriteLine($"{min} {max}");
        }
    }
}
