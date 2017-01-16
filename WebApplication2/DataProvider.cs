using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebApplication2.Models;
using System.IO;

namespace WebApplication2
{
    public class DataProvider
    {
        const string path = "d:\\DataContainer.xml";

        public IEnumerable<GoalItem> GetSavedGoalItems()
        {
            //Check that file is created
            //If not create new empty list
            if (!File.Exists(path))
            {
                return new List<GoalItem>();
            }

            //Else read XML file
            //And return List of goals
            XmlSerializer formatter = new XmlSerializer(typeof(List<GoalItem>));
            List<GoalItem> result;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                result = (List<GoalItem>)formatter.Deserialize(fs);
            }
            return result;
        }

        public void AddGoalToList(GoalItem goal)
        {
            List<GoalItem> goalsList = (List<GoalItem>)GetSavedGoalItems();
            goalsList.Add(goal);

            XmlSerializer formatter = new XmlSerializer(typeof(List<GoalItem>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, goalsList);
            }
        }
    }
}