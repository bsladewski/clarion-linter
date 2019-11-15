using System.Xml.Serialization;

namespace Language
{

    /// <summary>
    /// A Token is an abstract representation of a lexical unit of a programming language.
    /// </summary>
    [XmlType("token")]
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
        [XmlText]
        public string Name;

        /// <summary>
        /// A pattern that matches an occurance of this Token.
        /// </summary>
        [XmlAttribute("pattern")]
        public string Pattern;

        /// <summary>
        /// Indicates whether this token is case insensitive.
        /// </summary>
        [XmlIgnore]
        public bool? Insensitive
        {
            get { return string.IsNullOrEmpty(_insensitive) ? default(bool?) : bool.Parse(_insensitive); }
        }

        /// <summary>
        /// Used to deserialize whether a token should be matched in a case insensitive way.
        /// This additional variable is used so we can support undefined case sensitivity.
        /// </summary>
        [XmlAttribute("insensitive")]
        public string _insensitive;
        
        /// <summary>
        /// A parameterless constructor that is used when constructing Tokens through
        /// serialization.
        /// </summary>
        protected Token() { }

        /// <summary>
        /// Constructs a new Token.
        /// </summary>
        /// <param name="name">A name for this type of Token.</param>
        /// <param name="pattern">A pattern that matches this Token.</param>
        /// <param name="insensitive">Indicates whether this token is case insensitive.</param>
        public Token(string name, string pattern, bool? insensitive)
        {
            Name = name;
            Pattern = pattern;
            _insensitive = insensitive.HasValue ? insensitive.ToString() : null;
        }

        /// <summary>
        /// Constructs a new Token.
        /// </summary>
        /// <param name="name">A name for this type of Token.</param>
        /// <param name="pattern">A pattern that matches this Token.</param>
        public Token(string name, string pattern) : this(name, pattern, null) { }

        /// <summary>
        /// Constructs a new Token.
        /// </summary>
        /// <param name="name">A name for this type of Token.</param>
        public Token(string name) : this(name, null, null) { }

        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

    }

    /// <summary>
    /// A ReservedWord is a word that cannot be used as an identifier.
    /// They may have special meaning within the language or simply prevent the use of a
    /// particular identifier (for example, "goto" in the Java programming language).
    /// </summary>
    [XmlType("reserved")]
    public class ReservedWord : Token { }

    /// <summary>
    /// 
    /// </summary>
    [XmlType("symbol")]
    public class Symbol : Token { }

    /// <summary>
    /// A Literal is a notation for representing a fixed value in source code.
    /// </summary>
    [XmlType("literal")]
    public class Literal : Token { }

    /// <summary>
    /// Identifiers are user-defined labels for language entities.
    /// </summary>
    [XmlType("identifier")]
    public class Identifier : Token { }

    /// <summary>
    /// A Keyword is an identifier that has special meaning to a programming language.
    /// </summary>
    [XmlType("keyword")]
    public class Keyword : Identifier { }

    /// <summary>
    /// Trivia are tokens used only for display purposes.
    /// They have no semantic meaning and are not used in parsing.
    /// </summary>
    [XmlType("trivia")]
    public class Trivia : Token { }

}
