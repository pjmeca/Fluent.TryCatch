# 💧 Fluent.TryCatch

[![GitHub Repo stars](https://img.shields.io/github/stars/pjmeca/Fluent.TryCatch?style=flat&logo=github&label=Star%20this%20repo!)](https://github.com/pjmeca/Fluent.TryCatch)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Fluent.TryCatch?logo=nuget&label=Get%20it%20on%20NuGet)](https://www.nuget.org/packages/Fluent.TryCatch)
[![GitHub License](https://img.shields.io/github/license/pjmeca/Fluent.TryCatch?label=License)](https://opensource.org/licenses/MIT)



## Table of Contents

- [About](#about)
- [Why?](#why)
- [Features](#features)
- [Examples](#examples)
  - [Simple try...catch statement](#example1)
  - [Multiple try...catch statements with a when clause](#example2)
  - [The ignore operator with a finally block](#example3)
  - [Returning values](#example4)

## About

**Fluent.TryCatch** is a lightweight library that adds support for fluent `try...catch` statements to .Net. It incorporates all the funtionality of the standard `try...catch` statement, but with a more fluent syntax.

## Why?

Simplicity. Sometimes the standard `try...catch` statement can be verbose and difficult to read, especially for small segments of code. The fluent syntax offered by this library makes it easier to write and understand.

## Features

- One `try` clause
- Zero to multiple `catch` blocks
- Optionally, a `when` clause for each `catch` block
- A special `ignore` operator that discards non controlled exceptions
- Zero to one `finally` block
- Returning values

## Examples

### A simple `try...catch` statement <a id="example1"></a>

```csharp
Fluent.Try(() =>
        // Your code here
    ).Catch(e =>
        // Handle Exception
    ).Execute();
```

Translates to:

```csharp
try
{
    // Your code here
}
catch (Exception e)
{
    // Handle Exception
}
```

### Multiple `try...catch` statements with a `when` clause <a id="example2"></a>

```csharp
Fluent.Try(() => 
        // Your code here
    ).Catch<ArgumentOutOfRangeException>(e => 
        // Handle ArgumentOutOfRangeException
    ).Catch(e => 
        // Handle OutOfMemoryException or ArgumentNullException
    ).When(e => e is OutOfMemoryException || e is ArgumentNullException)
    .Catch(e => 
        // Handle Exception
    )
    .Execute();
```

Translates to:

```csharp
try
{
    // Your code here
}
catch (ArgumentOutOfRangeException e)
{
    // Handle ArgumentOutOfRangeException
}
catch (Exception e) when (e is OutOfMemoryException || e is ArgumentNullException)
{
    // Handle OutOfMemoryException or ArgumentNullException
}
catch (Exception e)
{
    // Handle Exception
}
```

### The `ignore` operator with a `finally` block <a id="example3"></a>

```csharp
Fluent.Try(() => 
        // Your code here
    ).Ignore()
    .Finally(() =>
        // Your code here
    )
    .Execute();
```

Translates to:

```csharp
try
{
    // Your code here
}
catch (Exception e)
{
    // Empty catch
}
finally
{
    // Your code here
}
```

### Returning values <a id="example4"></a>

```csharp
int result = Fluent.Try(() => 
        return 1;
    ).Catch<ArgumentNullException>(e =>
        return 2;
    ).Catch(e =>
        // No return value -> default value is returned
    ).Execute<int>();
```

Translates to:

```csharp
int result;
try
{
    result = 1;
}
catch (ArgumentNullException e)
{
    result = 2;
}
catch (Exception e)
{
    result = default; // 0
}
```

**Note:** If a block does not return a value, the default value will be automatically returned.