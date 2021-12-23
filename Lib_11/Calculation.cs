using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibArray;

namespace Lib_11
{
    public static class Calculation
    {
        public static string FindMaxNumber(this MyArray myarray)
        {
            int[] array = new int[myarray.RowLength];

            for (int i = 0; i < myarray.ColumnLength; i++)
            {
                int minValue = 100;

                for (int j = 0; j < myarray.RowLength; j++)
                {

                    if (myarray[j, i] < minValue)
                    {
                        minValue = myarray[j, i];
                    }

                    if (j == myarray.RowLength - 1)
                    {
                        array = array.Concat(new int[] { minValue }).ToArray();
                    }
                }
            }
            return array.Max().ToString();
        }
    }
}
