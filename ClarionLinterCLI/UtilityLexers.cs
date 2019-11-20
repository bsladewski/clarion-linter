using Language;
using System;

/// <summary>
/// A PrintLexer is an implementation of ILexer that prints the lexeme on each read.
/// </summary>
class PrintLexer : ILexer
{

    /// <summary>
    /// The lexer that this PrintLexer decorates.
    /// </summary>
    private ILexer lexer;

    /// <summary>
    /// See <see cref="Language.ILexer.HasNext()"/>
    /// </summary>
    public bool HasNext()
    {
        return lexer.HasNext();
    }

    /// <summary>
    /// See <see cref="Language.ILexer.Peek()"/>
    /// </summary>
    public Lexeme Peek()
    {
        return lexer.Peek();
    }

    /// <summary>
    /// See <see cref="Language.ILexer.Read()"/>
    /// </summary>
    public Lexeme Read()
    {
        Lexeme lexeme = lexer.Read();
        if (lexeme.Token is Trivia)
            return lexeme;
        Console.Write(lexeme);
        if (lexeme.Token.Equals(Token.EOL))
            Console.WriteLine();
        return lexeme;
    }

    /// <summary>
    /// Constructs a new PrintLexer.
    /// </summary>
    /// <param name="lexer">The lexeme to decorate with the PrintLexer.</param>
    public PrintLexer(ILexer lexer)
    {
        this.lexer = lexer;
    }

}
