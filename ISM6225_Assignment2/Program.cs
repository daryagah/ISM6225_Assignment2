using System;
using System.Collections.Generic;
namespace Assignment2_CT_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            // formatting the output array
            string Q1output = "[";
            foreach (int n in r)
            {
                Q1output += n + ",";
            }
            Q1output = (Q1output.Remove(Q1output.Length - 1)) + "]";
            Console.WriteLine(Q1output);

            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);

            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);

            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);

            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");

            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");

            //Console.WriteLine("Question 6");
            //char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            //int k = 3;
            //Console.WriteLine(ContainsDuplicate(arr, k));

            //Console.WriteLine("Question 7");
            //int rodLength = 4;
            //int priceProduct = GoldRod(rodLength);
            //Console.WriteLine(priceProduct);

            //Console.WriteLine("Question 8");
            //string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            //string keyword = "hhllo";
            //Console.WriteLine(DictSearch(userDict, keyword));

            //Console.WriteLine("Question 9");
            //SolvePuzzle();

            Console.ReadLine();
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        public static int[] TargetRange(int[] l1, int target)
        {
            try
            {
                List<int> MyList = new List<int>(); // declare a list
                for (int i = 0; i < l1.Length; i++)
                {
                    if (l1[i] == target)
                    {
                        MyList.Add(i); // iterate through every number and add it if it matches
                    }
                    else
                    {
                        continue;
                    }
                }
                if (MyList.Count != 0) // if found, transform into an array and return the result
                {
                    int[] r = MyList.ToArray();
                    return r;
                }
                else // if not found, return -1,-1
                {
                    int[] r = new int[] { -1, -1 };
                    return r;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return new int[] { };
        }


        public static string StringReverse(string s)
        {
            try
            {
                List<string> words = new List<string>(); // declare a list of words
                string word = ""; // store characters of one word
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] != ' ')
                    {
                        word += s[j]; // add the character to the word as long as it is not a whitespace
                    }
                    else
                    {
                        words.Add(word); // if it is a whitespace, add the word to the words list
                        word = ""; // reset the word after it is added and move to the next word
                    }
                }
                words.Add(word); // add the last word because there is no whitespace after it

                string rs = ""; // string to store reversed result in
                foreach (string w in words)
                {
                    for (int i = w.Length - 1; i >= 0; i--) // reverse characters for every word in the words list
                        rs += w[i];
                    rs += " "; // add a space after every word
                }
                return rs; // return reversed string
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }


        public static int MinimumSum(int[] l2)
        {
            try
            {
                int sum = 0;
                for (int n = l2.Length - 1; n > 0; n--) // iterate from the end of the array
                {
                    if (l2[n] == l2[n-1]) // if the right number is equal to the left number
                    {
                        l2[n] += 1; // add 1 to the right number
                        n = l2.Length - 1; // reset the loop and start checking from the end again
                    }
                }
                foreach (int num in l2)
                {
                    sum += num; // add upp all numbers of the array
                }
                return sum;
            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }


        public static string FreqSort(string s2)
        {
            try
            {
                // Dictionary to store characters as keys and number of instances as values
                Dictionary<char, int> FreqSortDict = new Dictionary<char, int>();
                for (int i = 0; i < s2.Length; i++)
                {
                    if (FreqSortDict.ContainsKey(s2[i]) == false) // if new character, add it as a key with a value of 1
                        FreqSortDict.Add(s2[i], 1);
                    else
                        FreqSortDict[s2[i]] += 1; // if repeating character, add 1 to the value
                }
                // Add characters to an array
                char[] sortedList = new char[s2.Length];
                int ct = 0;
                foreach (char c in s2)
                {
                    sortedList[ct] = c;
                    ct++;
                }
                // Bubble sort characters according to their number of instances
                char tmp;
                for (int p = 0; p <= sortedList.Length - 2; p++)
                {
                    for (int j = 0; j <= sortedList.Length - 2; j++)
                    {
                        if (FreqSortDict[sortedList[j]] < FreqSortDict[sortedList[j + 1]]) // compare the number of instances
                        {
                            tmp = sortedList[j + 1];
                            sortedList[j + 1] = sortedList[j];
                            sortedList[j] = tmp;
                        }
                    }
                }
                // Return sorted array as a string
                string output = "";
                foreach (char k in sortedList)
                {
                    output += k;
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }


        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                // Sort the arrays
                Array.Sort(nums1);
                Array.Sort(nums2);

                // Find the large and the small array
                int[] largeArray = nums1;
                int[] smallArray = nums2;
                if (nums1.Length < nums2.Length)
                {
                    largeArray = nums2;
                    smallArray = nums1;
                }

                List<int> intersection = new List<int>(); // list to store the results in

                for (int i = 0; i < largeArray.Length; i++) // iterate through the large array
                {
                    if (Array.BinarySearch(smallArray, largeArray[i]) >= 0) // if the number is found in the small array...
                        intersection.Add(largeArray[i]); // ...then add to the list
                }
                return intersection.ToArray(); // output
            }
            catch
            {
                throw;
            }
            return new int[] { };
        }


        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {
                List<int> intersection = new List<int>(); // list to store the results in
                Dictionary<int, int> interDict = new Dictionary<int, int>();
                for (int i = 0; i < nums1.Length; i++)
                    interDict.Add(i, nums1[i]); // store one array's elements in a dictionary as values

                for (int j = 0; j < nums2.Length; j++)
                {
                    if (interDict.ContainsValue(nums2[j])) // if second array's elements are found in the dictionary...
                        intersection.Add(nums2[j]); // ...then add to the list
                }
                return intersection.ToArray(); // output
            }
            catch
            {
                throw;
            }
            return new int[] { };
        }


        //public static bool ContainsDuplicate(char[] arr, int k)
        //{
        //    try
        //    {
        //        //Write your code here;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return default;
        //}


        //public static int GoldRod(int rodLength)
        //{
        //    try
        //    {
        //        //Write Your Code Here
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return 0;
        //}


        //public static bool DictSearch(string[] userDict, string keyword)
        //{
        //    try
        //    {
        //        //Write Your Code Here
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return default;
        //}


        //public static void SolvePuzzle()
        //{
        //    try
        //    {
        //        //Write Your Code Here
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
    }
}