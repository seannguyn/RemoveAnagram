using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveAnagram
{
    /*
     * for each word in a sentence, compute a has for that word
     * check in the dictionary if the hash exist, 
     *      if it does then check if anagram
     *      else add hashcode to the dictionary   
     */  
    class Program
    {
        static void Main(string[] args)
        {
            string[] sentence = { "sean", "bob", "neas", "nesa" ,"cece", "mane", "neas" };

            string[] newSentence = RemoveAnagram(sentence);
            foreach(string word in newSentence)
            {
                Console.WriteLine(word);
            }
        }

        public static string[] RemoveAnagram(string[] sentence)
        {
            Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();
            List<string> result = new List<string>();

            foreach (string s in sentence)
            {
                int hashCode = ComputeHash(s);
                if (map.ContainsKey(hashCode))
                {
                    List<string> stringList = map[hashCode];
                    if(!CheckAnagram(s, stringList))
                    {
                        map[hashCode].Add(s);
                        result.Add(s);
                    }
                } 
                else
                {
                    List<string> stringList = new List<string>();
                    stringList.Add(s);
                    map.Add(hashCode, stringList);
                    result.Add(s);
                }
            }
            return result.ToArray();
        }

        public static int ComputeHash(string word)
        {
            int total = 0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(word);

            foreach (byte c in asciiBytes)
            {
                total += c;
            }
            return total;
        }

        public static bool CheckAnagram(string word, List<string> stringList)
        {
            foreach(string w in stringList)
            {
                char[] a1 = w.ToCharArray();
                char[] a2 = w.ToCharArray();
                if (IsSame(a1, a2)) { return true; }
            }
            return false;
        }

        static bool IsSame<T>(IEnumerable<T> set1, IEnumerable<T> set2)
        {
            if (set1 == null && set2 == null)
                return true;
            if (set1 == null || set2 == null)
                return false;

            List<T> list1 = set1.ToList();
            List<T> list2 = set2.ToList();

            if (list1.Count != list2.Count)
                return false;

            list1.Sort();
            list2.Sort();

            return list1.SequenceEqual(list2);
        }
    }
}
