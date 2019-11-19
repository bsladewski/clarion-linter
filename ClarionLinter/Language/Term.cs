using System.Xml.Serialization;

namespace Language
{

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("termDef")]
    public class TermDef
    {

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("term", typeof(Term))]
        [XmlElement("terminal", typeof(Token))]
        public Term[] terms;

        [XmlElement("sequence")]
        public TermDef[] sequences;

    }

    /// <summary>
    /// 
    /// </summary>
    public class Term
    {

        /// <summary>
        /// 
        /// </summary>
        public string Name;

    }

    /// <summary>
    /// 
    /// </summary>
    public class Terminal : Term
    {

    }

}
