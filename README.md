# WriterUI - Console UI Helper

Welcome to WriterUI, your go-to library for simplifying console-based user interactions and message formatting.

## Description

WriterUI provides a set of functional methods for interacting with the console, allowing you to display formatted messages, capture user input, and customize the console output. Written in F# to leverage functional programming patterns and pipeline operations.

## Features

### 1. Formatted Messages
Display formatted messages with optional colors and spacing.

```fsharp
message None "Welcome to the writer console UI helper!"
error "Oops! Something went wrong."
warn "Warning: Proceed with caution."
```

### 2. Input Capture
Type-safe input capture with built-in error handling.

```fsharp
let intInput = inputTyped<int> None (Some "Please enter an integer:")
let boolInput = inputTyped<bool> None (Some "Enter 'true' or 'false':")
let strInput = input None (Some "Enter a string:")
```

### 3. Customisation
Customise colors and formatting using the WriteOptions record:
   
```fsharp
message (Some { 
    CustomColor = Some ConsoleColor.Magenta
    BackgroundColor = Some ConsoleColor.Black
    IncludeLineSpace = true 
}) "Customized message!"

let customInput = input 
    (Some { 
        CustomColor = Some ConsoleColor.DarkCyan
        BackgroundColor = None
        IncludeLineSpace = true 
    }) 
    (Some "Enter with style:")
```

## Usage
### Installation
Add the WriterUI library through NuGet Package Manager.

### Basic Usage
```fsharp
open WriterUI

message None "Welcome to my application!"
let age = inputTyped<int> None (Some "Please enter your age:")
```

## Why F#?
The library has been rewritten in F# to:  
 - Better support functional programming patterns
 - Enable pipeline operations with consistent parameter ordering
 - Provide cleaner option handling
 - Leverage F#'s type inference and pattern matching
 - Simplify error handling 

## Type Safety
The library provides type-safe input handling using F#'s generic constraints:

```fsharp
let age = inputTyped<int> None (Some "Enter age:")  // Works
let request = inputTyped<HttpClient> None (Some "Stringify an HttpClient?") // No way!
let name = input None (Some "Enter name:")          // String input
```

## Considerations
 - Error handling is built into inputTyped<'T> with recursive retry
 - All functions handle None cases gracefully
 - Background colors automatically reset to terminal defaults
 - Thread-safe console operations

## License
MIT License. See the LICENSE file for details.

## v2.0.0 Key changes:
- Updated syntax to show F# examples
- Removed C# examples and namespace references
- Added explanation for F# migration
- Simplified API examples
- Updated configuration examples to use F# record syntax
- Added note about background color handling
