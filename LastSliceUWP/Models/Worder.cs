using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastSliceUWP.Models
{
    public class Worder
    {
        private static int[,] string15 = new int[,] {
                { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10, 9, 8, 7, 6, 5 }, { 0, 1, 2, 5, 6, 7, 8, 9, 10, 11, 9, 8, 7, 6, 5 }, { 0, 1, 5, 6, 7, 8, 9, 10, 11, 12, 9, 8, 7, 6, 5 },
                { 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 9, 8, 7, 6, 5 }, { 1, 2, 3, 4, 5, 6, 7, 8, 9, 14, 9, 8, 7, 6, 5 }, { 2, 3, 4, 5, 6, 7, 8, 9, 13, 14, 9, 8, 7, 6, 5 },
                { 3, 4, 5, 6, 7, 8, 9, 12, 13, 14, 9, 8, 7, 6, 5 }, { 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 9, 8, 7, 6, 5 }, { 6, 7, 8, 9, 10, 9, 8, 7, 6, 5, 0, 1, 2, 3, 5 },
                { 7, 8, 9, 10, 11, 9, 8, 7, 6, 5, 0, 1, 2, 5, 6 }, { 8, 9, 10, 11, 12, 9, 8, 7, 6, 5, 0, 1, 5, 6, 7 }, { 9, 10, 11, 12, 13, 9, 8, 7, 6, 5, 0, 5, 6, 7, 8 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 14, 9, 8, 7, 6, 5 }, { 2, 3, 4, 5, 6, 7, 8, 9, 13, 14, 9, 8, 7, 6, 5 }, { 3, 4, 5, 6, 7, 8, 9, 12, 13, 14, 9, 8, 7, 6, 5 },
                { 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 9, 8, 7, 6, 5 }
            };

        private static int[,] position15 = new int[,] {
                { 1, 2, 3, 4, 5, 4, 3, 2, 1, 0, 18, 17, 16, 15, 14 }, { 2, 3, 4, 6, 5, 4, 3, 2, 1, 0, 17, 16, 15, 14, 13 }, { 3, 4, 7, 6, 5, 4, 3, 2, 1, 0, 16, 15, 14, 13, 12 },
                { 4, 8, 7, 6, 5, 4, 3, 2, 1, 0, 15, 14, 13, 12, 11 }, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 4, 11, 12, 13, 14, 15 }, { 0, 1, 2, 3, 4, 5, 6, 7, 4, 3, 12, 13, 14, 15, 16 },
                { 0, 1, 2, 3, 4, 5, 6, 4, 3, 2, 13, 14, 15, 16, 17 }, { 0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 14, 15, 16, 17, 18 }, { 0, 1, 2, 3, 4, 6, 7, 8, 9, 10, 3, 2, 1, 0, 19 },
                { 0, 1, 2, 3, 4, 7, 8, 9, 10, 11, 2, 1, 0, 18, 19 }, { 0, 1, 2, 3, 4, 8, 9, 10, 11, 12, 1, 0, 17, 18, 19 }, { 0, 1, 2, 3, 4, 9, 10, 11, 12, 13, 0, 16, 17, 18, 19 },
                { 4, 3, 2, 1, 0, 19, 18, 17, 16, 0, 13, 12, 11, 10, 9 }, { 4, 3, 2, 1, 0, 19, 18, 17, 0, 1, 12, 11, 10, 9, 8 }, { 4, 3, 2, 1, 0, 19, 18, 0, 1, 2, 11, 10, 9, 8, 7 },
                { 4, 3, 2, 1, 0, 19, 0, 1, 2, 3, 10, 9, 8, 7, 6 }
            };

        private static string[] direction15 = new string[] {
                "SE,SE,SE,SE,SW,SW,SW,SW,SW,SW,NW,NW,NW,NW,NW", "SE,SE,SE,SW,SW,SW,SW,SW,SW,SW,NW,NW,NW,NW,NW", "SE,SE,SW,SW,SW,SW,SW,SW,SW,SW,NW,NW,NW,NW,NW",
                "SE,SW,SW,SW,SW,SW,SW,SW,SW,SW,NW,NW,NW,NW,NW", "SE,SE,SE,SE,SE,SE,SE,SE,SE,SW,NE,NE,NE,NE,NE", "SE,SE,SE,SE,SE,SE,SE,SE,SW,SW,NE,NE,NE,NE,NE",
                "SE,SE,SE,SE,SE,SE,SE,SW,SW,SW,NE,NE,NE,NE,NE", "SE,SE,SE,SE,SE,SE,SW,SW,SW,SW,NE,NE,NE,NE,NE", "SE,SE,SE,SE,SE,NE,NE,NE,NE,NE,SW,SW,SW,SW,SE",
                "SE,SE,SE,SE,SE,NE,NE,NE,NE,NE,SW,SW,SW,SE,SE", "SE,SE,SE,SE,SE,NE,NE,NE,NE,NE,SW,SW,SE,SE,SE", "SE,SE,SE,SE,SE,NE,NE,NE,NE,NE,SW,SE,SE,SE,SE",
                "SW,SW,SW,SW,SW,SW,SW,SW,SW,SE,NW,NW,NW,NW,NW", "SW,SW,SW,SW,SW,SW,SW,SW,SE,SE,NW,NW,NW,NW,NW", "SW,SW,SW,SW,SW,SW,SW,SE,SE,SE,NW,NW,NW,NW,NW",
                "SW,SW,SW,SW,SW,SW,SE,SE,SE,SE,NW,NW,NW,NW,NW"
            };

        private static int[,] string20 = new int[,] {
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 }, { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 },
                { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 9, 8, 7, 6, 5 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 9, 8, 7, 6, 5 }, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 9, 8, 7, 6, 5 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 9, 8, 7, 6, 5 }, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 9, 8, 7, 6, 5 },
                { 4, 4, 4, 4, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 10, 9, 8, 7, 6, 5 }, { 3, 3, 3, 3, 3, 5, 6, 7, 8, 9, 11, 11, 11, 11, 11, 9, 8, 7, 6, 5 },
                { 2, 2, 2, 2, 2, 5, 6, 7, 8, 9, 12, 12, 12, 12, 12, 9, 8, 7, 6, 5 }, { 1, 1, 1, 1, 1, 5, 6, 7, 8, 9, 13, 13, 13, 13, 13, 9, 8, 7, 6, 5 },
                { 0, 0, 0, 0, 0, 5, 6, 7, 8, 9, 14, 14, 14, 14, 14, 9, 8, 7, 6, 5 }
            };

        private static int[,] position20 = new int[,] {
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14, 14, 14, 14, 14 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 13, 13, 13, 13 }, { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 12, 12, 12, 12, 12 },
                { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 11, 11, 11, 11, 11 }, { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 10, 10, 10, 10, 10 },
                { 0, 1, 2, 3, 4, 5, 5, 5, 5, 5, 4, 3, 2, 1, 0, 19, 19, 19, 19, 19 }, { 0, 1, 2, 3, 4, 6, 6, 6, 6, 6, 4, 3, 2, 1, 0, 18, 18, 18, 18, 18 },
                { 0, 1, 2, 3, 4, 7, 7, 7, 7, 7, 4, 3, 2, 1, 0, 17, 17, 17, 17, 17 }, { 0, 1, 2, 3, 4, 8, 8, 8, 8, 8, 4, 3, 2, 1, 0, 16, 16, 16, 16, 16 },
                { 0, 1, 2, 3, 4, 9, 9, 9, 9, 9, 4, 3, 2, 1, 0, 15, 15, 15, 15, 15 }
            };

        private static string[] direction20 = new string[] {
                "E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E", "E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E",
                "E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E", "E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E",
                "E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E", "S,S,S,S,S,S,S,S,S,S,S,S,S,S,S,N,N,N,N,N",
                "S,S,S,S,S,S,S,S,S,S,S,S,S,S,S,N,N,N,N,N", "S,S,S,S,S,S,S,S,S,S,S,S,S,S,S,N,N,N,N,N",
                "S,S,S,S,S,S,S,S,S,S,S,S,S,S,S,N,N,N,N,N", "S,S,S,S,S,S,S,S,S,S,S,S,S,S,S,N,N,N,N,N",
                "E,E,E,E,E,S,S,S,S,S,W,W,W,W,W,N,N,N,N,N", "E,E,E,E,E,S,S,S,S,S,W,W,W,W,W,N,N,N,N,N",
                "E,E,E,E,E,S,S,S,S,S,W,W,W,W,W,N,N,N,N,N", "E,E,E,E,E,S,S,S,S,S,W,W,W,W,W,N,N,N,N,N",
                "E,E,E,E,E,S,S,S,S,S,W,W,W,W,W,N,N,N,N,N"
            };

        private static int[,] string5 = new int[,] {
                { 0, 1, 2, 3, 4 }, { 0, 1, 2, 3, 4 }, { 5, 6, 7, 8, 9 }, { 5, 6, 7, 8, 9 }, { 5, 6, 7, 8, 9 }, { 5, 6, 7, 8, 9 }, { 5, 6, 7, 8, 9 }, { 5, 6, 7, 8, 9 },
                { 5, 6, 7, 8, 9 }, { 5, 6, 7, 8, 9 }, { 10, 11, 12, 13, 14 }, { 10, 11, 12, 13, 14 }, { 4, 3, 2, 1, 0 }, { 4, 3, 2, 1, 0 }, { 9, 8, 7, 6, 5 }, { 9, 8, 7, 6, 5 },
                { 9, 8, 7, 6, 5 }, { 9, 8, 7, 6, 5 }, { 9, 8, 7, 6, 5 }, { 9, 8, 7, 6, 5 }, { 9, 8, 7, 6, 5 }, { 9, 8, 7, 6, 5 }, { 14, 13, 12, 11, 10 }, { 14, 13, 12, 11, 10 }
            };

        private static int[,] position5 = new int[,] {
                { 0, 1, 2, 3, 4 }, { 4, 3, 2, 1, 0 }, { 0, 1, 2, 3, 4 }, { 4, 3, 2, 1, 0 }, { 5, 6, 7, 8, 9 }, { 9, 8, 7, 6, 5 }, { 10, 11, 12, 13, 14 }, { 14, 13, 12, 11, 10 },
                { 15, 16, 17, 18, 19 }, { 19, 18, 17, 16, 15 }, { 0, 1, 2, 3, 4 }, { 4, 3, 2, 1, 0 }, { 4, 3, 2, 1, 0 }, { 0, 1, 2, 3, 4 }, { 4, 3, 2, 1, 0 }, { 0, 1, 2, 3, 4 },
                { 9, 8, 7, 6, 5 }, { 5, 6, 7, 8, 9 }, { 14, 13, 12, 11, 10 }, { 10, 11, 12, 13, 14 }, { 19, 18, 17, 16, 15 }, { 15, 16, 17, 18, 19 }, { 4, 3, 2, 1, 0 }, { 0, 1, 2, 3, 4 }
            };

        private static string[] direction5 = new string[] {
                "SE,SE,SE,SE,SE", "SW,SW,SW,SW,SW", "SE,SE,SE,SE,SE", "SW,SW,SW,SW,SW", "SE,SE,SE,SE,SE", "SW,SW,SW,SW,SW", "SE,SE,SE,SE,SE", "SW,SW,SW,SW,SW",
                "SE,SE,SE,SE,SE", "SW,SW,SW,SW,SW", "SE,SE,SE,SE,SE", "SW,SW,SW,SW,SW", "NW,NW,NW,NW,NW", "NE,NE,NE,NE,NE", "NW,NW,NW,NW,NW", "NE,NE,NE,NE,NE",
                "NW,NW,NW,NW,NW", "NE,NE,NE,NE,NE", "NW,NW,NW,NW,NW", "NE,NE,NE,NE,NE", "NW,NW,NW,NW,NW", "NE,NE,NE,NE,NE", "NW,NW,NW,NW,NW", "NE,NE,NE,NE,NE"
            };

        private static int[,] Reversal(int[,] input) {
            int size = input.GetLength(0);
            int innerSize = input.Length/size;

            int[,] result = new int[size, innerSize];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < innerSize; j++)
                {
                    result[i, j] = input[i, innerSize - j - 1];
                }
            }

            return result;
        }

        private static string ReverseDirection(string direction)
        {
            string[] inputArr = direction.Split(',');
            int size = inputArr.Length;
            string result = reverse(inputArr[size - 1]);

            for (int i = size - 2; i >= 0; i--)
            {
                result = result + "," + reverse(inputArr[i]);
            }

            return result;
        }

        private static string reverse(string direction)
        {
            if (direction.Equals("N"))
                return "S";
            else if (direction.Equals("S"))
                return "N";
            else if (direction.Equals("E"))
                return "W";
            else if (direction.Equals("W"))
                return "E";
            else if (direction.Equals("NE"))
                return "SW";
            else if (direction.Equals("SW"))
                return "NE";
            else if (direction.Equals("NW"))
                return "SE";
            else if (direction.Equals("SE"))
                return "NW";
            return "";
        }

        private static int[,] Joiner(int[,] input)
        {
            int size = input.GetLength(0);
            int innerSize = input.Length / size;
            int[,] revst = Reversal(input);
            int[,] result = new int[size * 2, innerSize];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < innerSize; j++)
                {
                    result[i, j] = input[i, j];
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < innerSize; j++)
                {
                    result[size + i, j] = revst[i, j];
                }
            }

            return result;
        }

        private static string[] JoinDirection(string[] input)
        {
            int size = input.Length;
            string[] result = new string[size * 2];
            for (int i = 0; i < size; i++)
            {
                result[i] = input[i];
            }

            for (int i = 0; i < size; i++)
            {
                result[size + i] = ReverseDirection(input[i]);
            }

            return result;
        }

        private static string[,] DirectionSplitter(string[] input)
        {
            int size = input.Length;
            int innerSize = input[0].Split(',').Length;
            string[,] result = new string[size, innerSize];

            for (int i = 0; i < size; i++)
            {
                string[] arr = input[i].Split(',');
                for (int j = 0; j < innerSize; j++)
                {
                    result[i, j] = arr[j];
                }
            }

            return result;
        }

        public static int[,] Stringer15()
        {
            return Joiner(string15);
        }

        public static int[,] Positioner15()
        {
            return Joiner(position15);
        }

        public static string[,] Directioner15()
        {
            return DirectionSplitter(JoinDirection(direction15));
        }

        public static int[,] Stringer20()
        {
            return Joiner(string20);
        }

        public static int[,] Positioner20()
        {
            return Joiner(position20);
        }

        public static string[,] Directioner20()
        {
            return DirectionSplitter(JoinDirection(direction20));
        }

        public static int[,] Stringer5()
        {
            return string5;
        }

        public static int[,] Positioner5()
        {
            return position5;
        }

        public static string[,] Directioner5()
        {
            return DirectionSplitter(direction5);
        }

        private string Word;

        private int X;

        private int Y;

        private string Direction;

        public Worder(string Word, int X, int Y, string Direction)
        {
            this.Word = Word;
            this.X = X;
            this.Y = Y;
            this.Direction = Direction;
        }

        public string toString()
        {
            string result = "{";

            result = result + "\"word\": \"" + Word + "\",";
            result = result + "\"x\": " + X + ",";
            result = result + "\"y\": " + Y + ",";
            result = result + "\"direction\": \"" + Direction + "\"";
            result = result + "}";

            return result;
        }
    }
}
