/// <summary>
/// A Token is an abstract representation of a lexical unit of the Clarion language.
/// </summary>
public class Token
{

    /// <summary>
    /// The general type of token represented.
    /// </summary>
    public readonly string Type;

    /// <summary>
    /// A pattern that matches a concrete occurance of this Token.
    /// </summary>
    public readonly string Pattern;

    /// <summary>
    /// Whether the token is a reserved word in the Clarion language.
    /// </summary>
    public readonly bool Reserved;

    /// <summary>
    /// Whether the token is a keyword in the Clarion language.
    /// </summary>
    public readonly bool Keyword;

    /// <summary>
    /// Constructs a new Token.
    /// </summary>
    /// <param name="type">A name for this type of Token.</param>
    /// <param name="pattern">A pattern that matches this Token.</param>
    /// <param name="reserved">Whether this token represents a reserved word.</param>
    /// <param name="keyword">Whether this token represents a keyword.</param>
    public Token(string type, string pattern, bool reserved, bool keyword)
    {
        Type = type;
        Pattern = pattern;
        Reserved = reserved;
        Keyword = keyword;
    }

    /// <summary>
    /// <see cref="object.ToString()"/>
    /// </summary>
    public override string ToString()
    {
        return Type;
    }

}
