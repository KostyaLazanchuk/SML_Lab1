using System;
using System.IO;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Part 1

            var readText = File.ReadAllText("Text.txt");
            var ingnoreWords = new string[] { "on", "at", "for", "the", "in", "to" };
            var wordCount = 0;

            int i = 0;
        CountingOfWords:
            if (readText[i] == ' ' || readText[i] == '\n') wordCount++;
            i++;
            if (i < readText.Length) goto CountingOfWords;

            Console.WriteLine(wordCount);

            string[] words = new string[wordCount];
            int[] wordsRepeats = new int[wordCount];
            var word = "";
            var wordCounter = 0;
            bool isFillArray;
            i = 0;

        Loop:
            if ((readText[i] == ' ' || readText[i] == '\n' || readText[i] == '\r') && word != "")
            {
                isFillArray = false;
                var j = 0;

            CheckWordsLoop:
                if (words[j] == word)
                {
                    wordsRepeats[j]++;
                    isFillArray = true;
                    goto FinishLoop;
                }
                j++;
                if (words[j] != null) goto CheckWordsLoop;

                FinishLoop:
                if (!isFillArray)
                {
                    words[wordCounter] = word;
                    wordsRepeats[wordCounter] = 1;
                    wordCounter++;
                }

                word = "";

            }
            else if (readText[i] != ',' && readText[i] != '.' &&
                readText[i] != '?' && readText[i] != '!' && readText[i] != '"' &&
                readText[i] != ' ' && readText[i] != '\n')
            {
                if (readText[i] >= 65 && readText[i] <= 90)
                {
                    word += (char)((int)readText[i] + 32);
                }
                word += readText[i];
            }
            i++;
            if (i < readText.Length) goto Loop;


            Array.Resize(ref words, wordCounter);
            Array.Resize(ref wordsRepeats, wordCounter);

            i = 0;
            var k = 0;
        SortLoopOut:
            if (i < wordCounter)
            {
            SortLoopIn:
                if (k < wordCounter - i - 1)
                {
                    if (wordsRepeats[k] < wordsRepeats[k + 1])
                    {
                        word = words[k];
                        var key = wordsRepeats[k];

                        wordsRepeats[k] = wordsRepeats[k + 1];
                        words[k] = words[k + 1];

                        wordsRepeats[k + 1] = key;
                        words[k + 1] = word;
                    }
                    k++;
                    goto SortLoopIn;
                }
                i++;
                k = 0;
                goto SortLoopOut;
            }

            i = 0;

        PrintResult:
            var PrintCycle1 = 0;
            var PrintCycle2 = 0;
            if (i < wordCounter)
            {
                if (wordsRepeats[i] != 0)
                {
                    Cycle1:
                    if (PrintCycle1 < word.Length)
                    {
                        PrintCycle1++;
                        Cycle2:
                        if (PrintCycle2 < ingnoreWords.Length)
                        {                            
                            if (words[PrintCycle1] != ingnoreWords[PrintCycle2])
                            {
                                Console.WriteLine($"{words[i]} - {wordsRepeats[i]}");
                            }
                                                  
                        }
                        else goto Cycle2;
                    }
                    else goto Cycle1;
                                       
                }
                i++;
                goto PrintResult;
            }

        }
    }
}
