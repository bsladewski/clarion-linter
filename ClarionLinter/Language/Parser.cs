using System.Collections.Generic;

namespace Language
{

    /// <summary>
    /// A ParseTree represents the resulting of parsing source code.
    /// ParseTree provides useful methods for inspecting and manipulating the ParseTree.
    /// </summary>
    public class ParseTree
    {

        /// <summary>
        /// The root node of this ParseTree.
        /// </summary>
        public ParseNode Root;

        /// <summary>
        /// Constructs a new ParseTree.
        /// </summary>
        /// <param name="root">The root node of this ParseTree.</param>
        public ParseTree(ParseNode root)
        {
            Root = root;
        }

        /// <summary>
        /// A Callback may be used to perform some operation on a ParseNode during tree traversal.
        /// </summary>
        /// <param name="node">A node that the callback will operate on.</param>
        public delegate void Callback(ParseNode node);

        /// <summary>
        /// Performs an inorder traversal of the ParseTree applying the supplied callback function
        /// to each node encountered.
        /// </summary>
        /// <param name="callback">A callback function to apply to ParseTree nodes.</param>
        public void Inorder(Callback callback)
        {
            inorder(Root, callback);
        }

        /// <summary>
        /// Recursively executes the inorder traversal.
        /// </summary>
        /// <param name="node">The node being traversed.</param>
        /// <param name="callback">The callback function to apply to the node.</param>
        private void inorder(ParseNode node, Callback callback)
        {
            foreach (ParseNode child in node.Children)
                inorder(child, callback);
            callback(node);
        }

    }

    /// <summary>
    /// A ParseNode represents a Grammar Rule within a parse tree.
    /// ParseNodes are created when a RuleDefinition is successfully matched during parsing.
    /// When adding Tokens to input, they are wrapped in a Terminal ParseNode.
    /// </summary>
    public class ParseNode
    {

        /// <summary>
        /// The Grammar Rule that this ParseNode represents.
        /// This is the abstract representation of syntax.
        /// </summary>
        public Rule Rule;

        /// <summary>
        /// A Lexeme that this ParseNode encapsulates.
        /// This will occur if the ParseNode represents a Terminal Rule.
        /// This is the concrete representation of syntax.
        /// </summary>
        public Lexeme Lexeme;

        /// <summary>
        /// Any child nodes to this ParseNode.
        /// </summary>
        public List<ParseNode> Children;

        /// <summary>
        /// Constructs a new ParseNode.
        /// </summary>
        /// <param name="rule">The Rule that this ParseNode matched.</param>
        /// <param name="lexeme">A Lexeme that this ParseNode encapsulates.</param>
        public ParseNode(Terminal rule, Lexeme lexeme)
        {
            Rule = rule;
            Lexeme = lexeme;
            Children = new List<ParseNode>();
        }

        /// <summary>
        /// Constructs a new ParseNode.
        /// </summary>
        /// <param name="rule">The Rule that this ParseNode matched.</param>
        /// <param name="children">Any child nodes to this ParseNode.</param>
        public ParseNode(Rule rule, List<ParseNode> children)
        {
            Rule = rule;
            Lexeme = null;
            Children = children;
        }

        /// <summary>
        /// See <see cref="object.ToString()"/>
        /// </summary>
        public override string ToString()
        {
            if (Rule is Terminal)
                return Lexeme.ToString();
            return string.Format("[{0}]", Rule.Name);
        }

    }

    /// <summary>
    /// A DefaultParser parses a programming language from a stream of Lexemes.
    /// </summary>
    public class DefaultParser
    {

        /// <summary>
        /// The grammar that will be used to parse input.
        /// </summary>
        private Grammar grammar;

        /// <summary>
        /// All nodes to be parsed on the next pass.
        /// </summary>
        private List<ParseNode> nextPass = new List<ParseNode>();

        /// <summary>
        /// Checks whether a ParseNode matches a Grammar Rule.
        /// </summary>
        /// <param name="node">The ParseNode to match.</param>
        /// <param name="rule">The Grammar Rule to match against.</param>
        /// <returns>Whether the element matches the Rule.</returns>
        private bool matches(ParseNode node, Rule rule)
        {
            if (node.Rule is Terminal)
            {
                if (node.Lexeme == null || !(rule is Terminal))
                    // A Terminal Rule should only be compared to another Terminal Rule
                    // We also cannot match a null Lexeme to a Terminal Rule, if this occurs in
                    // runtime the invalid ParseNode will remain in input and result in a parse error
                    return false;
                Terminal terminal = rule as Terminal;
                // Terminal Rules will either match a Token by name or type
                // If the type corresponds to one of the Token types defined by the LexicalSpec
                // schema, the matching will occur on the type of the Token
                switch (terminal.Type)
                {
                    case "token":
                        return true;
                    case "reserved":
                        return node.Lexeme.Token is ReservedWord;
                    case "symbol":
                        return node.Lexeme.Token is Symbol;
                    case "literal":
                        return node.Lexeme.Token is Literal;
                    case "identifier":
                        return node.Lexeme.Token is Identifier;
                    case "keyword":
                        return node.Lexeme.Token is Keyword;
                }
                // If the type is not set or is not part of the LexicalSpec schema, matching will
                // occur on the Token name
                return node.Lexeme.Token.Name == terminal.Name;
            }
            // If neither the ParseNode and Rule are Terminal Rules, matching simply occurs on the
            // Rule name.
            return node.Rule.Name == rule.Name;
        }

        /// <summary>
        /// Processes the next pass of parsing.
        /// </summary>
        /// <returns>Whether or not there is still input to parse.</returns>
        private bool pass()
        {
            // Create an array of ParseNodes we will process during this pass, clear the next pass
            ParseNode[] currentPass = new ParseNode[nextPass.Count];
            nextPass.CopyTo(currentPass);
            nextPass.Clear();
            // Track the number of input elements that were successfully parsed
            int parsed = 0;
            for (int i = 0; i < currentPass.Length; i++)
            {
                // Look for the shortest match starting with the ith element
                List<ParseNode> matching = new List<ParseNode>();
                bool found = false;
                for (int j = i; j < currentPass.Length; j++)
                {
                    matching.Add(currentPass[j]);
                    // Track the number of partial matches, if we don't get an exact match we may
                    // need to read more input to fill out these partial matches
                    int partialMatches = 0;
                    foreach (RuleDefinition definition in grammar.RuleDefinitions)
                    {
                        if (found)
                            // If we found an exact match we do not need to continue to look for
                            // matches
                            break;
                        // Try to match against Rules defined in the Grammar
                        foreach (Rule rule in definition.Rules ?? new Rule[0])
                        {
                            if (matching.Count != 1)
                                // A Rule can only match one input element
                                break;
                            // Attempt to match the node against the Rule
                            if (matches(matching[0], rule))
                            {
                                // If the node matches the Rule we have successfully parsed
                                // the node
                                found = true;
                                parsed++;
                                nextPass.Add(new ParseNode(new Rule(definition.Name), matching));
                                break;
                            }
                        }
                        if (found)
                            // If we found an exact match we can just exit the loop without checking
                            // whether any Sequences match
                            break;
                        // Try to match against Sequences defined in the Grammar
                        foreach (Sequence sequence in definition.Sequences ?? new Sequence[0])
                        {
                            if (matching.Count > sequence.Rules.Length)
                                // A Sequence must be greater than (partial match) or equal to
                                // (exact match) the number of nodes to match
                                continue;
                            // Attempt to match all nodes so far against the Sequence Rules
                            // Having checked zero elements against zero rules, we initialize
                            // partial match to true and set it to false if a mismatch occurs
                            bool partialMatch = true;
                            for (int k = 0; k < matching.Count; k++)
                                if (!matches(matching[k], sequence.Rules[k]))
                                {
                                    partialMatch = false;
                                    break;
                                }
                            if (partialMatch)
                                // If a partial match occurred we need to track it in case we
                                // don't get a definitive match, this will tell us whether we
                                // should continue looking for matching sequences
                                partialMatches++;
                            if (partialMatch && matching.Count == sequence.Rules.Length)
                            {
                                // If the the number of elements and the number of Rules in the
                                // sequence are equal and all elements matched the corresponding
                                // Rules we have successfully parsed the element(s)
                                found = true;
                                parsed++;
                                i = j; // advance i to the end of this subset of input
                                nextPass.Add(new ParseNode(new Rule(definition.Name), matching));
                                break;
                            }
                        }
                    }
                    // If we got an exact match or nothing matches the current run we do not need
                    // to continue looking for matches
                    if (found || partialMatches == 0)
                        break;
                }
                if (!found)
                    // If we didn't find a match add the ith node to the next pass
                    // We do this because we may be waiting on a more complex structure to be
                    // parsed before we're able to use this element in future parsing
                    nextPass.Add(currentPass[i]);
            }
            // If any input was successfully parsed we will need to make another pass
            return parsed > 0;
        }

        public ParseTree Parse(ILexer input)
        {
            // Add all Lexemes from input as Terminal Rules to the next pass
            while (input.HasNext())
            {
                Lexeme next = input.Read();
                if (next.Token is Trivia)
                    continue;
                nextPass.Add(new ParseNode(new Terminal(), next));
            }
            // Perform passes until input has been parsed
            while (pass()) ;
            // At this point the parse tree exists as elements of nextPass
            if (nextPass.Count == 1)
                // If there is only one element in nextPass, the parse was successful and the
                // element represents the root of the parse tree
                return new ParseTree(nextPass[0]);
            // If there was not one element, a parse error occurred
            // Add all elements of nextPass to a parse error node and return it as the root of
            // the parse tree
            return new ParseTree(new ParseNode(Rule.ParseError, nextPass));
        }

        /// <summary>
        /// Constructs a new DefaultParser.
        /// </summary>
        /// <param name="grammar">The Grammar used to parse input.</param>
        public DefaultParser(Grammar grammar)
        {
            this.grammar = grammar;
        }

    }

}
