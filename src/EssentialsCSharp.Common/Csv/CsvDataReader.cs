using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Csv
{
    public class CsvDataReader : IDataReader
    {
        private StreamReader _csvFileStream;
        private bool _isFileOpen;

        private readonly char _delimeter;
        private readonly char _qualifier;

        private IList<string> _currentFielsSet;

        public CsvDataReader(StreamReader fileStream,
            char delimeter, char qualifier)
        {
            _csvFileStream = fileStream;
            _isFileOpen = true;

            _delimeter = delimeter;
            _qualifier = qualifier;

            _currentFielsSet = new List<string>();
        }


        #region IDataReader members
        
        /*
         * Always return a value of zero if nesting is not supported.
         */
        public int Depth
        {
            get { return 0; }
        }

        public DataTable GetSchemaTable()
        {
            throw new NotSupportedException();
        }

        /*
         * Keep track of the reader state - some methods should be
         * disallowed if the reader is closed.
         */
        public bool IsClosed
        {
            get { return !_isFileOpen; }
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            if (_csvFileStream.EndOfStream)
            {
                return false;
            }

            _currentFielsSet = ParseRecord(_csvFileStream, _delimeter, _qualifier);

            var invalidRow = false;
            if (_currentFielsSet == null)
            {
                invalidRow = true;
            }

            //var invalidRow = false;
            //for (int i = 0; i < _currentLineValues.Length; i++)
            //{
            //    if (!_constraintsTable[i](_currentLineValues[i]))
            //    {
            //        invalidRow = true;
            //        break;
            //    }
            //} 

            return !invalidRow || Read();
        }

        private IList<string> ParseRecord(TextReader reader, char delimiter, char qualifier)
        {
            var isInQuote = false;
            var record = new List<string>();
            var fieldBuilder = new StringBuilder();

            while (reader.Peek() != -1)
            {
                var currentChar = (char)reader.Read();

                var isEndOfSet = currentChar == '\n' ||
                                (currentChar == '\r' && (char)reader.Peek() == '\n');

                #region if we reach end of set
                if (isEndOfSet)
                {
                    // If it's a \r\n combo consume the \n part and throw it away.
                    if (currentChar == '\r')
                        reader.Read();

                    if (isInQuote)
                    {
                        if (currentChar == '\r')
                            fieldBuilder.Append('\r');
                        fieldBuilder.Append('\n');
                    }
                    else
                    {
                        if (fieldBuilder.Length == 0)
                        {
                            record.Add(string.Empty);
                        }
                        else
                        {
                            record.Add(fieldBuilder.ToString());
                        }

                        fieldBuilder.Clear();
                        return record;
                    }
                }

                #endregion if we reach end of set

                #region if we reach first char in field

                else if (fieldBuilder.Length == 0 && !isInQuote)
                {
                    if (currentChar == qualifier)
                    {
                        isInQuote = true;
                    }
                    else if (currentChar == delimiter)
                    {
                        record.Add(string.Empty);
                        fieldBuilder.Clear();
                    }
                    else if (char.IsWhiteSpace(currentChar))
                    {
                        // Ignore leading whitespace
                    }
                    else
                    {
                        fieldBuilder.Append(currentChar);
                    }
                }

                #endregion if we reach first char in field

                #region if reach delimeter
                
                else if (currentChar == delimiter)
                {
                    if (isInQuote)
                    {
                        fieldBuilder.Append(delimiter);
                    }
                    else
                    {
                        record.Add(fieldBuilder.ToString());
                        fieldBuilder.Clear();
                    }
                }

                #endregion if reach delimeter

                #region if we reach qualifier

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
                        {
                            isInQuote = false;
                        }
                    }
                    else
                    {
                        fieldBuilder.Append(currentChar);
                    }
                }

                #endregion if we reach qualifier

                #region just add char 

                else
                {
                    fieldBuilder.Append(currentChar);
                }
                
                #endregion just add char
            }

            return null;
        }

        /*
         * RecordsAffected is only applicable to batch statements
         * that include inserts/updates/deletes. 
         * The sample always returns -1.
         */
        public int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }


        #region Resource clean-up

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Close();
            }
        }

        /*
         * Close the reader. The sample only changes the state,
         * but an actual implementation would also clean up any 
         * resources used by the operation. For example,
         * cleaning up any resources waiting for data to be
         * returned by the server.
         */
        public void Close()
        {
            _isFileOpen = false;
            // free managed resources
            if (_csvFileStream != null)
            {
                _csvFileStream.Close();
                _csvFileStream = null;
            }
        }

        #endregion Resource clean-up


        public int FieldCount
        {
            get { return _currentFielsSet.Count; }
        }

        #region Get data fields convert to type

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
           /*
            * The sample code does not support this method. Normally,
            * this would be used to expose nested tables and
            * other hierarchical data.
            */
            throw new NotSupportedException("GetData not supported.");
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public object GetValue(int i)
        {
            return _currentFielsSet[i];
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        #endregion Get data fields convert to type

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public object this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public object this[int i]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion IDataReader members
    }
}
