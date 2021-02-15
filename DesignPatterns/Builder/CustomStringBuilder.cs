namespace DesignPatterns.Builder
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private char[] _text;

        public CustomStringBuilder()
        {
            _text = new char[0];
        }

        public CustomStringBuilder(string text)
        {
            _text = new char[text.Length];
            _text = text.ToCharArray();
        }

        public ICustomStringBuilder Append(string str)
        {
            foreach (char ch in str)
                Append(ch);
            return this;
        }

        public ICustomStringBuilder Append(char ch)
        {
            int newLength = _text.Length + 1;
            char[] temporaryCharArray = _text;
            _text = new char[newLength];
            for (int i = 0; i < newLength - 1; i++)
                _text[i] = temporaryCharArray[i];
            _text[newLength - 1] = ch;
            return this;
        }

        public ICustomStringBuilder AppendLine()
        {
            return Append('\n');
        }

        public ICustomStringBuilder AppendLine(string str)
        {
            return Append('\n' + str + '\n');
        }

        public ICustomStringBuilder AppendLine(char ch)
        {
            return Append("\n" + ch + '\n');
        }

        public string Build()
        {
            return new string(_text);
        }
    }
}