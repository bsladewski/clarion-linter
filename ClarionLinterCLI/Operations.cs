﻿using Language;
using System;

partial class ClarionLinterCLI
{

    /// <summary>
    /// A callback function that prints a ParseNode to standard out.
    /// </summary>
    /// <param name="node">The ParseNode to print.</param>
    private static void printParseNode(ParseNode node)
    {
        Console.Write(node);
    }

    /// <summary>
    /// Prints a ParseTree to standard out.
    /// </summary>
    /// <param name="tree">The ParseTree to print.</param>
    public static void PrintParseTree(ParseTree tree)
    {
        tree.Inorder(printParseNode);
    }

}