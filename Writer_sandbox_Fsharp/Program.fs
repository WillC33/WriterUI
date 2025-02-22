open System
open WriterUI

// Basic message examples
message None "Welcome to the writer console UI helper!"

message None "It gives a simple way to create formatted text"
message (Some { 
    CustomColor = Some ConsoleColor.Magenta
    BackgroundColor = Some ConsoleColor.DarkBlue 
    IncludeLineSpace = true 
}) "It gets displayed with some space, and an optional colour change!"

error "Or we can easily show an error!"

warn "I'm warning you..."
warn "That the next feature might blow your mind! (Or just make life very slightly easier)"

// Input capture examples
message None "And also to capture user input in a way that doesn't interfere with your flow"
let intInput = 
    inputTyped<int> None (Some "Please enter an int... (and we'll make sure)")
message None  $"See! it's a {intInput.GetType()}"


let test = 
    inputTyped<bool> None (Some "Or try a game of 'true' or 'false'...")

// String input examples
let strInput = 
    input None (Some "Or you can simply grab a string without a generic")

let strInput2 = 
    input None (Some "With a custom colour for gussying up your console app" )

message None "And it will always capture an empty string (no worrying about nulls)"
message None "And you can even ask without telling your users at all..."
let blankInput = input None

message None "Writer helps you to focus on console business logic. No more worrying about loops and error handling for your console input!"