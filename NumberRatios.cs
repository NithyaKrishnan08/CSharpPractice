using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        int totalCount = arr.Count;
        int negativeCount = 0;
        int positiveCount = 0;
        int zeroCount = 0;
        
        foreach (int i in arr)
        {
            if (i < 0)
            {
                negativeCount++;
            }
            else if (i > 0)
            {
                positiveCount++;
            }
            else
            {
                zeroCount++;
            }
        }
        
        PrintRatio(positiveCount, totalCount);
        PrintRatio(negativeCount, totalCount);
        PrintRatio(zeroCount, totalCount);
    }
    
    public static void PrintRatio(int specificCount, int totalCount)
    {
        double ratio = (double)specificCount / totalCount;
        Console.WriteLine(ratio.ToString("F6"));
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}