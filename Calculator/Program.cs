// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Transactions;

class Program {

    public static void Main(string[] args) {
        Console.WriteLine("Enter a number");

        if (!int.TryParse(Console.ReadLine(), out int num1)) {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return; 
        }


        Console.WriteLine("Enter the operation you want to do (+, -, *, or /)");

        string? operation = Console.ReadLine();

        if(string.IsNullOrEmpty(operation)) {
            Console.WriteLine("Must enter an operator");
            return;
        }


        Console.WriteLine("Enter a second number");

        if(!int.TryParse(Console.ReadLine(), out int num2)) {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }


        switch(operation) {
            case "+":
                Console.WriteLine($"{num1} + {num2} is {num1 + num2}");
                break;
            case "-":
                Console.WriteLine($"{num1} - {num2} is {num1 - num2}");
                break;
            case "*":
                Console.WriteLine($"{num1} * {num2} is {num1 * num2}");
                break;
            case "/":
                if(num2 == 0) {
                    Console.WriteLine("Cannot divide by 0");
                }
                else {
                    Console.WriteLine($"{num1} / {num2} is {num1 / num2}");
                }
                break;
            default:
                Console.WriteLine("Invalid Operation");
                break;
        }
    }
}
