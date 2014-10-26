using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        short a, b, c, d, e;
        a = short.Parse(Console.ReadLine());
        b = short.Parse(Console.ReadLine());
        c = short.Parse(Console.ReadLine());
        d = short.Parse(Console.ReadLine());
        e = short.Parse(Console.ReadLine());


        for (int devider = 4; devider < (100 * 100 * 100); devider++)
        {
            int devidersCount = 0;
            if (devider % a == 0) devidersCount++;
            if (devider % b == 0) devidersCount++;
            if (devider % c == 0) devidersCount++;
            if (devider % d == 0) devidersCount++;
            if (devider % e == 0) devidersCount++;

            if (devidersCount >= 3)
            {
                Console.WriteLine(devider);
                break;
            }
        }
    }
}
