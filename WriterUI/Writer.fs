module WriterUI

open System

/// <summary>
/// Configuration options for console writing operations.
/// </summary>
type WriteOptions =
    {
        /// <summary>The foreground color to use for console output. If None, defaults to White.</summary>
        CustomColor: ConsoleColor option
        /// <summary>The background color to use for console output. If None, defaults to Black.</summary>
        BackgroundColor: ConsoleColor option
        /// <summary>Whether to include a blank line before output. Defaults to true.</summary>
        IncludeLineSpace: bool
    }
 
/// <summary>
/// This is set to -1 in most circumstances so introduces a small amount of
/// undesirable global state
/// </summary>
let private initialBackground = Console.BackgroundColor

/// <summary>
/// Default configuration for write operations.
/// </summary>
let defaultOptions =
    { CustomColor = None
      BackgroundColor = Some initialBackground 
      IncludeLineSpace = true }

/// <summary>
/// Sets the console colors with fallback to defaults.
/// </summary>
/// <param name="foreColor">The foreground color to set, or None for default White.</param>
/// <param name="backColor">The background color to set, or None for default Black.</param>
// In Writer.fs
let private setColors (foreColor: ConsoleColor option) (backColor: ConsoleColor option) =
    Console.ForegroundColor <- Option.defaultValue ConsoleColor.White foreColor
    match backColor with
    | Some color -> Console.BackgroundColor <- color
    | None -> ()

/// <summary>
/// Resets console colors to defaults (White foreground, Black background).
/// </summary>
let private resetColors () =
    Console.ForegroundColor <- ConsoleColor.White
    Console.BackgroundColor <- initialBackground


/// <summary>
/// Reads a string input from the console with customizable prompt and colors.
/// </summary>
/// <param name="options">The write options to use for the input request.</param>
/// <param name="request">A request message to prompt the user with.</param>
/// <returns>The string entered by the user, or empty string if null.</returns>
let input (options: WriteOptions option) (request: string option) =
    let opts = Option.defaultValue defaultOptions options

    if opts.IncludeLineSpace then
        printfn ""
    
    if request.IsSome then
        printf $"{request.Value}"

    setColors opts.CustomColor opts.BackgroundColor
    
    let input = Console.ReadLine() |> Option.ofObj |> Option.defaultValue ""
    resetColors ()
    input

/// <summary>
/// Reads and parses a typed input from the console with error handling.
/// </summary>
/// <param name="options">The write options to use for the input request.</param>
/// <param name="request">A request message to prompt the user with</param>
/// <typeparam name="'T">The type to parse the input as. Must be a value type.</typeparam>
/// <returns>The parsed value of type 'T.</returns>
/// <exception cref="FormatException">When the input cannot be parsed as type 'T.</exception>
/// <exception cref="OverflowException">When the input value is outside the range of type 'T.</exception>
/// <remarks>Exceptions thrown in the noted categories are swallowed and a tryParse attempted recursively</remarks>
let inputTyped<'T when 'T: struct> (options: WriteOptions option) (request: string option) =
    let opts = Option.defaultValue defaultOptions options

    if opts.IncludeLineSpace then
        printfn ""
    
    if request.IsSome then
        printf $"%s{request.Value}"

    setColors opts.CustomColor opts.BackgroundColor

    let rec tryParse () =
        let input = Console.ReadLine() |> Option.ofObj |> Option.defaultValue ""

        try
            let result = Convert.ChangeType(input, typeof<'T>) :?> 'T
            resetColors ()
            result
        with
        | :? FormatException ->
            setColors (Some ConsoleColor.Red) None
            printfn "Invalid input..."
            setColors opts.CustomColor opts.BackgroundColor
            tryParse ()
        | :? OverflowException ->
            setColors (Some ConsoleColor.Red) None
            printfn "Input out of range..."
            setColors opts.CustomColor opts.BackgroundColor
            tryParse ()

    tryParse ()

/// <summary>
/// Writes a message to the console with customizable colors and spacing.
/// </summary>
/// <param name="options">The write options to use for the message.</param>
/// <param name="text">The text to write to the console.</param>
let message (options: WriteOptions option) text =
    let opts = Option.defaultValue defaultOptions options

    if opts.IncludeLineSpace then
        printfn ""

    setColors opts.CustomColor opts.BackgroundColor
    printfn $"%s{text}"
    resetColors ()

/// <summary>
/// Writes a warning message to the console in dark yellow.
/// </summary>
/// <param name="text">The warning text to display.</param>
let warn text =
    setColors (Some ConsoleColor.DarkYellow) None
    printfn ""
    printfn $"%s{text}"
    resetColors ()

/// <summary>
/// Writes an error message to the console in red.
/// </summary>
/// <param name="text">The error text to display.</param>
let error text =
    setColors (Some ConsoleColor.Red) None
    printfn ""
    printfn $"%s{text}"
    resetColors ()
