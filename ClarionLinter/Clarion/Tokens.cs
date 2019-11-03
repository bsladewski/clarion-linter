using Language;

namespace Clarion
{

    /// <summary>
    /// Contains definitions for all Clarion Tokens.
    /// </summary>
    class Tokens
    {
    
        /// <summary>
        /// End of line token.
        /// </summary>
        public static readonly Token EOL = new Token("EOL", null, false, false);

        /// <summary>
        /// End of file token.
        /// </summary>
        public static readonly Token EOF = new Token("EOF", null, false, false);

        /// <summary>
        /// A token that indicates a parse error occurred.
        /// </summary>
        public static readonly Token ParseError = new Token("ParseError", null, false, false);

        /// <summary>
        /// The ACCEPT reserved word.
        /// </summary>
        public static readonly Token Accept = new Token("Accept", @"^ACCEPT", true, true);

        /// <summary>
        /// The AND reserved word.
        /// </summary>
        public static readonly Token And = new Token("And", @"^AND", true, true);

        /// <summary>
        /// The BEGIN reserved word.
        /// </summary>
        public static readonly Token Begin = new Token("Begin", @"^BEGIN", true, true);

        /// <summary>
        /// The BREAK reserved word.
        /// </summary>
        public static readonly Token Break = new Token("Break", @"^BREAK", true, true);

        /// <summary>
        /// The BY reserved word.
        /// </summary>
        public static readonly Token By = new Token("By", @"^BY", true, true);

        /// <summary>
        /// The CASE reserved word.
        /// </summary>
        public static readonly Token Case = new Token("Case", @"^CASE", true, true);

        /// <summary>
        /// The CHOOSE reserved word.
        /// </summary>
        public static readonly Token Choose = new Token("Choose", @"^CHOOSE", true, true);

        /// <summary>
        /// The COMPILE reserved word.
        /// </summary>
        public static readonly Token Compile = new Token("Compile", @"^COMPILE", true, true);

        /// <summary>
        /// The CYCLE reserved word.
        /// </summary>
        public static readonly Token Cycle = new Token("Cycle", @"^CYCLE", true, true);

        /// <summary>
        /// The DO reserved word.
        /// </summary>
        public static readonly Token Do = new Token("Do", @"^DO", true, true);

        /// <summary>
        /// The ELSE reserved word.
        /// </summary>
        public static readonly Token Else = new Token("Else", @"^ELSE", true, true);

        /// <summary>
        /// The ELSIF reserved word.
        /// </summary>
        public static readonly Token ElsIf = new Token("ElsIf", @"^ELSIF", true, true);

        /// <summary>
        /// The END reserved word.
        /// </summary>
        public static readonly Token End = new Token("End", @"^END", true, true);

        /// <summary>
        /// The EXECUTE reserved word.
        /// </summary>
        public static readonly Token Execute = new Token("Execute", @"^EXECUTE", true, true);

        /// <summary>
        /// The EXIT reserved word.
        /// </summary>
        public static readonly Token Exit = new Token("Exit", @"^EXIT", true, true);

        /// <summary>
        /// The FUNCTION reserved word.
        /// </summary>
        public static readonly Token Function = new Token("Function", @"^FUNCTION", true, true);

        /// <summary>
        /// The GOTO reserved word.
        /// </summary>
        public static readonly Token Goto = new Token("Goto", @"^GOTO", true, true);

        /// <summary>
        /// The IF reserved word.
        /// </summary>
        public static readonly Token If = new Token("If", @"^IF", true, true);

        /// <summary>
        /// The INCLUDE reserved word.
        /// </summary>
        public static readonly Token Include = new Token("Include", @"^INCLUDE", true, true);

        /// <summary>
        /// The LOOP reserved word.
        /// </summary>
        public static readonly Token Loop = new Token("Loop", @"^LOOP", true, true);

        /// <summary>
        /// The MEMBER reserved word.
        /// </summary>
        public static readonly Token Member = new Token("Member", @"^MEMBER", true, true);

        /// <summary>
        /// The NEW reserved word.
        /// </summary>
        public static readonly Token New = new Token("New", @"^NEW", true, true);

        /// <summary>
        /// The NOT reserved word.
        /// </summary>
        public static readonly Token Not = new Token("Not", @"^NOT", true, true);

        /// <summary>
        /// The NULL reserved word.
        /// </summary>
        public static readonly Token Null = new Token("Null", @"^NULL", true, true);

        /// <summary>
        /// The OF reserved word.
        /// </summary>
        public static readonly Token Of = new Token("Of", @"^OF", true, true);

        /// <summary>
        /// The OMIT reserved word.
        /// </summary>
        public static readonly Token Omit = new Token("Omit", @"^OMIT", true, true);

        /// <summary>
        /// The OR reserved word.
        /// </summary>
        public static readonly Token Or = new Token("Or", @"^OR", true, true);

        /// <summary>
        /// The OROF reserved word.
        /// </summary>
        public static readonly Token OrOf = new Token("OrOf", @"^OROF", true, true);

        /// <summary>
        /// The PARENT reserved word.
        /// </summary>
        public static readonly Token Parent = new Token("Parent", @"^PARENT", true, true);

        /// <summary>
        /// The PROCEDURE reserved word.
        /// </summary>
        public static readonly Token Procedure = new Token("Procedure", @"^PROCEDURE", true, true);

        /// <summary>
        /// The PROGRAM reserved word.
        /// </summary>
        public static readonly Token Program = new Token("Program", @"^PROGRAM", true, true);

        /// <summary>
        /// The RETURN reserved word.
        /// </summary>
        public static readonly Token Return = new Token("Return", @"^RETURN", true, true);

        /// <summary>
        /// The ROUTINE reserved word.
        /// </summary>
        public static readonly Token Routine = new Token("Routine", @"^ROUTINE", true, true);

        /// <summary>
        /// The SECTION reserved word.
        /// </summary>
        public static readonly Token Section = new Token("Section", @"^SECTION", true, true);

        /// <summary>
        /// The SELF reserved word.
        /// </summary>
        public static readonly Token Self = new Token("Self", @"^SELF", true, true);

        /// <summary>
        /// The THEN reserved word.
        /// </summary>
        public static readonly Token Then = new Token("Then", @"^THEN", true, true);

        /// <summary>
        /// The TIMES reserved word.
        /// </summary>
        public static readonly Token Times = new Token("Times", @"^TIMES", true, true);

        /// <summary>
        /// The TO reserved word.
        /// </summary>
        public static readonly Token To = new Token("To", @"^TO", true, true);

        /// <summary>
        /// The UNTIL reserved word.
        /// </summary>
        public static readonly Token Until = new Token("Until", @"^UNTIL", true, true);

        /// <summary>
        /// The WHILE reserved word.
        /// </summary>
        public static readonly Token While = new Token("While", @"^WHILE", true, true);

        /// <summary>
        /// The XOR reserved word.
        /// </summary>
        public static readonly Token Xor = new Token("Xor", @"^XOR", true, true);

        /// <summary>
        /// The APPLICATION keyword.
        /// </summary>
        public static readonly Token Application = new Token("Application", @"^APPLICATION", false, true);

        /// <summary>
        /// The CLASS keyword.
        /// </summary>
        public static readonly Token Class = new Token("Class", @"^CLASS", false, true);

        /// <summary>
        /// The CODE keyword.
        /// </summary>
        public static readonly Token Code = new Token("Code", @"^CODE", false, true);

        /// <summary>
        /// The DATA keyword.
        /// </summary>
        public static readonly Token Data = new Token("Data", @"^DATA", false, true);

        /// <summary>
        /// The DETAIL keyword.
        /// </summary>
        public static readonly Token Detail = new Token("Detail", @"^DETAIL", false, true);

        /// <summary>
        /// The FILE keyword.
        /// </summary>
        public static readonly Token File = new Token("File", @"^FILE", false, true);

        /// <summary>
        /// The FOOTER keyword.
        /// </summary>
        public static readonly Token Footer = new Token("Footer", @"^FOOTER", false, true);

        /// <summary>
        /// The FORM keyword.
        /// </summary>
        public static readonly Token Form = new Token("Form", @"^FORM", false, true);

        /// <summary>
        /// The GROUP keyword.
        /// </summary>
        public static readonly Token Group = new Token("Group", @"^GROUP", false, true);

        /// <summary>
        /// The HEADER keyword.
        /// </summary>
        public static readonly Token Header = new Token("Header", @"^HEADER", false, true);

        /// <summary>
        /// The ITEM keyword.
        /// </summary>
        public static readonly Token Item = new Token("Item", @"^ITEM", false, true);

        /// <summary>
        /// The ITEMIZE keyword.
        /// </summary>
        public static readonly Token Itemize = new Token("Itemize", @"^ITEMIZE", false, true);

        /// <summary>
        /// The JOIN keyword.
        /// </summary>
        public static readonly Token Join = new Token("Join", @"^JOIN", false, true);

        /// <summary>
        /// The MAP keyword.
        /// </summary>
        public static readonly Token Map = new Token("Map", @"^MAP", false, true);

        /// <summary>
        /// The MENU keyword.
        /// </summary>
        public static readonly Token Menu = new Token("Menu", @"^MENU", false, true);

        /// <summary>
        /// The MENUBAR keyword.
        /// </summary>
        public static readonly Token MenuBar = new Token("MenuBar", @"^MENUBAR", false, true);

        /// <summary>
        /// The MODULE keyword.
        /// </summary>
        public static readonly Token Module = new Token("Module", @"^MODULE", false, true);

        /// <summary>
        /// The OLECONTROL keyword.
        /// </summary>
        public static readonly Token OleControl = new Token("OleControl", @"^OLECONTROL", false, true);

        /// <summary>
        /// The OPTION keyword.
        /// </summary>
        public static readonly Token Option = new Token("Option", @"^OPTION", false, true);

        /// <summary>
        /// The QUEUE keyword.
        /// </summary>
        public static readonly Token Queue = new Token("Queue", @"^QUEUE", false, true);

        /// <summary>
        /// The RECORD keyword.
        /// </summary>
        public static readonly Token Record = new Token("Record", @"^RECORD", false, true);

        /// <summary>
        /// The REPORT keyword.
        /// </summary>
        public static readonly Token Report = new Token("Report", @"^REPORT", false, true);

        /// <summary>
        /// The ROW keyword.
        /// </summary>
        public static readonly Token Row = new Token("Row", @"^ROW", false, true);

        /// <summary>
        /// The SHEET keyword.
        /// </summary>
        public static readonly Token Sheet = new Token("Sheet", @"^SHEET", false, true);

        /// <summary>
        /// The TAB keyword.
        /// </summary>
        public static readonly Token Tab = new Token("Tab", @"^TAB", false, true);

        /// <summary>
        /// The TABLE keyword.
        /// </summary>
        public static readonly Token Table = new Token("Table", @"^TABLE", false, true);

        /// <summary>
        /// The TOOLBAR keyword.
        /// </summary>
        public static readonly Token ToolBar = new Token("ToolBar", @"^TOOLBAR",false, true);

        /// <summary>
        /// The VIEW keyword.
        /// </summary>
        public static readonly Token View = new Token("View", @"^VIEW", false, true);

        /// <summary>
        /// The WINDOW keyword.
        /// </summary>
        public static readonly Token Window = new Token("Window", @"^WINDOW", false, true);

        /// <summary>
        /// The '*' symbol.
        /// </summary>
        public static readonly Token Asterisk = new Token("Asterisk", @"^\*", false, false);

        /// <summary>
        /// The '@' symbol.
        /// </summary>
        public static readonly Token At = new Token("At", @"^\@", false, false);

        /// <summary>
        /// The '\' symbol.
        /// </summary>
        public static readonly Token Backslash = new Token("Backslash", @"^\\", false, false);

        /// <summary>
        /// The '!' symbol.
        /// </summary>
        public static readonly Token Bang = new Token("Bang", @"^\!", false, false);

        /// <summary>
        /// The '|' symbol.
        /// </summary>
        public static readonly Token Bar = new Token("Bar", @"^\|", false, false);

        /// <summary>
        /// The ':' symbol.
        /// </summary>
        public static readonly Token Colon = new Token("Colon", @"^\:", false, false);

        /// <summary>
        /// The ',' symbol.
        /// </summary>
        public static readonly Token Comma = new Token("Comma", @"^\,", false, false);

        /// <summary>
        /// The '$' symbol.
        /// </summary>
        public static readonly Token Dollar = new Token("Dollar", @"^\$", false, false);

        /// <summary>
        /// The '"' symbol.
        /// </summary>
        public static readonly Token DoubleQuote = new Token("DoubleQuote", @"^\""", false, false);

        /// <summary>
        /// The '=' symbol.
        /// </summary>
        public new static readonly Token Equals = new Token("Equals", @"^\=", false, false);

        /// <summary>
        /// The '/' symbol.
        /// </summary>
        public static readonly Token Solidus = new Token("Solidus", @"^\/", false, false);

        /// <summary>
        /// The '&lt;' symbol.
        /// </summary>
        public static readonly Token LeftAngled = new Token("LeftAngled", @"^\<", false, false);

        /// <summary>
        /// The '{' symbol.
        /// </summary>
        public static readonly Token LeftCurly = new Token("LeftCurly", @"^\{", false, false);

        /// <summary>
        /// The '(' symbol.
        /// </summary>
        public static readonly Token LeftParen = new Token("LeftParen", @"^\(", false, false);

        /// <summary>
        /// The '[' symbol.
        /// </summary>
        public static readonly Token LeftSquare = new Token("LeftSquare", @"^\[", false, false);

        /// <summary>
        /// The '-' symbol.
        /// </summary>
        public static readonly Token Minus = new Token("Minus", @"^\-", false, false);

        /// <summary>
        /// The '.' symbol.
        /// </summary>
        public static readonly Token Period = new Token("Period", @"^\.", false, false);

        /// <summary>
        /// The '+' symbol.
        /// </summary>
        public static readonly Token Plus = new Token("Plus", @"^\+", false, false);

        /// <summary>
        /// The '#' symbol.
        /// </summary>
        public static readonly Token Pound = new Token("Pound", @"^\#", false, false);

        /// <summary>
        /// The '?' symbol.
        /// </summary>
        public static readonly Token Question = new Token("Question", @"^\?", false, false);

        /// <summary>
        /// The '&gt;' symbol.
        /// </summary>
        public static readonly Token RightAngled = new Token("RightAngled", @"^\>", false, false);

        /// <summary>
        /// The '}' symbol.
        /// </summary>
        public static readonly Token RightCurly = new Token("RightCurly", @"^\}", false, false);

        /// <summary>
        /// The ')' symbol.
        /// </summary>
        public static readonly Token RightParen = new Token("RightParen", @"^\)", false, false);

        /// <summary>
        /// The ']' symbol.
        /// </summary>
        public static readonly Token RightSquare = new Token("RightSquare", @"^\]", false, false);

        /// <summary>
        /// The ';' symbol.
        /// </summary>
        public static readonly Token Semicolon = new Token("Semicolon", @"^\;", false, false);

        /// <summary>
        /// The ''' symbol.
        /// </summary>
        public static readonly Token SingleQuote = new Token("SingleQuote", @"^\'", false, false);

        /// <summary>
        /// The '~' symbol.
        /// </summary>
        public static readonly Token Tilde = new Token("Tilde", @"^\~", false, false);

        /// <summary>
        /// An end of line comment.
        /// </summary>
        public static readonly Token Comment = new Token("Comment", @"^\!.*", false, false);

        /// <summary>
        /// A user defined identifier.
        /// </summary>
        public static readonly Token Identifier = new Token("Identifier", @"^([A-Z]|_)\w*", false, false);

        /// <summary>
        /// A number literal.
        /// </summary>
        public static readonly Token Number = new Token("Number", @"^(\+|\-)?\d+(\.\d+)?", false, false);

        /// <summary>
        /// A Clarion picture token.
        /// </summary>
        public static readonly Token Picture = new Token("Picture", @"^\@([^\s|\~]+|\~.*\~)+", false, false);

        /// <summary>
        /// A string literal.
        /// </summary>
        public static readonly Token String = new Token("String", @"^\'([^\']|\'\')*\'", false, false);

        /// <summary>
        /// A run of whitespace characters.
        /// </summary>
        public static readonly Token Whitespace = new Token("Whitespace", @"^\s+", false, false);

        /// <summary>
        /// An array containing all Tokens that are matched by pattern.
        /// </summary>
        public static readonly Token[] Patterns =
        {
            Accept, And, Begin, Break, By, Case, Choose, Compile, Cycle, Do, Else, ElsIf, End,
            Execute, Exit, Function, Goto, If, Include, Loop, Member, New, Not, Null, Of, Omit,
            Or, OrOf, Parent, Procedure, Program, Return, Routine, Section, Self, Then, Times,
            To, Until, While, Xor, Application, Class, Code, Data, Detail, File, Footer, Form,
            Group, Header, Item, Itemize, Join, Map, Menu, MenuBar, Module, OleControl, Option,
            Queue, Record, Report, Row, Sheet, Tab, Table, ToolBar, View, Window, Asterisk, At,
            Backslash, Bang, Bar, Colon, Comma, Dollar, DoubleQuote, Equals, Solidus, LeftAngled,
            LeftCurly, LeftParen, LeftSquare, Minus, Period, Plus, Pound, Question, RightAngled,
            RightCurly, RightParen, RightSquare, Semicolon, SingleQuote, Tilde, Comment,
            Identifier, Number, Picture, String
        };

    }

}
