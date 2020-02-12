using GenericsDemo.Interfaces;
using System;
using NumberExtension;
using System.Collections.Generic;
using System.Text;

namespace GenericDemo.ConsoleClient
{
    public class DigitPredicateAdapty : IPredicate<int>
    {
        private readonly PredicateDigit predicate;

        public DigitPredicateAdapty(PredicateDigit predicate)
        {
            this.predicate = predicate;
        }
        public bool IsMatch(int value)
        {
            return predicate.ContainsKey(value);
        }
    }
}
