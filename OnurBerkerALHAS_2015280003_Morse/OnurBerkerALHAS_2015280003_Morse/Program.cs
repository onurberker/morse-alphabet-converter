using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnurBerkerALHAS_2015280003_Morse
{
    class Program
    {

        private static Dictionary<string,string> data = new Dictionary<string,string>(){{" ", " "},  {"E", "."},    {"T", "-"},    {"I", ".."},   {"A", ".-"},   {"N", "-."},    
{"M", "--"},   {"S", "..."},  {"U", "..-"},  {"R", ".-."},  {"W", ".--"},  {"D", "-.."},   
{"K", "-.-"},  {"G", "--."},  {"O", "---"},  {"H", "...."}, {"V", "...-"}, {"F", "..-."},  
{"L", ".-.."}, {"P", ".--."}, {"J", ".---"},  {"B", "-..."}, {"X", "-..-"}, {"C", "-.-."},  
{"Y", "-.--"}, {"Z", "--.."}, {"Q", "--.-"}};

        static void Main(string[] args)
        {
            Converter cv = new Converter(data);
            cv.fill();
            menu(cv);
            Console.ReadKey();
           

            
        }

        
        static void menu(Converter cv)
        {
            while(true)
            {
                Console.WriteLine("\n1 - Convert string to morse\n" + 
                                  "2 - Convert morse to string\n" + 
                                  "3 - Pre-order traversal\n" + 
                                  "4 - In-order traversal\n" +
                                  "5 - Post-order traversal\n"+
                                  "6 - Clean screen\n" +
                                  "0 - Exit\n");
                string de = Console.ReadLine();

                switch(de)
                {
                    case "1":
                        {
                            string str;
                            while(true)
                            {
                                
                                Console.WriteLine("Enter a string");
                                str = Console.ReadLine();
                                if (!hasOnlyLetters(str))
                                {
                                    Console.WriteLine();
                                    cv.convertStringToMorse(str);
                                    Console.WriteLine();
                                    break;
                                }
                                else Console.WriteLine("Invalid string");
                                    
                            }
                          
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter a morse code");
                            string str = Console.ReadLine();
                            cv.convertMorseToString(str);
                            break;
                        }
                    case "3":
                        {
                            cv.preOrder(cv.getTree());
                            break;
                        }
                    case "4":
                        {
                            cv.inOrder(cv.getTree());
                            break;

                        }
                    case "5":
                        {
                            cv.postOrder(cv.getTree());
                            break;
                        }
                    case "6":
                        {
                            Console.Clear();
                            break;
                        }
                    case "0":
                        {
                            
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {

                            Console.WriteLine("Invalid Option");

                            break;
                        }
                        
                }


            }
        }

        static bool hasOnlyLetters(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                int ch = s[i];
                if (Char.IsLetter(s[i]))
                {
                    if (!(ch >= 65 && 90 <= ch))
                        return false;
                }
                else return false;
               
            }
            return true;
        }
        

        
    }




}
