using System.Xml.Serialization;

namespace Language
{

    /// <summary>
    /// A Grammar is used to deserialize information needed at runtime to parse a programming
    /// language.
    /// </summary>
    [XmlRoot("grammar")]
    public class Grammar
    {

        /// <summary>
        /// A list of RuleDefinitions specified by the grammar.
        /// </summary>
        [XmlElement("ruleDefinition", Type = typeof(RuleDefinition))]
        public RuleDefinition[] RuleDefinitions;

    }

    /// <summary>
    /// A RuleDefinition defines abstract syntax made up of Rules and Sequences.
    /// </summary>
    [XmlType("ruleDefinition")]
    public class RuleDefinition
    {

        /// <summary>
        /// A display name for this RuleDefinition.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;

        /// <summary>
        /// Rules reference the RuleDefinitions and Terminal tokens that make up the syntax of
        /// this RuleDefinition. Each Rule is treated as a different option. That is, if the Rules
        /// are defined as [foo, bar, baz], this RuleDefinition will match any single occurance of
        /// foo, bar, or baz.
        /// </summary>
        [XmlElement("rule", typeof(Rule))]
        [XmlElement("terminal", typeof(Terminal))]
        public Rule[] Rules;

        /// <summary>
        /// Sequences indicate that this RuleDefinition may match a number of Rules in a specific
        /// order. Like Rules, Sequences are treated as different options. The contents of a
        /// Sequence, however, must all occur in the order they are specified. For example, a
        /// sequence defined by [foo, bar, baz] will match an occurance of foo followed by an
        /// occurance of bar followed by an occurance of baz.
        /// </summary>
        [XmlElement("sequence", typeof(Sequence))]
        public Sequence[] Sequences;

    }

    /// <summary>
    /// A Sequence is similar to a RuleDefinition in that it stores a list of rules. The Sequence,
    /// however, indicates that all rules must occur in the order they were specified.
    /// </summary>
    [XmlType("sequence")]
    public class Sequence : RuleDefinition { }

    /// <summary>
    /// Rules are matched during parsing to define abstract syntax.
    /// </summary>
    [XmlType("rule")]
    public class Rule
    {

        /// <summary>
        /// A Rule that indicates parsing resulted in multiple root results.
        /// </summary>
        public static readonly Rule ParseError = new Rule("Parse Error");

        /// <summary>
        /// A display name for this Rule.
        /// This value is also used to relate the Rule to its definition by name. For example, a
        /// Rule will use the Name field to determine if this Rule matches a given RuleDefinition
        /// or a Terminal will use the Name field to determine if this Rule matches a given Token.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;

        /// <summary>
        /// A parameterless constructor that is used when constructing Rules through serialization.
        /// </summary>
        protected Rule() { }

        /// <summary>
        /// Constructs a new Rule.
        /// </summary>
        /// <param name="name">A name for this Rule.</param>
        public Rule(string name)
        {
            Name = name;
        }

    }

    /// <summary>
    /// A Terminal Rule matches a Token. Terminal Rules cannot be expanded further and thus
    /// represent a leaf node in the abstract syntax tree.
    /// </summary>
    [XmlType("terminal")]
    public class Terminal : Rule
    {

        /// <summary>
        /// A type of Token matched by this Terminal Rule. For example, a type of literal will
        /// match any Tokens that are an instance of the Literal Token type.
        /// </summary>
        [XmlAttribute("type")]
        public string Type;

    }

}
