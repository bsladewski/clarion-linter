using Language;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Util;

namespace Clarion
{

    /// <summary>
    /// A ClarionLexer tokenizes Clarion source code.
    /// </summary>
    public class ClarionLexer : DefaultLexer
    {

        /// <summary>
        /// Gets the Clarion lexical specification.
        /// </summary>
        public static LexicalSpec ClarionLexicalSpec()
        {
            string spec = Resource.GetEmbeddedResource("Clarion/LexicalSpec.xml");
            using (MemoryStream specStream = new MemoryStream(Encoding.UTF8.GetBytes(spec)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LexicalSpec));
                return (LexicalSpec)serializer.Deserialize(specStream);
            }
        }

        /// <summary>
        /// Constructs a new Lexer using the Clarion lexical specification.
        /// </summary>
        /// <param name="input"></param>
        public ClarionLexer(StreamReader input) : base(ClarionLexicalSpec(), input) { }

    }

}
