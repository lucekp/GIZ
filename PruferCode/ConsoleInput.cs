using System;

namespace Input
{
    internal static class ConsoleInput
    {
        internal static bool LastReadWasGood { get; private set; }

        internal static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
        {
            var input = "";

            char nextChar;
            while (char.IsWhiteSpace(nextChar = (char) Console.Read()))
                //accumulate leading white space if skipLeadingWhiteSpace is false:
                if (!skipLeadingWhiteSpace)
                    input += nextChar;
            //the first non white space character:
            input += nextChar;

            //accumulate characters until white space is reached:
            while (!char.IsWhiteSpace(nextChar = (char) Console.Read())) input += nextChar;

            LastReadWasGood = input.Length > 0;
            return input;
        }

        internal static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
        {
            var input = "";

            char nextChar;
            if (unwantedSequence != null)
            {
                nextChar = '\0';
                for (var charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
                    if (char.IsWhiteSpace(unwantedSequence[charIndex]))
                    {
                        //ignore all subsequent white space:
                        while (char.IsWhiteSpace(nextChar = (char) Console.Read()))
                        {
                        }
                    }
                    else
                    {
                        //ensure each character matches the expected character in the sequence:
                        nextChar = (char) Console.Read();
                        if (nextChar != unwantedSequence[charIndex])
                            return null;
                    }

                input = nextChar.ToString();
                if (maxFieldLength == 1)
                    return input;
            }

            while (!char.IsWhiteSpace(nextChar = (char) Console.Read()))
            {
                input += nextChar;
                if (maxFieldLength == input.Length)
                    return input;
            }

            return input;
        }
    }
}