﻿namespace ClarionLinter
{

    /// <summary>
    /// A Lexeme combines the abstract and concrete representation of a lexical unit of the
    /// Clarion language.
    /// </summary>
    class Lexeme
    {

        /// <summary>
        /// An abstract representation of this Lexeme as a lexical unit of the Clarion
        /// language.
        /// </summary>
        public readonly Token Token;

        /// <summary>
        /// The line number where this Lexeme originally occurred.
        /// </summary>
        public readonly int Line;

        /// <summary>
        /// The column number where this Lexeme originally occurred.
        /// </summary>
        public readonly int Column;

        /// <summary>
        /// The current text representation of this Lexeme.
        /// </summary>
        public string Contents;

    }

}
