using System;

namespace MyRegExApp
{
    /*
     * In C#, write a program that parses a sentence and replaces each word with the following: 
     * first letter, number of distinct characters between first and last character, and last letter. 
     * For example, Smooth would become S3h. Words are separated by spaces or non-alphabetic characters 
     * and these separators should be maintained in their original form and location in the answer.

    The code must be syntactically correct and build in visual studio, either as a console or winforms application.
     */
    public static class Program
    {
        public static void Main(string[] args)
        {
            string text = "$0Hello9world10Hi$World!_some_  othreer&charar_A_end+";
            //string text = "Hello9world10Hi$World!_some_  othreer&charar_A_end+";
           // string text = "Hello9world10Hi$World!some othreer&charar_A_end+";
            Console.WriteLine(text.BuildNewSentance());
        }
    }
}
