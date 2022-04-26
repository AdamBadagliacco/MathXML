using System;
using System.Xml;

//Press F5 to Run

namespace Mathml
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument xmlDoc = new XmlDocument(); 
            xmlDoc.Load("math.xml");

            XmlNodeList descriptions = xmlDoc.GetElementsByTagName("Description");
            XmlNodeList firstValues = xmlDoc.GetElementsByTagName("Value1");
            XmlNodeList secondValues = xmlDoc.GetElementsByTagName("Value2");

            //Verify equal amount of Elements in each list so calculations can be successfully performed
            if (descriptions.Count != firstValues.Count || descriptions.Count != secondValues.Count) {
                throw new ArgumentException("XML must contain the same amount of Description, Value1, and Value2 elements");
            }

            for (int i = 0; i < descriptions.Count; i++){
                Calculation myCalculation = new Calculation(descriptions[i].InnerText, firstValues[i].InnerText, secondValues[i].InnerText);
                Console.WriteLine(myCalculation.GetCalculation());

            }

            Console.WriteLine("Press Enter to Exit program");
            ConsoleKeyInfo lastKeyPressed = Console.ReadKey(true); //true here mean we won't output the key to the console, just cleaner in my opinion.
            while (lastKeyPressed.Key != ConsoleKey.Enter)
            {
                lastKeyPressed = Console.ReadKey(true);
            }
        }

        #region Static Methods to Debug
        static void TestCalculationClass(string description, string value1, string value2)
        {

            Calculation myCalculation = new Calculation(description, value1, value2);

            Console.WriteLine("Joe – SUM – 40 + 2 = 42");
            Console.WriteLine(myCalculation.GetCalculation());
            
        }

        static void TestCalculationClass()
        {
            Console.WriteLine("---Testing functionality of the Calculation Class---");

            string correctResult = "Joe – SUM – 40 + 2 = 42";

            string description = "Joe;SUM;TURN10";
            string value1 = "40";
            string value2 = "2";
            Calculation myCalculation = new Calculation(description, value1, value2);
            string actualResult = myCalculation.GetCalculation();

            if (string.Equals(correctResult, actualResult)) {
                Console.WriteLine("Success! The actual result was the correct result.");
                Console.WriteLine("correctResult: " + correctResult);
                Console.WriteLine("actualResult: " + actualResult);
            }
            else {
                Console.WriteLine("Failure! The actual result was NOT the correct result.");
                Console.WriteLine("correctResult: " + correctResult);
                Console.WriteLine("actualResult: " + actualResult);
            }

            myCalculation.PrintToDebugObject();
        }
        #endregion
    }
}
