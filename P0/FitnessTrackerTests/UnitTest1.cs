using FitnessTracker;

namespace FitnessTrackerTests;

public class UnitTest1
{
    [Fact]
        public void Assert_AddDataWorks_GivenValidInput()
        {
            // Arrange
            var workoutData = new Dictionary<string, List<WorkoutEntry>>();
            var workoutEntry = new WorkoutEntry { Exercise = "Running", DurationOrReps = "30 mins" };
            string userDate = "10/10/24";

            // Act
            if (!workoutData.ContainsKey(userDate))
            {
                workoutData[userDate] = new List<WorkoutEntry>();
            }
            workoutData[userDate].Add(workoutEntry);

            // Assert
            Assert.Contains(workoutEntry, workoutData[userDate]);
        }

    [Fact]
        public void Assert_DeleteDataWorks_GivenValidInput()
        {
            // Arrange
            var workoutData = new Dictionary<string, List<WorkoutEntry>>();
            var workoutEntry = new WorkoutEntry { Exercise = "Cycling", DurationOrReps = "20 mins" };
            string userDate = "10/10/24";
            workoutData[userDate] = new List<WorkoutEntry> { workoutEntry };

            // Act
            workoutData[userDate].Remove(workoutEntry);

            // Assert
            Assert.DoesNotContain(workoutEntry, workoutData[userDate]);

        }
}