using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{ 
    public class Calculator
    {
        public static double Calculate(double value1, double value2, string thisOperator)
        {
            double result = 0;

            switch(thisOperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "×":
                    result = value1 * value2;
                    break;
                case"+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }

            return result;
        }
    }
}
