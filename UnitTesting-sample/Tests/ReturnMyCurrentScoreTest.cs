using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xunit;

namespace UnitTesting_sample.Tests
{
    public static class ReturnMyCurrentScoreTest
    {
        // NAming convention: ClassName_MethodName_ExpectedResult
        public static void ReturnMyCurrentScore_ReturnWelcomeIfZero_ReturnString()
        {
            try
            {

                // Arrange - get variables, instances, functions, classes to  be used to execute the function
                int num = 0;
                var currentScore = new FIrstUnitTestingClass();

                // Act - Execute the function
                var result = currentScore.ReturnMyCurrentScore(num);

                //Assert - whatever you return is it what you want?
                if(result == "WELCOME LUCAS")
                {
                    Console.WriteLine("PASSED: ReturnMyCurrentScore_ReturnWelcomeIfZero_ReturnString(");
                }
                else
                {
                    Console.WriteLine("FAILED: ReturnMyCurrentScore_ReturnWelcomeIfZero_ReturnString(");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
