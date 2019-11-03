using Language;
using System.IO;
using System.Text.RegularExpressions;

namespace Clarion
{

    /// <summary>
    /// Lexer provides a stream of Lexemes for the Clarion programming language.
    /// </summary>
    class Lexer : ILexer
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
                return new Lexeme(EOF, line, column, "");
            // Read first line of input if necessary
            if (lineContents == null & line == 1 && column == 1)
                lineContents = input.ReadLine();
            // EOL if current line is empty
            if (string.IsNullOrEmpty(lineContents))
                return new Lexeme(EOL, line, column, "\n");
            // Find the longest matching Lexeme
            Lexeme next = null;
            foreach (Token token in tokens)
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
                return new Lexeme(ParseError, line, column, lineContents);
            return next;
        }

        /// <summary>
        /// See <see cref="Language.ILexer.Read()"/>
        /// </summary>
        public Lexeme Read()
        {
            Lexeme next = Peek();
            if (next.Token.Equals(ParseError)) // flush the contents of the stream
            {
                lineContents = null;
                input.ReadToEnd();
            }
            else if (next.Token.Equals(EOL)) // read the next line of input
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

        /// <summary>
        /// End of line token.
        /// </summary>
        private static readonly Token EOL = new Token("EOL", null, false, false);

        /// <summary>
        /// End of file token.
        /// </summary>
        private static readonly Token EOF = new Token("EOF", null, false, false);

        /// <summary>
        /// A token that indicates a parse error occurred.
        /// </summary>
        private static readonly Token ParseError = new Token("ParseError", null, false, false);

        /// <summary>
        /// Definitions for all Clarion Tokens.
        /// </summary>
        private static readonly Token[] tokens =
        {
            // Reserved Words
            new Token("Accept",      @"^ACCEPT",                true,  true),
            new Token("And",         @"^AND",                   true,  true),
            new Token("Begin",       @"^BEGIN",                 true,  true),
            new Token("Break",       @"^BREAK",                 true,  true),
            new Token("By",          @"^BY",                    true,  true),
            new Token("Case",        @"^CASE",                  true,  true),
            new Token("Choose",      @"^CHOOSE",                true,  true),
            new Token("Compile",     @"^COMPILE",               true,  true),
            new Token("Cycle",       @"^CYCLE",                 true,  true),
            new Token("Do",          @"^DO",                    true,  true),
            new Token("Else",        @"^ELSE",                  true,  true),
            new Token("ElsIf",       @"^ELSIF",                 true,  true),
            new Token("End",         @"^END",                   true,  true),
            new Token("Execute",     @"^EXECUTE",               true,  true),
            new Token("Exit",        @"^EXIT",                  true,  true),
            new Token("Function",    @"^FUNCTION",              true,  true),
            new Token("Goto",        @"^GOTO",                  true,  true),
            new Token("If",          @"^IF",                    true,  true),
            new Token("Include",     @"^INCLUDE",               true,  true),
            new Token("Loop",        @"^LOOP",                  true,  true),
            new Token("Member",      @"^MEMBER",                true,  true),
            new Token("New",         @"^NEW",                   true,  true),
            new Token("Not",         @"^NOT",                   true,  true),
            new Token("Null",        @"^NULL",                  true,  true),
            new Token("Of",          @"^OF",                    true,  true),
            new Token("Omit",        @"^OMIT",                  true,  true),
            new Token("Or",          @"^OR",                    true,  true),
            new Token("OrOf",        @"^OROF",                  true,  true),
            new Token("Parent",      @"^PARENT",                true,  true),
            new Token("Procedure",   @"^PROCEDURE",             true,  true),
            new Token("Program",     @"^PROGRAM",               true,  true),
            new Token("Return",      @"^RETURN",                true,  true),
            new Token("Routine",     @"^ROUTINE",               true,  true),
            new Token("Section",     @"^SECTION",               true,  true),
            new Token("Self",        @"^SELF",                  true,  true),
            new Token("Then",        @"^THEN",                  true,  true),
            new Token("Times",       @"^TIMES",                 true,  true),
            new Token("To",          @"^TO",                    true,  true),
            new Token("Until",       @"^UNTIL",                 true,  true),
            new Token("While",       @"^WHILE",                 true,  true),
            new Token("Xor",         @"^XOR",                   true,  true),
            // Keywords
            new Token("Application", @"^APPLICATION",           false, true),
            new Token("Class",       @"^CLASS",                 false, true),
            new Token("Code",        @"^CODE",                  false, true),
            new Token("Data",        @"^DATA",                  false, true),
            new Token("Detail",      @"^DETAIL",                false, true),
            new Token("File",        @"^FILE",                  false, true),
            new Token("Footer",      @"^FOOTER",                false, true),
            new Token("Form",        @"^FORM",                  false, true),
            new Token("Group",       @"^GROUP",                 false, true),
            new Token("Header",      @"^HEADER",                false, true),
            new Token("Item",        @"^ITEM",                  false, true),
            new Token("Itemize",     @"^ITEMIZE",               false, true),
            new Token("Join",        @"^JOIN",                  false, true),
            new Token("Map",         @"^MAP",                   false, true),
            new Token("Menu",        @"^MENU",                  false, true),
            new Token("MenuBar",     @"^MENUBAR",               false, true),
            new Token("Module",      @"^MODULE",                false, true),
            new Token("OleControl",  @"^OLECONTROL",            false, true),
            new Token("Option",      @"^OPTION",                false, true),
            new Token("Queue",       @"^QUEUE",                 false, true),
            new Token("Record",      @"^RECORD",                false, true),
            new Token("Report",      @"^REPORT",                false, true),
            new Token("Row",         @"^ROW",                   false, true),
            new Token("Sheet",       @"^SHEET",                 false, true),
            new Token("Tab",         @"^TAB",                   false, true),
            new Token("Table",       @"^TABLE",                 false, true),
            new Token("ToolBar",     @"^TOOLBAR",               false, true),
            new Token("View",        @"^VIEW",                  false, true),
            new Token("Window",      @"^WINDOW",                false, true),
            // Symbols
            new Token("Asterisk",    @"^\*",                    false, false),
            new Token("At",          @"^\@",                    false, false),
            new Token("Backslash",   @"^\\",                    false, false),
            new Token("Bang",        @"^\!",                    false, false),
            new Token("Bar",         @"^\|",                    false, false),
            new Token("Colon",       @"^\:",                    false, false),
            new Token("Comma",       @"^\,",                    false, false),
            new Token("Dollar",      @"^\$",                    false, false),
            new Token("DoubleQuote", @"^\""",                   false, false),
            new Token("Equals",      @"^\=",                    false, false),
            new Token("Solidus",     @"^\/",                    false, false),
            new Token("LeftAngled",  @"^\<",                    false, false),
            new Token("LeftCurly",   @"^\{",                    false, false),
            new Token("LeftParen",   @"^\(",                    false, false),
            new Token("LeftSquare",  @"^\[",                    false, false),
            new Token("Minus",       @"^\-",                    false, false),
            new Token("Period",      @"^\.",                    false, false),
            new Token("Plus",        @"^\+",                    false, false),
            new Token("Pound",       @"^\#",                    false, false),
            new Token("Question",    @"^\?",                    false, false),
            new Token("RightAngled", @"^\>",                    false, false),
            new Token("RightCurly",  @"^\}",                    false, false),
            new Token("RightParen",  @"^\)",                    false, false),
            new Token("RightSquare", @"^\]",                    false, false),
            new Token("Semicolon",   @"^\;",                    false, false),
            new Token("SingleQuote", @"^\'",                    false, false),
            new Token("Tilde",       @"^\~",                    false, false),
            // Other
            new Token("Identifier",  @"^([A-Z]\_)\w*",          false, false),
            new Token("Number",      @"^(\+|\-)?\d+(\.\d+)?",   false, false),
            new Token("Picture",     @"^\@([^\s|\~]+|\~.*\~)+", false, false),
            new Token("String",      @"^\'([^\']|\'\')*\'",     false, false),
            new Token("Whitespace",  @"^\s+",                   false, false),
        };

    }

}
