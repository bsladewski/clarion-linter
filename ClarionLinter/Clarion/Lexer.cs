using Language;
using System.IO;
using System.Text.RegularExpressions;

namespace Clarion
{

    /// <summary>
    /// Lexer provides a stream of Lexemes for the Clarion programming language.
    /// </summary>
    public class Lexer : ILexer
    {

        /// <summary>
        /// Used to read input source code.
        /// </summary>
        private StreamReader input;

        /// <summary>
        /// The current line of input being read.
        /// </summary>
        private int line;
        
        /// <summary>
        /// The current column of input being read.
        /// </summary>
        private int column;

        /// <summary>
        /// The current line of code being tokenized.
        /// </summary>
        private string lineContents;

        /// <summary>
        /// See <see cref="Language.ILexer.HasNext()"/>
        /// </summary>
        public bool HasNext()
        {
            return !string.IsNullOrEmpty(lineContents) || !input.EndOfStream;
        }

        /// <summary>
        /// See <see cref="Language.ILexer.Peek()"/>
        /// </summary>
        public Lexeme Peek()
        {
            // EOF if stream is empty
            if (!HasNext())
                return new Lexeme(Tokens.EOF, line, column, "");
            // Read first line of input if necessary
            if (lineContents == null & line == 1 && column == 1)
                lineContents = input.ReadLine();
            // EOL if current line is empty
            if (string.IsNullOrEmpty(lineContents))
                return new Lexeme(Tokens.EOL, line, column, "\n");
            // Find the longest matching Lexeme
            Lexeme next = null;
            foreach (Token token in Tokens.Patterns)
            {
                Match match = Regex.Match(lineContents, token.Pattern, RegexOptions.IgnoreCase);
                if (match.Equals(Match.Empty))
                    continue;
                else if (next == null || match.Length > next.Contents.Length)
                    next = new Lexeme(token, line, column, match.Value);
                else if (match.Length < next.Contents.Length)
                    continue;
                else if (token.Keyword)
                    next = new Lexeme(token, line, column, match.Value);
            }
            // Parse error if no maching Lexeme could be found
            if (next == null)
                return new Lexeme(Tokens.ParseError, line, column, lineContents);
            return next;
        }

        /// <summary>
        /// See <see cref="Language.ILexer.Read()"/>
        /// </summary>
        public Lexeme Read()
        {
            Lexeme next = Peek();
            if (next.Token.Equals(Tokens.ParseError)) // flush the contents of the stream
            {
                lineContents = null;
                input.ReadToEnd();
            }
            else if (next.Token.Equals(Tokens.EOL)) // read the next line of input
            {
                lineContents = input.ReadLine();
                line++;
                column = 1;
            }
            else // consume token contents from current line of input
            {
                lineContents = lineContents.Substring(next.Contents.Length);
                column += next.Contents.Length;
            }
            return next;
        }

        /// <summary>
        /// Constructs a Clarion Lexer on the supplied input stream.
        /// </summary>
        /// <param name="input">A stream of Clarion source code.</param>
        public Lexer(StreamReader input)
        {
            this.input = input;
            line = 1;
            column = 1;
        }

    }

}
