namespace ClarionLinter
{

    /// <summary>
    /// A Token is an abstract representation of a lexical unit of the Clarion language.
    /// </summary>
    class Token
    {

        /// <summary>
        /// The general type of token represented.
        /// </summary>
        public readonly TokenType Type;

        /// <summary>
        /// A regular expression that matches an occurance of this token.
        /// </summary>
        public readonly string Regex;

        /// <summary>
        /// Whether the token is a reserved word in the Clarion language.
        /// </summary>
        public readonly bool Reserved;

        /// <summary>
        /// Constructs a Token definition.
        /// </summary>
        /// <param name="type">The general type of token.</param>
        /// <param name="regex">A regular expression that matches this token.</param>
        /// <param name="reserved">Whether this token represents a reservered word.</param>
        public Token(TokenType type, string regex, bool reserved)
        {
            Type = type;
            Regex = regex;
            Reserved = reserved;
        }

        /// <summary>
        /// Tokens defines all available Clarion tokens.
        /// </summary>
        public static readonly Token[] Tokens = {
            new Token(TokenType.Accept, @"", true),
            new Token(TokenType.And, @"", true),
            new Token(TokenType.Begin, @"", true),
            new Token(TokenType.Break, @"", true),
            new Token(TokenType.By, @"", true),
            new Token(TokenType.Case, @"", true),
            new Token(TokenType.Choose, @"", true),
            new Token(TokenType.Compile, @"", true),
            new Token(TokenType.Cycle, @"", true),
            new Token(TokenType.Do, @"", true),
            new Token(TokenType.Else, @"", true),
            new Token(TokenType.ElsIf, @"", true),
            new Token(TokenType.End, @"", true),
            new Token(TokenType.Execute, @"", true),
            new Token(TokenType.Exit, @"", true),
            new Token(TokenType.Function, @"", true),
            new Token(TokenType.GoTo, @"", true),
            new Token(TokenType.If, @"", true),
            new Token(TokenType.Include, @"", true),
            new Token(TokenType.Loop, @"", true),
            new Token(TokenType.Member, @"", true),
            new Token(TokenType.New, @"", true),
            new Token(TokenType.Not, @"", true),
            new Token(TokenType.Null, @"", true),
            new Token(TokenType.Of, @"", true),
            new Token(TokenType.Omit, @"", true),
            new Token(TokenType.Or, @"", true),
            new Token(TokenType.OrOf, @"", true),
            new Token(TokenType.Parent, @"", true),
            new Token(TokenType.Procedure, @"", true),
            new Token(TokenType.Program, @"", true),
            new Token(TokenType.Return, @"", true),
            new Token(TokenType.Routine, @"", true),
            new Token(TokenType.Section, @"", true),
            new Token(TokenType.Self, @"", true),
            new Token(TokenType.Then, @"", true),
            new Token(TokenType.Times, @"", true),
            new Token(TokenType.To, @"", true),
            new Token(TokenType.Until, @"", true),
            new Token(TokenType.While, @"", true),
            new Token(TokenType.Xor, @"", true),
            new Token(TokenType.Application, @"", false),
            new Token(TokenType.Class, @"", false),
            new Token(TokenType.Code, @"", false),
            new Token(TokenType.Data, @"", false),
            new Token(TokenType.Detail, @"", false),
            new Token(TokenType.File, @"", false),
            new Token(TokenType.Footer, @"", false),
            new Token(TokenType.Form, @"", false),
            new Token(TokenType.Group, @"", false),
            new Token(TokenType.Header, @"", false),
            new Token(TokenType.Item, @"", false),
            new Token(TokenType.Itemize, @"", false),
            new Token(TokenType.Join, @"", false),
            new Token(TokenType.Map, @"", false),
            new Token(TokenType.Menu, @"", false),
            new Token(TokenType.MenuBar, @"", false),
            new Token(TokenType.Module, @"", false),
            new Token(TokenType.OleControl, @"", false),
            new Token(TokenType.Option, @"", false),
            new Token(TokenType.Queue, @"", false),
            new Token(TokenType.Record, @"", false),
            new Token(TokenType.Report, @"", false),
            new Token(TokenType.Row, @"", false),
            new Token(TokenType.Sheet, @"", false),
            new Token(TokenType.Tab, @"", false),
            new Token(TokenType.Table, @"", false),
            new Token(TokenType.ToolBar, @"", false),
            new Token(TokenType.View, @"", false),
            new Token(TokenType.Window, @"", false),
            new Token(TokenType.Indentifier, @"", false),
            new Token(TokenType.Comment, @"", false),
            new Token(TokenType.WhitespaceTrivia, @"", false)
        };
        
    }

}
