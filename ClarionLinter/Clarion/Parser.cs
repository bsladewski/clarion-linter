using Language;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Util;

namespace Clarion
{

    /// <summary>
    /// A ClarionParser parses Clarion source code.
    /// </summary>
    public class ClarionParser : DefaultParser
    {

        /// <summary>
        /// Gets the Clarion grammar.
        /// </summary>
        /// <returns>The Clarion grammar.</returns>
        public static Grammar ClarionGrammar()
        {
            string grammar = Resource.GetEmbeddedResource("Clarion/Grammar.xml");
            using (MemoryStream grammarStream = new MemoryStream(Encoding.UTF8.GetBytes(grammar)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Grammar));
                return (Grammar)serializer.Deserialize(grammarStream);
            }
        }

        /// <summary>
        /// Constructs a new Parser using the Clarion grammar.
        /// </summary>
        public ClarionParser() : base(ClarionGrammar()) { }

    }

}
