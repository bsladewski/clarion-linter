using System.Collections.Generic;

namespace Language
{

    /// <summary>
    /// IParser represents an abstract syntax tree.
    /// </summary>
    public interface IParser
    {

        // TODO: I want to be able implement IParser to create decorators that will be used to
        // apply linting rules to the abstract syntax tree.

    }

    /// <summary>
    /// A DefaultParser parses a programming language from a stream of Lexemes.
    /// </summary>
    public class DefaultParser : IParser
    {

        /// <summary>
        /// The grammar that will be used to parse input.
        /// </summary>
        private Grammar grammar;

        /// <summary>
        /// All Lexemes and Rules to be parsed on the next pass.
        /// </summary>
        private List<object> nextPass = new List<object>();

        /// <summary>
        /// Checks whether an element of input matches a Grammar Rule.
        /// </summary>
        /// <param name="element">The element to match.</param>
        /// <param name="rule">The Grammar Rule to match against.</param>
        /// <returns>Whether the element matches the Rule.</returns>
        private bool matches(object element, Rule rule)
        {
            if (element is Lexeme && rule is Terminal)
            {
                Lexeme lexeme = element as Lexeme;
                Terminal terminal = rule as Terminal;
                // Try to match the Token by type
                bool typeMatch = false;
                switch (terminal.Type)
                {
                    case "token":
                        typeMatch = true;
                        break;
                    case "reserved":
                        typeMatch = lexeme.Token is ReservedWord;
                        break;
                    case "symbol":
                        typeMatch = lexeme.Token is Symbol;
                        break;
                    case "literal":
                        typeMatch = lexeme.Token is Literal;
                        break;
                    case "identifier":
                        typeMatch = lexeme.Token is Identifier;
                        break;
                    case "keyword":
                        typeMatch = lexeme.Token is Keyword;
                        break;
                }
                // Try to match the Token by name
                if (typeMatch || lexeme.Token.Name == terminal.Name)
                    return true;
            }
            return element is Rule && (element as Rule).Name == rule.Name;
        }

        /// <summary>
        /// Processes the next pass of parsing.
        /// </summary>
        /// <returns>Whether or not there is still input to parse.</returns>
        private bool pass()
        {
            // Create an array of input we will process on this pass, clear next pass
            object[] currentPass = new object[nextPass.Count];
            nextPass.CopyTo(currentPass);
            nextPass.Clear();
            // Track the number of input elements that were successfully parsed
            int parsed = 0;
            // Begin iterating over the input
            for (int i = 0; i < currentPass.Length; i++)
            {
                // Look for the shortest match starting with the ith element
                List<object> matching = new List<object>();
                bool found = false;
                for (int j = i; j < currentPass.Length; j++)
                {
                    matching.Add(currentPass[j]);
                    // Track the number of partial matches, if we don't get an exact match we may
                    // need to read more input to fill out these partial matches
                    int partialMatches = 0;
                    foreach (RuleDefinition definition in grammar.RuleDefinitions)
                    {
                        // Try to match against rules
                        foreach (Rule rule in definition.Rules)
                        {
                            if (matching.Count != 1)
                                // A Rule can only match one input element
                                break;
                            // Attempt to match the element against the rule
                            if (matches(matching[0], rule))
                            {
                                // If the element matches the rule we have successfully parsed
                                // the element
                                found = true;
                                break;
                            }
                        }
                        // If we found an exact match we can just exit the loop
                        if (found)
                            break;
                        // Try to match against sequences
                        foreach (Sequence sequence in definition.Sequences)
                        {
                            // A Sequence must be greater than or equal to the number of elements
                            // to match
                            if (matching.Count > sequence.Rules.Length)
                                continue;
                            // Attempt to match all elements so far against the Sequence Rules
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
                                // don't get a definitive match, this will tell us if we should
                                // continue looking for matching sequences
                                partialMatches++;
                            if (partialMatch && matching.Count == sequence.Rules.Length)
                            {
                                // If the the number of elements and the number of Rules in the
                                // sequence are equal and all elements matched the corresponding
                                // Rules we have successfully parsed the element(s)
                                found = true;
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
                    // If we didn't find a match add the element to the next pass
                    // We do this because we may be waiting on a more complex structure to be
                    // parsed before we're able to use this element in future parsing
                    nextPass.Add(currentPass[i]);
            }
            // If any input was parsed we will need to make another pass
            return parsed > 0;
        }

    }

}
