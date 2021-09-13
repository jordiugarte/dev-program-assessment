using System.Collections.Generic;

namespace Assessment
{
    public class StringProvider : IElementsProvider<string>
    {
        private string separator = "";

        public IEnumerable<string> ProcessData(string source)
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
            return source.Split(separator);
        }
    }
}