using System;

namespace ConsoleHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool line = false;
            bool star = false;
            bool space = true;
            bool flag1 = true;
            bool cont = false;
            string allword = "";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please enter the text:");
            string text = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Please enter the pattern:");
            string pattern = Console.ReadLine();
            pattern = pattern.ToLower();
            for(int i = 0; i < pattern.Length; i++) //checking - or *
            {
                if (pattern[i] == '-')
                {
                    line = true;
                    break;
                }

                   
                if (pattern[i] == '*')
                {
                    star = true;
                    break;
                }
            }
            
            text = text.Replace(",", "");
            text = text.Replace(".", "");
            text = text.ToLower();
            
            string[] words_original = text.Split(" ");
            Array.Sort(words_original);
            string[] words = new string[words_original.Length];
            words[0] = words_original[0];
            
            for(int i = 1; i < words_original.Length; i++)//getting rid of repetitive words
            {
                if (words_original[i] != words_original[i - 1])
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (words_original[j] == words_original[i])
                        {
                            flag1 = false;
                            break;
                        }
                        else
                            flag1 = true;
                    }
                    if (flag1)
                    {
                        words[i] = words_original[i];
                    }
                }
            }         
            while (line)// pattern -
            {
                
                for (int i = 0; i < words.Length; i++)//looking for words in array
                {
                    if (words[i]!=null&&words[i].Length == pattern.Length)
                    {
                        for(int j = 0; j < pattern.Length; j++)//looking at the letters in the word one by one
                        {
                            if (words[i][j] == pattern[j] ||pattern[j] == '-')
                            {
                                allword = allword + words[i][j];

                                if (allword.Length == pattern.Length)
                                {
                                    
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write(allword);
                                    space = true;
                                }                              
                            }
                            else
                            {
                                space = false;
                                break;
                            }                                                                                      
                        }
                        if (space)
                        {
                            Console.WriteLine();
                        }
                    }
                    allword = "";
                }
                line = false;
            }                    
            while (star)//pattern *
            {
                string[] pattern_array = pattern.Split("*");
                if (pattern_array.Length == 2&&pattern_array[0]=="" && pattern_array[1] == "")// if the users input just *
                {
                    for(int i = 0; i < words.Length; i++)
                    {
                        if (words[i] != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(words[i]);
                        }
                    }
                }
                for(int i = 0; i < pattern_array.Length; i++) 
                {
                    for (int j = 0; j < words.Length; j++) 
                    {
                        if (pattern_array[i] == "")
                        {
                            break;
                        }
                        if (words[j]!=null&&words[j].Contains(pattern_array[i]))//if there is a part from the pattern in the word 
                        {
                            if (i == pattern_array.Length - 1)
                            {
                                cont = true;
                            }
                            else { 
                            for(int m = i + 1; m < pattern_array.Length; m++)
                            {
                                    if (words[j].Contains(pattern_array[m]))
                                    {
                                        cont = true;
                                    }
                                    else
                                    {
                                        cont = false;
                                        break;
                                    }                                                                                                              
                            }
                            }
                            if (cont)
                            {
                                
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine(words[j]);
                            }
                            
                        }
                    }
                }
                
                star = false;
            }
                }
        }
}
