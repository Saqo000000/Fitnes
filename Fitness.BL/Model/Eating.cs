using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Model
{

    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }

        public User User { get; }

        public Dictionary<Food,double> Foods { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty",nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food ,double weight)
        {
            //var eee= 

           // Foods.Keys.FirstOrDefault((f)=>f.Name==food.Name)
            Food product = Foods.Keys.FirstOrDefault((f) => f.Name == food.Name);
            if (product==null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
