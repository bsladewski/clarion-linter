using System;
using System.Xml.Serialization;

namespace Language
{

    /// <summary>
    /// A Token is an abstract representation of a lexical unit of a programming language.
    /// </summary>
    [Serializable]
    public class Token
    {

        /// <summary>
        /// The end-of-line Token.
        /// </summary>
        public static readonly Token EOL = new Token("EOL");

        /// <summary>
        /// The end-of-file Token.
        /// </summary>
        public static readonly Token EOF = new Token("EOF");

        /// <summary>
        /// A Token that indicates no other valid Token could be parsed from input.
        /// </summary>
        public static readonly Token ParseError = new Token("Parse Error");

        /// <summary>
        /// A display name for this Token.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;

        /// <summary>
        /// A pattern that matches an occurance of this Token.
        /// </summary>
        [XmlAttribute("pattern")]
        public string Pattern;

        /// <summary>
        /// Whether the token is a reserved word. Reserved words cannot be shadowed by identifiers.
        /// </summary>
        [XmlAttribute("reserved")]
        public bool Reserved;

        /// <summary>
        /// Whether the token is a keyword. Keywords may be shadowed by identifiers.
        /// </summary>
        [XmlAttribute("keyword")]
        public bool Keyword;

        /// <summary>
        /// Whether the token should be omitted from the abstract syntax tree.
        /// </summary>
        [XmlAttribute("trivia")]
        public bool Trivia;

        /// <summary>
        /// A parameterless constructor that is used when constructing Tokens through
        /// serialization.
        /// </summary>
        private Token() { }

        /// <summary>
        /// Constructs a new Token.
        /// </summary>
        /// <param name="name">A name for this type of Token.</param>
        /// <param name="pattern">A pattern that matches this Token.</param>
        /// <param name="reserved">Whether this token represents a reserved word.</param>
        /// <param name="keyword">Whether this token represents a keyword.</param>
        public Token(string name, string pattern, bool reserved, bool keyword, bool trivia)
        {
            Name = name;
            Pattern = pattern;
            Reserved = reserved;
            Keyword = keyword;
            Trivia = trivia;
        }

        /// <summary>
        /// Constructs a new Token.
        /// </summary>
        /// <param name="name">A name for this type of Token.</param>
        public Token(string name) : this(name, null, false, false, false) { }

        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

    }

}
