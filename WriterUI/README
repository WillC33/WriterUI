# WriterUI - Console UI Helper

Welcome to WriterUI, your go-to library for simplifying console-based user interactions and message formatting.

## Description

WriterUI provides a set of convenient methods for interacting with the console, allowing you to display formatted messages, capture user input, and customize the console output to match your application's style.

## Features

### 1. Formatted Messages
Easily display formatted messages on the console with customizable colors.

```csharp
Writer.Message("Welcome to the writer console UI helper!");
Writer.Error("Oops! Something went wrong.");
Writer.Warn("Warning: Proceed with caution."); 
```

### 2. Input Capture
Capture user input from the console, ensuring seamless integration into your application flow.

```csharp
int intInput = Writer.Input<int>("Please enter an integer:");
bool boolInput = Writer.Input<bool>("Enter 'true' or 'false':");
string strInput = Writer.Input("Enter a string:");
```


### 3. Customisation
Customise message colors and prompts to match your application's style.

```csharp
Writer.Message("This message is in magenta color!", ConsoleColor.Magenta);
string customColorInput = Writer.Input("Enter a string:", ConsoleColor.DarkCyan);
```

### 4. Type Safety
Ensure type safety when capturing user input, preventing invalid inputs and runtime errors.

```csharp
// No compilation for impossible tasks!
HttpClient badInput = Writer.Input<HttpClient>("Invalid input!");
```
## Usage
### Installation:

Add the WriterUI library to your project through NuGet Package Manager or by downloading and referencing the assembly.
### Usage:

Import the WriterUI namespace into your code file.
Use the provided methods (Message, Error, Warn, Input) to interact with the console.
```csharp
using WriterUI;

Writer.Message("Welcome to my application!");
int age = Writer.Input<int>("Please enter your age:");
```

### Customisation:
Experiment with different message colors and input prompts to enhance user experience.
```csharp
Writer.Message("This is a custom message.", ConsoleColor.Green);
string userInput = Writer.Input("Enter a value:", ConsoleColor.Yellow);
```

### Considerations
- Error Handling: Writer will continue asking for input until a value can be converted when using Input\<T\>() but you might still need your own in some cases.
- Input Validation: Always validate user input to prevent unexpected behavior or security vulnerabilities.
- Thread Safety: Use synchronization mechanisms if accessing WriterUI methods concurrently from multiple threads.

## Contributions
Contributions to the WriterUI library are welcome! If you encounter any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request on GitHub.

## License
This library is licensed under the MIT License. See the LICENSE file for details.
