// See https://aka.ms/new-console-template for more information

using WriterUI;

Writer.Message("This is a trial");
Writer.Error("And this is an error!");
Writer.Warn("I'm warning you...");

int intInput = Writer.RequestInput<int>("Please enter a number above 0");

Console.WriteLine(intInput);