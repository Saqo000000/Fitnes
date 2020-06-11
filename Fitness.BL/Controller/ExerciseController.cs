using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Controller
{
    public class ExerciseController:ControllerBase
    {
        private readonly User user;
        private const string Exercises_File_Name = "exercises.dat";
        private const string Activities_File_Name = "activities.dat";
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity,DateTime begin, DateTime finish)
        {
            Activity act = Activities.SingleOrDefault((a) => a.Name == activity.Name);
            if (act==null)
            {
                Activities.Add(activity);
                Exercise exercise = new Exercise(begin, finish, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                Exercise exercise = new Exercise(begin, finish, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }
        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(Exercises_File_Name) ?? new List<Exercise>();
        }
        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(Activities_File_Name) ?? new List<Activity>();
        }
        private void Save()
        {
            Save(Exercises_File_Name, Exercises);
            Save(Activities_File_Name, Activities);
        }
    }
}
