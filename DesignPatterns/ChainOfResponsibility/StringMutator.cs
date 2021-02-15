using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ChainOfResponsibility
{
    public class StringMutator : IStringMutator
    {
        private IStringMutator _next;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return next;
        }

        public virtual string Mutate(string str)
        {
            return _next == null ? str : _next.Mutate(str);
        }
    }
}
