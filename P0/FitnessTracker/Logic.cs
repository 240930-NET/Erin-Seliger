
using FitnessTracker;
using System.Text.Json;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;


public static class Logic {

    public static Dictionary<string, List<WorkoutEntry>> readData() {
        if (File.Exists("Workouts.json")) {
            using(StreamReader sr = new StreamReader("Workouts.json")) {
                string jsonContent = sr.ReadToEnd();
                if (string.IsNullOrWhiteSpace(jsonContent)) {
                    Console.WriteLine("\nFile is empty\n");
                    return new Dictionary<string, List<WorkoutEntry>>();
                }
                else {
                    return JsonSerializer.Deserialize<Dictionary<string, List<WorkoutEntry>>>(jsonContent) ?? new Dictionary<string, List<WorkoutEntry>>();
                }
            }
        }
        Console.WriteLine("\nFile does not exist\n");
        return new Dictionary<string, List<WorkoutEntry>>();
    }

    public static void addData(Dictionary<string, List<WorkoutEntry>> workoutData) {
        string userDate = "";
        string pattern = "";
        do {
        Console.WriteLine("\nEnter the date you want to add an entry for (in MM/DD/YY format)\n");
        userDate = Console.ReadLine() ?? "";
        pattern = @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{2}$";
        if (!Regex.IsMatch(userDate, pattern)) {
            Console.WriteLine("\nInvalid format. Please use MM/DD/YY\n");
        }
        } while (!Regex.IsMatch(userDate, pattern));

        string exercise = "";
        do {
            Console.WriteLine("\nEnter the exercise\n");
            exercise = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(exercise)) {
                Console.WriteLine("exercise cannot be empty\n");
            }
        } while(string.IsNullOrEmpty(exercise));

        string durationOrReps = "";
        do {
            Console.WriteLine("\nEnter duration of/number of reps for exercise\n");
            durationOrReps = Console.ReadLine() ?? "";
            if(string.IsNullOrEmpty(durationOrReps)) {
                Console.WriteLine("durationOrReps cannot be empty\n");
            }
        } while(string.IsNullOrEmpty(durationOrReps));

        WorkoutEntry workoutEntry = new WorkoutEntry(){Exercise = exercise, DurationOrReps = durationOrReps};

        if(workoutData.ContainsKey(userDate)) {
            workoutData[userDate].Add(workoutEntry);
        }
        else {
            workoutData[userDate] = new List<WorkoutEntry>() {workoutEntry};
        }

        Console.WriteLine("\nEntry added\n");
    }


    public static void deleteData(Dictionary<string, List<WorkoutEntry>> workoutData) {
        if (workoutData.Count == 0) {
            Console.WriteLine("\nNo entries to delete\n");
            return;
        }
        do {
            Console.WriteLine("\nEnter 'date' to delete an entire day of entries or 'workout' to only delete a specific entry from a day\n");
            string? userChoice = Console.ReadLine();
            if(userChoice == "date") {
                Console.WriteLine("\nWhich date would you like to delete?\n");
                string deleteDate = Console.ReadLine() ?? "";
                if (workoutData.Remove(deleteDate)) {
                    Console.WriteLine("\nEntry deleted\n");
                }
                else {
                    Console.WriteLine("\nThere's no entry with that date\n");
                    return;
                }
                break;
            }
            else if(userChoice == "workout") {
                Console.WriteLine("\nFrom which day would you like to delete a workout?\n");
                string selectedDate = Console.ReadLine() ?? "";

                if (workoutData.ContainsKey(selectedDate)) {
                    Console.WriteLine("\nWhich exercise would you like to delete?\n");
                    string? deleteExercise = Console.ReadLine();
                    WorkoutEntry foundWorkout = workoutData[selectedDate].Find(w => w.Exercise == deleteExercise) ?? new WorkoutEntry();
                    if (workoutData[selectedDate].Remove(foundWorkout)) {
                        Console.WriteLine("\nentry deleted\n");
                    }
                    else {
                        Console.WriteLine("\nThere's no entry with that exercise\n");
                        return;
                    }
                }
                else {
                    Console.WriteLine("\nThere's no entry with that date\n");
                    return;
                }
                break;
            }
            else {
                Console.WriteLine("\nInvalid input: write either 'date' or 'workout'\n");
            }
        }
        while (true);
    }


}