using System.IO;
using System.Text.RegularExpressions;

namespace Language
{

    /// <summary>
    /// A DefaultLexer tokenizes a programming language line-by-line.
    /// </summary>
    public class DefaultLexer : ILexer
    {

        /// <summary>
        /// The lexical specification that will be used to tokenize input.
        /// </summary>
        private LexicalSpec spec;

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
                return new Lexeme(Token.EOF, line, column, "");
            // Read first line of input if necessary
            if (lineContents == null & line == 1 && column == 1)
                lineContents = input.ReadLine();
            // EOL if current line is empty
            if (string.IsNullOrEmpty(lineContents))
                return new Lexeme(Token.EOL, line, column, "\n");
            // Find the longest matching Lexeme
            Lexeme next = null;
            foreach (Token token in spec.Tokens)
            {
                // Prepare regular expression and matching options.
                string pattern = token.Pattern;
                if (string.IsNullOrEmpty(pattern))
                    pattern = string.Format("^{0}", Regex.Escape(token.Name));
                RegexOptions options = RegexOptions.None;
                if (token.Insensitive == true || (spec.Insensitive && token.Insensitive != false))
                    options = RegexOptions.IgnoreCase;
                Match match = Regex.Match(lineContents, pattern, options);
                if (match.Equals(Match.Empty))
                    // If no match is found we can continue onto the next token type
                    continue;
                else if (next == null || match.Length > next.Contents.Length)
                    // If next is null or shorter than the current match, use the current match
                    // We always want to take the longest matching token type
                    next = new Lexeme(token, line, column, match.Value);
                else if (match.Length < next.Contents.Length)
                    // If a longer match has already been found there is nothing to do
                    continue;
                else if (token is Keyword || token is ReservedWord)
                    // Identifier tokens will typically match keywords
                    // We always want to assume we're looking a keyword
                    next = new Lexeme(token, line, column, match.Value);
            }
            // Parse error if no maching Lexeme could be found
            if (next == null)
                return new Lexeme(Token.ParseError, line, column, lineContents);
            return next;
        }

        /// <summary>
        /// See <see cref="Language.ILexer.Read()"/>
        /// </summary>
        public Lexeme Read()
        {
            Lexeme next = Peek();
            if (next.Token.Equals(Token.ParseError)) 
            {
                // Flush the contents of the stream so no further tokens are read
                // There is no guarantee matching after this point will be accurate
                lineContents = null;
                input.ReadToEnd();
            }
            else if (next.Token.Equals(Token.EOL)) 
            {
                // Read the next line of input
                lineContents = input.ReadLine();
                line++;
                column = 1;
            }
            else
            {
                // Consume token contents from current line of input
                lineContents = lineContents.Substring(next.Contents.Length);
                column += next.Contents.Length;
            }
            return next;
        }

        /// <summary>
        /// Constructs a DefaultLexer on the supplied input stream.
        /// </summary>
        /// <param name="spec">A lexical specification used for tokenizing input.</param>
        /// <param name="input">A stream of source code.</param>
        public DefaultLexer(LexicalSpec spec, StreamReader input)
        {
            this.spec = spec;
            this.input = input;
            line = 1;
            column = 1;
        }

    }

}
