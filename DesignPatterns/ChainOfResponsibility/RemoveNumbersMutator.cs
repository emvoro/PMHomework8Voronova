using System.Text.RegularExpressions;
namespace DesignPatterns.ChainOfResponsibility
{
    public class RemoveNumbersMutator : StringMutator
    {
        public override string Mutate(string str)
        {
            return base.Mutate(Regex.Replace(str, "[0-9]", ""));
        }
    }
}