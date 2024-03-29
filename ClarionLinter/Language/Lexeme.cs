﻿namespace Language
{

    /// <summary>
    /// A Lexeme combines the abstract and concrete representation of a lexical unit of a
    /// programming language.
    /// </summary>
    public class Lexeme
    {

        /// <summary>
        /// The abstract representation of this Lexeme as a lexical unit of a programming language.
        /// </summary>
        public readonly Token Token;

        /// <summary>
        /// The current text representation of this Lexeme.
        /// </summary>
        public string Contents;

        /// <summary>
        /// The line number where this Lexeme originally occurred.
        /// </summary>
        public readonly int Line;

        /// <summary>
        /// The column number where this Lexeme originally occurred.
        /// </summary>
        public readonly int Column;
        
        /// <summary>
        /// Constructs a Lexeme.
        /// </summary>
        /// <param name="token">The abstract representation of this Lexeme.</param>
        /// <param name="line">The line this Lexeme occurred.</param>
        /// <param name="column">The column this Lexeme occurred.</param>
        /// <param name="contents">The concrete representation of this Lexeme.</param>
        public Lexeme(Token token, int line, int column, string contents)
        {
            Token = token;
            Line = line;
            Column = column;
            Contents = contents;
        }

        /// <summary>
        /// See <see cref="object.ToString()"/>
        /// </summary>
        public override string ToString()
        {
            return string.Format("<{0}>", Token);
        }

    }

}
