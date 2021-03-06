using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibArray
{
    public class MyArray
    {
        public MyArray(int row, int column)
        {
            _array = new int[row, column];
        }

        private Random _random = new Random();
        private int[,] _array;
        public int RowLength => _array.GetLength(0);
        public int ColumnLength => _array.GetLength(1);

        public void Fill(int min = 1, int max = 100)
        {
            for (int i = 0; i < RowLength; i++)
            {
                for (int j = 0; j < ColumnLength; j++)
                {
                    _array[i, j] = _random.Next(min, max);
                }
            }
        }

        public void Export(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(RowLength);
                writer.WriteLine(ColumnLength);

                for (int i = 0; i < RowLength; i++)
                {
                    for (int j = 0; j < ColumnLength; j++)
                    {
                        writer.WriteLine(_array[i, j]);
                    }
                }
            }
        }

        public void Import(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int rowlength = int.Parse(reader.ReadLine());
                int columnlength = int.Parse(reader.ReadLine());

                for (int i = 0; i < rowlength; i++)
                {
                    for (int j = 0; j < columnlength; j++)
                    {
                        _array[i, j] = int.Parse(reader.ReadLine());
                    }
                }
            }
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < RowLength; i++)
            {
                res.Columns.Add("Col" + (i + 1));
            }

            for (int i = 0; i < ColumnLength; i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < ColumnLength; j++)
                {
                    row[j] = _array[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }

        public int this[int firstindex, int secondindex]
        {
            get
            {
                return _array[firstindex, secondindex];
            }
            set
            {
                _array[firstindex, secondindex] = value;
            }
        }
        public void Clear()
        {
            Fill(0, 0);
        }
    }
}
