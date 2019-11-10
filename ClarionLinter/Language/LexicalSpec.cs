using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Language
{

    /// <summary>
    /// The LexicalSpec is used to deserialize information needed at runtime to tokenize
    /// a programming language.
    /// </summary>
    [Serializable, XmlRoot("lexical")]
    public class LexicalSpec
    {

        /// <summary>
        /// A list of Tokens defined by the lexical specification.
        /// </summary>
        [XmlArray("tokens")]
        [XmlArrayItem("token")]
        public List<Token> Tokens;

    }

}
