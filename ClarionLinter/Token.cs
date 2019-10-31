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
            new Token(TokenType.Accept, @"^ACCEPT$", true),
            new Token(TokenType.And, @"^AND$", true),
            new Token(TokenType.Begin, @"^BEGIN$", true),
            new Token(TokenType.Break, @"^BREAK$", true),
            new Token(TokenType.By, @"^BY$", true),
            new Token(TokenType.Case, @"^CASE$", true),
            new Token(TokenType.Choose, @"^CHOOSE$", true),
            new Token(TokenType.Compile, @"^COMPILE$", true),
            new Token(TokenType.Cycle, @"^CYCLE$", true),
            new Token(TokenType.Do, @"^DO$", true),
            new Token(TokenType.Else, @"^ELSE$", true),
            new Token(TokenType.ElsIf, @"^ELSIF$", true),
            new Token(TokenType.End, @"^(END|\.)$", true),
            new Token(TokenType.Execute, @"^EXECUTE$", true),
            new Token(TokenType.Exit, @"^EXIT$", true),
            new Token(TokenType.Function, @"^FUNCTION$", true),
            new Token(TokenType.GoTo, @"^GOTO$", true),
            new Token(TokenType.If, @"^IF$", true),
            new Token(TokenType.Include, @"^INCLUDE$", true),
            new Token(TokenType.Loop, @"^LOOP$", true),
            new Token(TokenType.Member, @"^MEMBER$", true),
            new Token(TokenType.New, @"^NEW$", true),
            new Token(TokenType.Not, @"^NOT$", true),
            new Token(TokenType.Null, @"^NULL$", true),
            new Token(TokenType.Of, @"^OF$", true),
            new Token(TokenType.Omit, @"^OMIT$", true),
            new Token(TokenType.Or, @"^OR$", true),
            new Token(TokenType.OrOf, @"^OROF$", true),
            new Token(TokenType.Parent, @"^PARENT$", true),
            new Token(TokenType.Procedure, @"^PROCEDURE$", true),
            new Token(TokenType.Program, @"^PROGRAM$", true),
            new Token(TokenType.Return, @"^RETURN$", true),
            new Token(TokenType.Routine, @"^ROUTINE$", true),
            new Token(TokenType.Section, @"^SECTION$", true),
            new Token(TokenType.Self, @"^SELF$", true),
            new Token(TokenType.Then, @"^THEN$", true),
            new Token(TokenType.Times, @"^TIMES$", true),
            new Token(TokenType.To, @"^TO$", true),
            new Token(TokenType.Until, @"^UNTIL$", true),
            new Token(TokenType.While, @"^WHILE$", true),
            new Token(TokenType.Xor, @"^XOR$", true),
            new Token(TokenType.Application, @"^APPLICATION$", false),
            new Token(TokenType.Class, @"^CLASS$", false),
            new Token(TokenType.Code, @"^CODE$", false),
            new Token(TokenType.Data, @"^DATA$", false),
            new Token(TokenType.Detail, @"^DETAIL$", false),
            new Token(TokenType.File, @"^FILE$", false),
            new Token(TokenType.Footer, @"^FOOTER$", false),
            new Token(TokenType.Form, @"^FORM$", false),
            new Token(TokenType.Group, @"^GROUP$", false),
            new Token(TokenType.Header, @"^HEADER$", false),
            new Token(TokenType.Item, @"^ITEM$", false),
            new Token(TokenType.Itemize, @"^ITEMIZE$", false),
            new Token(TokenType.Join, @"^JOIN$", false),
            new Token(TokenType.Map, @"^MAP$", false),
            new Token(TokenType.Menu, @"^MENU$", false),
            new Token(TokenType.MenuBar, @"^MENUBAR$", false),
            new Token(TokenType.Module, @"^MODULE$", false),
            new Token(TokenType.OleControl, @"^OLECONTROL$", false),
            new Token(TokenType.Option, @"^OPTION$", false),
            new Token(TokenType.Queue, @"^QUEUE$", false),
            new Token(TokenType.Record, @"^RECORD$", false),
            new Token(TokenType.Report, @"^REPORT$", false),
            new Token(TokenType.Row, @"^ROW$", false),
            new Token(TokenType.Sheet, @"^SHEET$", false),
            new Token(TokenType.Tab, @"^TAB$", false),
            new Token(TokenType.Table, @"^TABLE$", false),
            new Token(TokenType.ToolBar, @"^TOOLBAR$", false),
            new Token(TokenType.View, @"^VIEW$", false),
            new Token(TokenType.Window, @"^WINDOW$", false),
            new Token(TokenType.Asterisk, @"^\*$", false),
            new Token(TokenType.At, @"^\@$", false),
            new Token(TokenType.Bar, @"^\|$", false),
            new Token(TokenType.Colon, @"^\:$", false),
            new Token(TokenType.Comma, @"^\,$", false),
            new Token(TokenType.Dollar, @"^\$$", false),
            new Token(TokenType.DoubleQuote, @"^\""$", false),
            new Token(TokenType.Exclamation, @"^\!$", false),
            new Token(TokenType.LeftAngleBracket, @"^\<$", false),
            new Token(TokenType.LeftCurlyBrace, @"^\{$", false),
            new Token(TokenType.LeftParen, @"^\($", false),
            new Token(TokenType.LeftSquareBracket, @"^\[$", false),
            new Token(TokenType.Period, @"^\.$", false),
            new Token(TokenType.Pound, @"^\#$", false),
            new Token(TokenType.Question, @"^\?$", false),
            new Token(TokenType.RightAngleBracket, @"^\>$", false),
            new Token(TokenType.RightCurlyBrace, @"^\}$", false),
            new Token(TokenType.RightParen, @"^\)$", false),
            new Token(TokenType.RightSquareBracket, @"^\]$", false),
            new Token(TokenType.Semicolon, @"^\;$", false),
            new Token(TokenType.SingleQuote, @"^'$", false),
            new Token(TokenType.Tilde, @"^~$", false),
            new Token(TokenType.Comment, @"^!.*$", false),
            new Token(TokenType.EOF, @"", false),
            new Token(TokenType.EOL, @"", false),
            new Token(TokenType.Indentifier, @"^([A-Z]|_)\w*$", false),
            new Token(TokenType.WhitespaceTrivia, @"^\s+$", false)
        };
        
    }

}
