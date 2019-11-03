using Language;

namespace Clarion
{

    /// <summary>
    /// Lexer provides a stream of Lexemes for the Clarion programming language.
    /// </summary>
    class Lexer : ILexer
    {

        /// <summary>
        /// See <see cref="Language.ILexer.HasNext()"/>
        /// </summary>
        public bool HasNext()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// See <see cref="Language.ILexer.Peek()"/>
        /// </summary>
        public Lexeme Peek()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// See <see cref="Language.ILexer.Read()"/>
        /// </summary>
        public Lexeme Read()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Definitions for all Clarion Tokens.
        /// </summary>
        private readonly Token[] tokens =
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
            new Token("EOL",         null,                      false, false),
            new Token("EOF",         null,                      false, false),
        };

    }

}
