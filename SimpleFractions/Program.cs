using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFractions
{
    public class SimpleFractions
    {
        int Numerator;
        int Denominator;

        public SimpleFractions(int N, int D)
        {
            if (D == 0)
            {
                throw new DevideByZeroException();
            }
            Numerator = N; Denominator = D;
        }

        //public int X { get; set; }

        
        public SimpleFractions()
        {
            Numerator = 1; Denominator = 1;
        }
        public static SimpleFractions operator +(SimpleFractions a, SimpleFractions b)
        {
            return new SimpleFractions(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator).Normalization();
        }
        public static SimpleFractions operator -(SimpleFractions a, SimpleFractions b)
        {
            return new SimpleFractions(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator).Normalization();
        }
        public static SimpleFractions operator *(SimpleFractions a, SimpleFractions b)
        {
            return new SimpleFractions(a.Numerator * b.Numerator, a.Denominator * b.Denominator).Normalization();
        }

        public static SimpleFractions operator /(SimpleFractions a, SimpleFractions b)
        {
            return new SimpleFractions(a.Numerator * b.Denominator, a.Denominator * b.Numerator).Normalization();
        }

        public SimpleFractions Normalization()// Fraction Normalization
        {
            return new SimpleFractions(Numerator / GetCommonDivisor(Numerator, Denominator), Denominator / GetCommonDivisor(Numerator, Denominator));
        }
        private static int GetCommonDivisor(int i, int j)//The ECLIDE'S algorith to find GCD
        {
            i = Math.Abs(i);
            j = Math.Abs(j);
            while (i != j)
                if (i > j) { i -= j; }
                else { j -= i; }
            return i;
        }
        private static int GetInt(int a, int b)//выделение целой части || selection of a whole part
        {
            int K;
            if (a > b)
            {
                K = a / b;
                return K;
            }
            return 0;
        }
        public SimpleFractions GetRest()// остаток от выделения целой части || The remainder of the selection of a whole part
        {
            return new SimpleFractions(Numerator - GetInt(Numerator, Denominator) * Denominator, Denominator);
        }
        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }
        public void display()
        { 
            Console.WriteLine(this.ToString()); 
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            try
            {
                SimpleFractions f1 = new SimpleFractions(1, 3);
                SimpleFractions f2 = new SimpleFractions(10, 5);

                double b,c = 1.5;
                b = (double)Math.Pow(c, 2);
                double a = 1.5;
                Console.WriteLine("{0}+{1}={2}", f1,f2,f1 + f2);
                Console.WriteLine("{0}-{1}={2}", f1, f2, f1 - f2);
                Console.WriteLine( "{0}*{1}={2}", f1,f2,f1 * f2);
                Console.WriteLine("{0}/{1}={2}", f1, f2, f1 / f2);
                Console.WriteLine(b);
                Console.WriteLine("{0}", -a);
                Console.WriteLine(a > 1.4); // Output True 
                Console.WriteLine(a < 1.2);//Output False
                Console.WriteLine(a==1.5);//Output True

                double m, n;
                Console.WriteLine("Enter the Fraction : ");
                m = double.Parse(Console.ReadLine());
                Console.WriteLine("Give the Exponent : ");
                n = double.Parse(Console.ReadLine());
                double value1 = Math.Pow(m, n);
                Console.WriteLine("The exponent of the number is : {0}", value1);
                

                //Console.WriteLine("UniLecs");
                //      long result = PowMod(3, 5, 6);
                //    Console.WriteLine(string.Format("Answer = {0}", result
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception caught:{0}", e.Message);
                Console.ReadKey();
            }
        }
        //private static long PowMod(long a, long b, long m)
        //{
          //  throw new NotImplementedException();
        //}
    }
}
