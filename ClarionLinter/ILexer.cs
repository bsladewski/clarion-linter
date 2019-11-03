namespace Language
{

    /// <summary>
    /// ILexer represents a stream of Lexemes.
    /// </summary>
    public interface ILexer
    {

        /// <summary>
        /// Checks whether another Lexeme exists in the stream.
        /// </summary>
        /// <returns>Whether another Lexeme exists.</returns>
        bool HasNext();

        /// <summary>
        /// Retrieves the next Lexeme without removing it from the stream.
        /// </summary>
        /// <returns>The next Lexeme in the stream.</returns>
        /// <exception cref="System.IO.IOException"/>
        Lexeme Peek();

        /// <summary>
        /// Retrieves and removes the next Lexeme in the stream.
        /// </summary>
        /// <returns>The next Lexeme in the stream.</returns>
        /// <exception cref="System.IO.IOException"/>
        Lexeme Read();

    }

}
