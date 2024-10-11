using System.Text.Json;

namespace FitnessTracker;

class Program
{
    static void Main(string[] args)
    {
        Menu.Welcome();
        
        Dictionary<string, List<WorkoutEntry>> workoutData = new Dictionary<string, List<WorkoutEntry>>();


        string userSelection = "";
        while(userSelection != "5") {
            Menu.DisplayMenu();

            userSelection = Console.ReadLine() ?? "";

            switch(userSelection) {
                case "1": 
                    Logic.addData(workoutData);
                    break;
                    
                case "2":
                    workoutData = Logic.readData();

                    if(workoutData.Count == 0) {
                        continue;
                    }

                    foreach (var entry in workoutData) {
                        Console.WriteLine($"\nDate: {entry.Key}");
                        foreach (WorkoutEntry workout in entry.Value) {
                            Console.WriteLine($"  - Exercise: {workout.Exercise}, Duration/Reps: {workout.DurationOrReps}\n");
                        }
                    }
                    break;

                case "3":
                    Logic.deleteData(workoutData);
                    break;

                case "4":
                    string jsonString = JsonSerializer.Serialize(workoutData);
                    using(StreamWriter sw = new StreamWriter("Workouts.json")) {
                        sw.WriteLine(jsonString);
                    }
                    Console.WriteLine("\nSaving to file\n");
                    break;

                case "5":
                    break;
                
                default:
                    Console.WriteLine("Invalid input, please enter a number from 1 to 5");
                    break;
            }
        }


    }
}
