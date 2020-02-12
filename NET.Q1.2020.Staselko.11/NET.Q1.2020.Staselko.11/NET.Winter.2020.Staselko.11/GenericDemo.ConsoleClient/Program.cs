using GenericsDemo;
using System;
using System.Collections.Generic;
using NumberExtension;
using GenericDemo.Tests.Predicates;
using GenericsDemo.Interfaces;
namespace GenericDemo.ConsoleClient
{
    static class Program
    {
        static void Main(string[] args)
        {
            var source = new int[] {12, 35, -65, 543, 23};

            //source.FilterBy(new DigitPredicateAdapty(new PredicateDigit() { Digit = 5 }))
            //    .FilterBy(new OddPredicate());
            
            source.OrderAccordingTo(new IntegerComparer());
            for (int i = 0; i < source.Length; i++)
            {
                Console.WriteLine(source[i]);
            }
        }
    }
}