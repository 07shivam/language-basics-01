using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

   
        public static int FindDigit(string equation)
        {
                         // string equation = "42*47=1?74";
            //throw new NotImplementedException();
            int equationlength = equation.Length;
                         // cout << equationlength;
            int OperatorM=-1, Equalto=-1, QuestionM=-1;
            for (int i = 0; i < equationlength; i++)
            {
                if (equation[i] == '*')
                    OperatorM = i;

                if (equation[i] == '=')
                    Equalto = i;

                if (equation[i] == '?')
                    QuestionM = i;
            }
        //  cout<<OperatorM<<Equalto<<QuestionM;

            int A, B, C;
            if (QuestionM > Equalto && QuestionM > OperatorM)
            {
            //work on A and B
                A = ConvertInt(equation, 0, OperatorM);
                B = ConvertInt(equation, OperatorM, Equalto);

                int ActualResult = A * B;
                string ActualResultString = ActualResult.ToString();

                string ProvidedAnswer = "";
                for (int i = Equalto + 1; i < equationlength; i++)
                {
                    ProvidedAnswer += equation[i];
                }
                if(ProvidedAnswer.Length!=ActualResultString.Length)
                {
                    return -1;
                }
                int result = findMissingDigit(ActualResultString, ProvidedAnswer);
                return result;

            //cout<<ProvidedAnswer;

            }
            if (QuestionM < OperatorM && QuestionM < Equalto)
            {
            //work on B and C
                B = ConvertInt(equation, OperatorM,Equalto);
                C = ConvertInt(equation, Equalto, equationlength);

                if (B == 0)
                {
                    return 0;
                }
                int ActualResult = C / B;
                string ActualResultString = ActualResult.ToString();

                string ProvidedAnswer = "";
                for (int i = 0; equation[i] != '*'; i++)
                {
                    ProvidedAnswer += equation[i];
                }
               //  Console.WriteLine("ActualResult"+ActualResult);
              //  Console.WriteLine("B"+B);
              //  Console.WriteLine("c"+C);

               // Console.WriteLine("ProvidedAnswer"+ProvidedAnswer);
               if(ProvidedAnswer.Length!=ActualResultString.Length)
                {
                    return -1;
                }
                int result = findMissingDigit(ActualResultString, ProvidedAnswer);
                return result;

            }
            if (QuestionM > OperatorM && QuestionM < Equalto)
            {
            //work on A and C
                A = ConvertInt(equation, 0, OperatorM);
                C = ConvertInt(equation, Equalto, equationlength);
                if (A == 0)
                {
                    return 0;
                }
                int ActualResult = C / A;
                string ActualResultString = ActualResult.ToString();

                string ProvidedAnswer = "";
                for (int i = OperatorM + 1; equation[i] != '='; i++)
                {
                    ProvidedAnswer += equation[i];
                }
                if(ProvidedAnswer.Length!=ActualResultString.Length)
                {
                    return -1;
                }
                int result = findMissingDigit(ActualResultString, ProvidedAnswer);
                return result;
            }
            else
            {
            return -1;
            }
        }


       public static int ConvertInt(string equation, int Start, int End)
        {
            int i;
            if (Start == 0)
            {
                i = Start;
            }
            else
            {
                i = Start + 1;
            }

            int argument = 0;
            while (i != End)
            {
                argument = argument * 10 + equation[i] - '0';
                ++i;
            }
            return argument;
        }

        public static int findMissingDigit(string ActualResultString, string ProvidedAnswer)
        {
            int result = 0 ;
            for (int i = 0; i< ActualResultString.Length; i++)
            {
                if (ActualResultString[i] != ProvidedAnswer[i] && ProvidedAnswer[i] == '?')
                {
                    result = ActualResultString[i] - '0';
                    return result;
                }
            }
            return result;

        }
    }
}
