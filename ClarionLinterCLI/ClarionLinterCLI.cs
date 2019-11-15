using Clarion;
using Language;
using System;
using System.IO;
using System.Text;

/// <summary>
/// ClarionLinterCLI provides a command-line interface for the Clarion Linter.
/// </summary>
class ClarionLinterCLI
{

    /// <summary>
    /// A tool that allows users to run various functionality of the Clarion Linter from the
    /// command line.
    /// </summary>
    /// <param name="args">Command line arguments supplied to the program.</param>
    static void Main(string[] args)
    {
        // Get Clarion source code from user or redirected input
        string inputText = null;
        if (Console.IsInputRedirected)
            inputText = readRedirectedInput();
        else
            inputText = readUserInput();
        // Error on no supplied input
        if (string.IsNullOrEmpty(inputText))
            throw new ArgumentException("No input text supplied");
        // Create a Clarion lexer from the input text
        StreamReader input = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(inputText)));
        ClarionLexer lexer = new ClarionLexer(input);
        // Tokenize Clarion source and print results
        Console.WriteLine("\nTokenized Input:");
        while (lexer.HasNext())
        {
            Lexeme lexeme = lexer.Read();
            if (lexeme.Token is Trivia)
                continue;
            Console.Write(lexeme);
            if (lexeme.Token.Equals(Token.EOL))
                Console.WriteLine();
        }
        input.Close();
        // Wait for user input before closing
        if (!Console.IsInputRedirected)
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Reads input text from a user in a more interactive way.
    /// </summary>
    /// <returns>Input text representing Clarion source code.</returns>
    private static string readUserInput()
    {
        StringBuilder builder = new StringBuilder();
        Console.Write("Enter lines of Clarion source code (\\q to quit):\n> ");
        string line;
        while (!(line = Console.ReadLine()).Equals("\\q"))
        {
            builder.AppendLine(line);
            Console.Write("> ");
        }
        return builder.ToString();
    }

    /// <summary>
    /// Reads input text from standard input.
    /// </summary>
    /// <returns>Input text representing Clarion source code.</returns>
    private static string readRedirectedInput()
    {
        StreamReader reader = new StreamReader(Console.OpenStandardInput());
        StringBuilder builder = new StringBuilder();
        while (!reader.EndOfStream)
            builder.AppendLine(reader.ReadLine());
        reader.Close();
        return builder.ToString();
    }

}
