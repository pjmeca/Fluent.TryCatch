﻿namespace Fluent.TryCatch.Operators;

/// <summary>
/// Represents a <c>catch</c> block. It's the second step of <see cref="Fluent"/> <c>try...catch</c> statements.
/// </summary>
public class Catchabble : Ignorabble
{
    /// <summary>
    /// Adds a new <c>catch</c> block to the current <c>try...catch</c> statement.
    /// <br/><strong>Note:</strong> in a secuence containing multiple <c>catch</c> blocks only the first block
    /// that can handle the exception, if any, will be executed.
    /// </summary>
    /// <typeparam name="TException">The <see cref="Exception"/> type you want to catch.</typeparam>
    /// <param name="catchBlock">The code that should be executed if <typeparamref name="TException"/> is raised.</param>
    /// <returns>A <see cref="Catchabble"/> object.</returns>
    public Catchabble Catch<TException>(Action<Exception> catchBlock) where TException : Exception
    {
        _catchBlocks.Add((typeof(TException), catchBlock));

        return this;
    }

    /// <summary>
    /// Adds a new empty <c>catch</c> block to the current <c>try...catch</c> statement.
    /// <br/><strong>Note:</strong> in a secuence containing multiple <c>catch</c> blocks only the first block
    /// that can handle the exception, if any, will be executed.
    /// </summary>
    /// <typeparam name="TException">The <see cref="Exception"/> type you want to catch.</typeparam>
    /// <returns>A <see cref="Catchabble"/> object.</returns>
    public Catchabble Catch<TException>() where TException : Exception
    {
        _catchBlocks.Add((typeof(TException), e => { }));

        return this;
    }

    /// <summary>
    /// Adds a new <c>catch</c> block to the current <c>try...catch</c> statement that catches the default <see cref="Exception"/> type.
    /// <br/><strong>Note:</strong> in a secuence containing multiple <c>catch</c> blocks only the first block
    /// that can handle the exception, if any, will be executed.
    /// </summary>
    /// <param name="catchBlock">The code that should be executed if <see cref="Exception"/> is raised.</param>
    /// <returns>A <see cref="Catchabble"/> object.</returns>
    public Catchabble Catch(Action<Exception> catchBlock)
    {
        _catchBlocks.Add((typeof(Exception), catchBlock));

        return this;
    }

    /// <summary>
    /// Adds a new empty <c>catch</c> block to the current <c>try...catch</c> statement that catches the default <see cref="Exception"/> type.
    /// <br/><strong>Note:</strong> in a secuence containing multiple <c>catch</c> blocks only the first block
    /// that can handle the exception, if any, will be executed.
    /// </summary>
    /// <param name="catchBlock">The code that should be executed if <see cref="Exception"/> is raised.</param>
    /// <returns>A <see cref="Catchabble"/> object.</returns>
    public Catchabble Catch()
    {
        _catchBlocks.Add((typeof(Exception), e => { }));

        return this;
    }
}