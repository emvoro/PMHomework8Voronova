using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class InvertMutator : StringMutator
    {
        public override string Mutate(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return base.Mutate(new string(chars));
        }
    }
}