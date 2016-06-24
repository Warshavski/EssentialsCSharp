using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Csv
{
    static class Parser
    {
        private const char LINE_FEED = '\n';
        private const char CARRIAGE_RETURN = '\r';

        // extension method
        private static Tuple<T, IEnumerable<T>> HeadAndTail<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var en = source.GetEnumerator();
            en.MoveNext();

            return Tuple.Create(en.Current, EnumerateTail(en));
        }

        private static IEnumerable<T> EnumerateTail<T>(IEnumerator<T> en)
        {
            while (en.MoveNext()) yield return en.Current;
        }

        public static IEnumerable<IList<string>> Parse(string content, char delimiter, char qualifier)
        {
            using (var reader = new StringReader(content))
                return Parse(reader, delimiter, qualifier);
        }

        public static Tuple<IList<string>, IEnumerable<IList<string>>> ParseHeadAndTail(TextReader reader, char delimiter, char qualifier)
        {
            return HeadAndTail(Parse(reader, delimiter, qualifier));
        }

        public static IEnumerable<IList<string>> Parse(TextReader reader, char delimiter, char qualifier)
        {
            var isInQuote = false;
            var record = new List<string>();
            var fieldBuilder = new StringBuilder();

            while (reader.Peek() != -1)
            {
                var currentChar = (char)reader.Read();

                var isEndOfLine = currentChar == LINE_FEED ||
                    (currentChar == CARRIAGE_RETURN && (char)reader.Peek() == LINE_FEED);

                if (isEndOfLine)
                {
                    // If it's a \r\n combo consume the \n part and throw it away.
                    if (currentChar == CARRIAGE_RETURN)
                        reader.Read();

                    if (isInQuote)
                    {
                        if (currentChar == CARRIAGE_RETURN)
                            fieldBuilder.Append(CARRIAGE_RETURN);
                        fieldBuilder.Append(LINE_FEED);
                    }
                    else
                    {
                        if (record.Count > 0 || fieldBuilder.Length > 0)
                        {
                            record.Add(fieldBuilder.ToString());
                            fieldBuilder.Clear();
                        }

                        if (record.Count > 0)
                            yield return record;

                        
                        record = new List<string>(record.Count);
                    }
                }
                else if (fieldBuilder.Length == 0 && !isInQuote)
                {
                    if (currentChar == qualifier)
                        isInQuote = true;
                    else if (currentChar == delimiter)
                    {
                        record.Add(fieldBuilder.ToString());
                        fieldBuilder.Clear();
                    }
                    else if (char.IsWhiteSpace(currentChar))
                    {
                        // Ignore leading whitespace
                    }
                    else
                        fieldBuilder.Append(currentChar);
                }
                else if (currentChar == delimiter)
                {
                    if (isInQuote)
                        fieldBuilder.Append(delimiter);
                    else
                    {
                        record.Add(fieldBuilder.ToString());
                        fieldBuilder.Clear();
                    }
                }
                else if (currentChar == qualifier)
                {
                    if (isInQuote)
                    {
                        if ((char)reader.Peek() == qualifier)
                        {
                            reader.Read();
                            fieldBuilder.Append(qualifier);
                        }
                        else
                            isInQuote = false;
                    }
                    else
                        fieldBuilder.Append(currentChar);
                }
                else
                    fieldBuilder.Append(currentChar);
            }

            if (record.Count > 0 || fieldBuilder.Length > 0)
                record.Add(fieldBuilder.ToString());

            if (record.Count > 0)
                yield return record;
        }
    }
}
