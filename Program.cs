using System;

namespace Assignment1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();

            //Question 2:
            Console.Write("Enter the length of array 1");
            int l1 = int.Parse(Console.ReadLine());
            string[] bulls_string1 = new string[l1];
            for (int i = 0; i < l1; i++)   // taking input of array 1
            {
                bulls_string1[i] = Console.ReadLine();
            }


            Console.Write("Enter the length of array 2");
            int l2 = int.Parse(Console.ReadLine());
            string[] bulls_string2 = new string[l2];
            for (int i = 0; i < l2; i++) // taking input of array 2
            {
                bulls_string2[i] = Console.ReadLine();
            }
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            Console.WriteLine(flag);

            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }




            //Question 4:
            Console.Write("Enter the length and width of array");
            int lb = int.Parse(Console.ReadLine()); // Read the dimensions
            int[,] bulls_grid = new int[lb, lb];

            for (int i = 0; i < lb; i++)
            {
                for (int j = 0; j < lb; j++)
                {
                    bulls_grid[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int diagSum = DiagonalSum(bulls_grid, lb);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is {0}:", diagSum);

            //Question 5:
            Console.Write("Enter the string");
            String bulls_string = Console.ReadLine();
            Console.Write("Enter the length of the string");
            int len = int.Parse(Console.ReadLine());
            int[] indices = new int[len];

            for (int i = 0; i < len; i++)  //READ THE INDICES
            {
                indices[i] = int.Parse(Console.ReadLine());
            }


            string rotated_string = RestoreString(bulls_string, indices);

            Console.WriteLine("The  Final string after rotation is {0} ", rotated_string);

            //Quesiton 6:

            Console.Write("Enter the string");
            String bulls_string6 = Console.ReadLine();
            Console.Write("Enter the char");
            char ch = char.Parse(Console.ReadLine());

            string reversed_string = ReversePrefix(bulls_string6, ch);

            Console.WriteLine("Resultant string are reversing the prefix:{0}", reversed_string);
        }

        public static string RemoveVowels(this string s)
        {
            string[] vowels = new string[] { "A", "E", "I", "O", "U", "a", "e", "i", "o", "u" }; //create an array of all vowels
            foreach (string c in vowels)
            {
                s = s.Replace(c, ""); //replace all occurences of characters defined in "vowels" apperaing in "s" with empty
            }

            return s;
        }

        public static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            string a = "";
            string b = "";
            for (int i = 0; i < bulls_string1.Length; i++)  // here, I'm concatenating all elements of first array into a
            {
                a = a + bulls_string1[i];
            }
            Console.WriteLine(a);

            for (int i = 0; i < bulls_string2.Length; i++) // here, I'm concatenating all elements of 2nd array into b
            {
                b = b + bulls_string2[i];
            }
            Console.WriteLine(b);

            bool result = a.Equals(b); //comparing the strings
            return result;
        }

        public static int DiagonalSum(int[,] bulls_grid, int lb)
        {
            int cnt = 0;
            for (int i = 0; i < lb; i++)
            {
                for (int j = 0; j < lb; j++)
                {

                    if (i == j || i + j == lb - 1) // if the indices match and the sum of indices = the dimension -1, numbers in these places represent the diagnol elements
                    {
                        cnt = bulls_grid[i, j] + cnt;
                    }
                }
            }

            return cnt;
        }

        public static string RestoreString(string bulls_string, int[] indices)
        {

            char[] ch = new char[bulls_string.Length]; // CREATE A DUMMY ARRAY
            for (int i = 0; i < bulls_string.Length; i++) // CONVERT BULLSTRING TO ARRAY
            {
                ch[i] = bulls_string[i];
            }
            char[] dummy = new char[bulls_string.Length]; // CREATE ANOTHER DUMMY ARRAY
            int cnt = 0;
            foreach (var item in indices) // ASSIGN THE VALUES FROM CH TO DUMMY BASED ON THE INDEX VALUE; SOLVE THE PROBLEM HERE
            {
                dummy[cnt] = ch[item];
                cnt++;
            }
            string result = string.Join("", dummy); //CONVERT ARRAY BACK TO STRING

            return result;

        }

        public static string ReversePrefix(string bulls_string6, char ch)
        {
            int cnt = 0;
            for (int i = 0; i < bulls_string6.Length; i++)  // here, I'm retrieving the place where the character is located
            {
                if (bulls_string6[i] == ch)
                {
                    cnt = i;
                }
            }

            char[] dummy1 = new char[bulls_string6.Length];
            int j = 0;
            for (int i = cnt; i >= 0; i--)  // here, I'm reversing the string from the placeholder we obtained earlier
            {
                dummy1[j] = bulls_string6[i];
                j++;
            }


            int k = cnt;
            for (int i = cnt + 1; i < bulls_string6.Length; i++) // here, I'm concatenating the reversed string with the remaining string
            {
                dummy1[k] = bulls_string6[i];
                k++;
            }
            string result = string.Join("", dummy1);
            return result;


        }


    }
}
