namespace FitnessTracker;

public static class Menu {

    public static void Welcome() {
        Console.WriteLine("\nWelcome to your Fitness Tracker! Choose what to do by typing the number of the option you want:\n");
    }

    public static void DisplayMenu() {
        Console.WriteLine("1) Add a workout");
        Console.WriteLine("2) Display all workouts");
        Console.WriteLine("3) Delete a workout");
        Console.WriteLine("4) Save");
        Console.WriteLine("5) Exit\n");
    }


}