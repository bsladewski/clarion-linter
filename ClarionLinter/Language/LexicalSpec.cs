using System.Xml.Serialization;

namespace Language
{

    /// <summary>
    /// The LexicalSpec is used to deserialize information needed at runtime to tokenize a
    /// programming language.
    /// </summary>
    [XmlRoot("lexical")]
    public class LexicalSpec
    {

        /// <summary>
        /// Whether Tokens in general should be matched in a case insensitive way.
        /// </summary>
        [XmlAttribute("insensitive")]
        public bool Insensitive;

        /// <summary>
        /// A list of Tokens defined by the lexical specification.
        /// </summary>
        [XmlElement("token", Type = typeof(Token))]
        [XmlElement("reserved", Type = typeof(ReservedWord))]
        [XmlElement("symbol", Type = typeof(Symbol))]
        [XmlElement("literal", Type = typeof(Literal))]
        [XmlElement("identifier", Type = typeof(Identifier))]
        [XmlElement("keyword", Type = typeof(Keyword))]
        [XmlElement("trivia", Type = typeof(Trivia))]
        public Token[] Tokens;

    }

}
