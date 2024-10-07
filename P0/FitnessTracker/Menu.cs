namespace FitnessTracker;

public static class Menu {

    public static void Welcome() {
        Console.WriteLine("\nWelcome to your Fitness Tracker! Choose what to do by typing the number of the option you want:\n");
    }

    public static void DisplayMenu() {
        Console.WriteLine("1) Add an exercise");
        Console.WriteLine("2) Display all exercises");
        Console.WriteLine("3) Update an exercise");
        Console.WriteLine("4) Delete an exercise");
        Console.WriteLine("5) Save");
    }


}