namespace WriterUI;

/// <summary>
/// Static class for calling writer methods on the console IO
/// </summary>
public static class Writer
{

    
    /// <summary>
    /// Captures string input against an optional request that is written to the console
    /// </summary>
    /// <param name="request">the question to ask</param>
    /// <param name="customColour">An optional custom colour</param>
    /// <returns></returns>
    public static string Input(string? request = null, ConsoleColor? customColour = null)
    {
        Console.ForegroundColor = customColour ?? ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine(request);
        
        var input = Console.ReadLine() ?? string.Empty;
        Console.ForegroundColor = ConsoleColor.White;
        return input;

    }


    /// <summary>
    /// Asks for input against a certain question or blank and returns the following input of type T which must be a value type
    /// </summary>
    /// <param name="request">the question</param>
    /// <param name="customColour">An optional custom colour for valid input</param>
    /// <returns>response string cast to T</returns>
    public static T Input<T>(string? request = null, ConsoleColor?  customColour = null) where T : struct
    {
        Console.ForegroundColor = customColour ?? ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine(request);
        while (true)
        {
            var input = Console.ReadLine() ?? string.Empty;
            try
            {
                T result = (T)Convert.ChangeType(input, typeof(T));
                Console.ForegroundColor = ConsoleColor.White;
                return result;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input...");
                Console.ForegroundColor = customColour ?? ConsoleColor.Cyan;
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input out of range...");
                Console.ForegroundColor = customColour ?? ConsoleColor.Cyan;
            }
        }
    }


    /// <summary>
    /// Updates the user with formatted messages
    /// </summary>
    /// <param name="message">the message to display</param>
    /// <param name="customColour">An optional custom colour for the message</param>
    public static void Message(string message, ConsoleColor?  customColour = null)
    {
        Console.ForegroundColor = customColour ?? ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine(message);
    }
    
    
    /// <summary>
    /// Updates the user with formatted warning messages
    /// </summary>
    /// <param name="message">the message to display</param>
    public static void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine();
        Console.WriteLine(message);
    }
    
    
    /// <summary>
    /// Updates the user with formatted error messages
    /// </summary>
    /// <param name="message">the message to display</param>
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine(message);
    }
}