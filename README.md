# Connection Pooling Demonstration in C#

This repository demonstrates the usage of Connection Pooling and explores the impact of managing connections in different scenarios using `SqlConnection` in a C# application.

## Overview

The project contains three main functions that simulate scenarios involving
1. Connection Pooling Demonstrates reusing connections across multiple requests.
2. Connection Count Without Explicit Closure Shows the behavior when connections are not explicitly closed.
3. Connection Count With Explicit Closure Highlights proper connection management by closing connections explicitly.

---

## Code Structure

### Main Program
The main program allows toggling between the three scenarios by commentinguncommenting the respective method calls.

```csharp
const string connStr = ;   Primary connection string
const string connStr2 = ;  Secondary connection string
await ConnectionCountWithCloseConn();
await ConnectionCountWithoutCloseConn();
await ConnectionPooling();
Console.ReadLine();