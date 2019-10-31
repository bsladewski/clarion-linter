﻿namespace ClarionLinter
{

    /// <summary>
    /// An enumeration of distinct types of Clarion tokens.
    /// </summary>
    enum TokenType
    {

        // Reserved Words
        Accept,
        And,
        Begin,
        Break,
        By,
        Case,
        Choose,
        Compile,
        Cycle,
        Do,
        Else,
        ElsIf,
        End,
        Execute,
        Exit,
        Function,
        GoTo,
        If,
        Include,
        Loop,
        Member,
        New,
        Not,
        Null,
        Of,
        Omit,
        Or,
        OrOf,
        Parent,
        Procedure,
        Program,
        Return,
        Routine,
        Section,
        Self,
        Then,
        Times,
        To,
        Until,
        While,
        Xor,

        // Other Keywords
        Application,
        Class,
        Code,
        Data,
        Detail,
        File,
        Footer,
        Form,
        Group,
        Header,
        Item,
        Itemize,
        Join,
        Map,
        Menu,
        MenuBar,
        Module,
        OleControl,
        Option,
        Queue,
        Record,
        Report,
        Row,
        Sheet,
        Tab,
        Table,
        ToolBar,
        View,
        Window,
        
        // Other
        Indentifier,
        Comment,
        WhitespaceTrivia
        
    }

}
