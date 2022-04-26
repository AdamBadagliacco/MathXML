using System;

namespace Mathml
{
    class Calculation
    {
        string username;
        enum OperationName { SUM, SUB, MULTIPLY, DIVIDE, POWER};
        OperationName operationName;
        char operationChar;
        string miscellaneousInfo;

        float value1;
        float value2;

        float calculationResult;

        public Calculation(string description, string value1String, string value2String) {

            
            if (!float.TryParse(value1String, out value1))
            {
                value1 = WordsToNumbers.ConvertToFloat(value1String);
            }
           
            if (!float.TryParse(value2String, out value2))
            {
                value2 = WordsToNumbers.ConvertToFloat(value2String);
            }

            int positionOfFirstSemiColon = description.IndexOf(";");
            int positionOfSecondSemiColon = positionOfFirstSemiColon + description.Substring(positionOfFirstSemiColon+1).IndexOf(";") + 1;

            username = description.Substring(0, positionOfFirstSemiColon);
            miscellaneousInfo = description.Substring(positionOfSecondSemiColon+1);

            string operation = description.Substring(positionOfFirstSemiColon+1, positionOfSecondSemiColon- positionOfFirstSemiColon-1);

            if (operation.Contains("SUM"))
            {
                operationName = OperationName.SUM;
                operationChar = '+';
                calculationResult = value1 + value2;
            }
            else if (operation.Contains("SUB"))
            {
                operationName = OperationName.SUB;
                operationChar = '-';
                calculationResult = value1 - value2;
            }
            else if (operation.Contains("MULTIPLY"))
            {
                operationName = OperationName.MULTIPLY;
                operationChar = '*';
                calculationResult = value1 * value2;
            }
            else if (operation.Contains("DIVIDE"))
            {
                operationName = OperationName.DIVIDE;
                operationChar = '/';
                calculationResult = value1 / value2;
            }
            else if (operation.Contains("POWER"))
            {
                operationName = OperationName.POWER;
                operationChar = '^';
                calculationResult = (float)Math.Pow((double)value1, (double)value2);
            }
        }

        public string GetCalculation() {
            return username + " – " + operationName.ToString() + " – " + value1 + " " + operationChar + " " + value2 + " = " + calculationResult;
        }

        public void PrintToDebugObject()
        {
            Console.WriteLine("username: " + username);
            Console.WriteLine("operationName: " + operationName);
            Console.WriteLine("operationChar: " + operationChar);
            Console.WriteLine("miscellaneousInfo: " + miscellaneousInfo);

            Console.WriteLine("value1: " + value1);
            Console.WriteLine("value2: " + value2);

            Console.WriteLine("calculationResult: " + calculationResult);
        }


    }
}