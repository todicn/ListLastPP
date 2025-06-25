using System;
using System.IO;

namespace ListLastPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowUsage();
                return;
            }

            string command = args[0].ToLower();
            
            switch (command)
            {
                case "list":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Error: Please provide a file path for list command.");
                        ShowUsage();
                        return;
                    }
                    ListFileContents(args[1]);
                    break;
                    
                case "last":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Error: Please provide a file path for last command.");
                        ShowUsage();
                        return;
                    }
                    PrintLastLines(args[1]);
                    break;
                    
                default:
                    Console.WriteLine($"Error: Unknown command '{command}'");
                    ShowUsage();
                    break;
            }
        }

        /// <summary>
        /// Lists the complete contents of a file given a path
        /// </summary>
        /// <param name="filePath">The path to the file to read</param>
        public static void ListFileContents(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: File '{filePath}' does not exist.");
                    return;
                }

                Console.WriteLine($"Contents of '{filePath}':");
                Console.WriteLine(new string('=', 50));
                
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine($"{i + 1:D4}: {lines[i]}");
                }
                
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"Total lines: {lines.Length}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        /// <summary>
        /// Prints the last 10 lines of a file
        /// </summary>
        /// <param name="filePath">The path to the file to read</param>
        public static void PrintLastLines(string filePath, int lineCount = 10)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: File '{filePath}' does not exist.");
                    return;
                }

                string[] allLines = File.ReadAllLines(filePath);
                int totalLines = allLines.Length;
                
                Console.WriteLine($"Last {Math.Min(lineCount, totalLines)} lines of '{filePath}':");
                Console.WriteLine(new string('=', 50));
                
                int startIndex = Math.Max(0, totalLines - lineCount);
                for (int i = startIndex; i < totalLines; i++)
                {
                    Console.WriteLine($"{i + 1:D4}: {allLines[i]}");
                }
                
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"Showing lines {startIndex + 1}-{totalLines} of {totalLines} total lines");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("ListLastPP - File Content Viewer");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  ListLastPP list <file_path>   - List complete file contents with line numbers");
            Console.WriteLine("  ListLastPP last <file_path>   - Print the last 10 lines of the file");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("  ListLastPP list myfile.txt");
            Console.WriteLine("  ListLastPP last /path/to/logfile.log");
        }
    }
} 