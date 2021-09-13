using System.Collections.Generic;

namespace Assessment
{
    public class StringProvider : IElementsProvider<string>
    {
        private string separator = "";

        public StringProvider(){}

        public StringProvider(string separator)
        {
            this.separator = separator;
        }

        public IEnumerable<string> ProcessData(string source)
        {
            if (separator == "")
            {
                if (source.Contains(","))
                {
                    separator = ",";
                }
                else if (source.Contains("|"))
                {
                    separator = "|";
                }
                else
                {
                    separator = " ";
                }
            }
            return source.Split(separator);
        }
    }
}