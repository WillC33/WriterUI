using WriterUI;

Writer.Message("Welcome to the writer console UI helper!");

Writer.Message("It gives a simple way to create formatted text");
Writer.Message("It gets displayed with some space, and an optional colour change!", ConsoleColor.Magenta);

Writer.Error("Or we can easily show an error!");

Writer.Warn("I'm warning you...");
Writer.Warn("That the next feature might blow your mind! (Or just make life very slightly easier)");


Writer.Message("And also to capture user input in a way that doesn't interfere with your flow");
int intInput = Writer.Input<int>("Please enter an int... (and we'll make sure)");
Writer.Message($"See! it's a {intInput.GetType()}");


bool test = Writer.Input<bool>("Or try a game of 'true' or 'false'...");

Writer.Message("It works with any value type that can be captured via Console.Read()");
Writer.Message("So we can't compile nonsense like HttpClient badInput = Writer.Input<HttpClient>(\"Uh-oh! Such input would throw an exception, so best to block it with constraints to T\")");


string strInput = Writer.Input("Or you can simply grab a string without a generic");
string strInput2 = Writer.Input("With a custom colour for gussying up your console app", ConsoleColor.DarkCyan);
Writer.Message("And it will always capture an empty string (no no worrying about nulls)");

Writer.Message("And you can even ask without telling your users at all...");
string blankInput = Writer.Input();

Writer.Message("Writer helps you to focus on console business logic. No more worrying about loops and error handling for your console input!");





