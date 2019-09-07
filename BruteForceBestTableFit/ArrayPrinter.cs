using System;
using System.IO;

namespace BruteForceBestTableFit
{
    class ArrayPrinter
    {
        #region Declarations

        static bool isLeftAligned = false;
        const string cellLeftTop = "┌";
        const string cellRightTop = "┐";
        const string cellLeftBottom = "└";
        const string cellRightBottom = "┘";
        const string cellHorizontalJointTop = "┬";
        const string cellHorizontalJointbottom = "┴";
        const string cellVerticalJointLeft = "├";
        const string cellTJoint = "┼";
        const string cellVerticalJointRight = "┤";
        const string cellHorizontalLine = "─";
        const string cellVerticalLine = "│";

        #endregion

        #region Private Methods

        private static int GetMaxCellWidth(string[,] arrValues)
        {
            int maxWidth = 1;

            for (int i = 0; i < arrValues.GetLength(0); i++)
            {
                for (int j = 0; j < arrValues.GetLength(1); j++)
                {
                    int length = arrValues[i, j].Length;
                    if (length > maxWidth)
                    {
                        maxWidth = length;
                    }
                }
            }

            //return maxWidth > 20 ? 20 : maxWidth;
            return maxWidth;
        }

        private static string GetDataInTableFormat(string[,] arrValues)
        {
            string formattedString = string.Empty;

            if (arrValues == null)
                return formattedString;

            int dimension1Length = arrValues.GetLength(0);
            int dimension2Length = arrValues.GetLength(1);

            int maxCellWidth = GetMaxCellWidth(arrValues);
            int indentLength = (dimension2Length * maxCellWidth) + (dimension2Length - 1);
            //printing top line;
            formattedString = $"{cellLeftTop}{Indent(indentLength)}{cellRightTop}{System.Environment.NewLine}";

            for (int i = 0; i < dimension1Length; i++)
            {
                string lineWithValues = cellVerticalLine;
                string line = cellVerticalJointLeft;
                for (int j = 0; j < dimension2Length; j++)
                {
                    string value = (isLeftAligned) ? arrValues[i, j].PadRight(maxCellWidth, ' ') : arrValues[i, j].PadLeft(maxCellWidth, ' ');
                    //value = value.Substring(0, maxCellWidth);
                    lineWithValues += $"{value}{cellVerticalLine}";
                    line += Indent(maxCellWidth);
                    if (j < (dimension2Length - 1))
                    {
                        line += cellTJoint;
                    }
                }
                line += cellVerticalJointRight;
                formattedString += $"{lineWithValues}{System.Environment.NewLine}";
                if (i < (dimension1Length - 1))
                {
                    formattedString += $"{line}{System.Environment.NewLine}";
                }
            }

            //printing bottom line
            formattedString += $"{cellLeftBottom}{Indent(indentLength)}{cellRightBottom}{System.Environment.NewLine}";
            return formattedString;
        }

        private static string Indent(int count)
        {
            return string.Empty.PadLeft(count, '─');
        }

        #endregion

        public static void PrintToConsole(string[,] arrValues) => Console.WriteLine(GetDataInTableFormat(arrValues));
    }
}