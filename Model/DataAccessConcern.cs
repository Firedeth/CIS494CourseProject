//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html
using CIS494CourseProject.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CIS494CourseProject
{
    public partial class SQLiteDb
    {
        public void CreateConcernLevels()
        {
            using (SQLiteConnection db = new SQLiteConnection(_path))
            {
                //db.DropTable<ConcernLevelData>();
                db.CreateTable<ConcernLevelData>();

                var concernLevelData = db.Table<ConcernLevelData>();
                
                
                ConcernLevelData concernLevel = new ConcernLevelData();

                
                concernLevel.ConcernDetails = "No Reaction";
                if (concernLevelData.Where(food => food.ConcernDetails == concernLevel.ConcernDetails).FirstOrDefault() != null)
                {
                    db.Insert(concernLevel);
                }

                concernLevel.ConcernDetails = "Minor Reaction";
                if (concernLevelData.Where(food => food.ConcernDetails == concernLevel.ConcernDetails).FirstOrDefault() != null)
                {
                    db.Insert(concernLevel);
                }

                concernLevel.ConcernDetails = "Moderate Reaction";
                if (concernLevelData.Where(food => food.ConcernDetails == concernLevel.ConcernDetails).FirstOrDefault() != null)
                {
                    db.Insert(concernLevel);
                }

                concernLevel.ConcernDetails = "Major Reaction";
                if (concernLevelData.Where(food => food.ConcernDetails == concernLevel.ConcernDetails).FirstOrDefault() != null)
                {
                    db.Insert(concernLevel);
                }

                foreach (ConcernLevelData ConcernLevel in concernLevelData)
                {
                    Debug.WriteLine(ConcernLevel.ConcernID + " ->  " + ConcernLevel.ConcernDetails);
                }
                
            }
        }
    }
}