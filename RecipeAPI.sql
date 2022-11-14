-- Creates a new schema called RecipeData
CREATE SCHEMA RecipeData;
USE RecipeData;

-- Creates the tables
CREATE TABLE Recipes(
	RecipeID INT NOT NULL AUTO_iNCREMENT,
    RecipeName VARCHAR(1000) NOT NULL,
    Instructions VARCHAR(5000) NOT NULL,
    NutritionID INT,
    Primary Key (RecipeID)
);
CREATE TABLE Nutrition(
	NutritionID int not null auto_increment,
    ServingSize varchar(30),
    Calories smallint,
    TotalFat varchar(30),
    Cholesterol varchar(30),
    Sodium varchar(30),
    TotalCarbs varchar(30),
    Sugars varchar(30),
    Protein varchar(30),
    Primary Key (NutritionID)
);

-- Creates a foreign key constraint from the Recipe table to the Nutrition table
ALTER TABLE Recipes ADD CONSTRAINT FK_RecipeNutrition FOREIGN KEY (NutritionID) REFERENCES Nutrition(NutritionID);

-- Inserts Dummy data (can ignore if not necessary)
INSERT INTO Nutrition (ServingSize, Calories, TotalFat, Cholesterol, Sodium, TotalCarbs, Sugars, Protein) VALUES ("150mL", 466, "26g", "1g", "100mg", "38g", "20g", "27g");
INSERT INTO Nutrition (ServingSize, Calories, TotalFat, Cholesterol, Sodium, TotalCarbs, Sugars, Protein) VALUES ("1piece", 446, "15g", "63mg", "216mg", "74g", "46g", "4g");
INSERT INTO Nutrition (ServingSize, Calories, TotalFat, Cholesterol, Sodium, TotalCarbs, Sugars, Protein) VALUES ("3oz", 150, "5g", "0mg", "170mg", "24g", "0g", "1g");
INSERT INTO Nutrition (ServingSize, Calories, TotalFat, Cholesterol, Sodium, TotalCarbs, Sugars, Protein) VALUES ("10oz", 1481, "79.7g", "32.7mg", "1848.1mg", "174.5g", "0.2g", "27.3g");
INSERT INTO Recipes (RecipeName, Instructions, NutritionID) VALUES ("Seaweed Smoothie", "Toss the following ingredients into the blender: ", 1);
INSERT INTO Recipes (RecipeName, Instructions, NutritionID) VALUES ("Citrus Apple Pie", "Line a 9in pie plate with ", 2);
INSERT INTO Recipes (RecipeName, Instructions, NutritionID) VALUES ("Sweet Potato Fries", "Heat the oven to 400 degrees. Cut the potatoes ", 3);
INSERT INTO Recipes (RecipeName, Instructions, NutritionID) VALUES ("Jerk Chicken Apology Nachos", "Preheat oven to 425°F. Arrange tortilla chips in a slightly overlapping layer on Large Round Stone with Handles or Shallow Baker. In Classic Batter Bowl, combine chicken, cheese and 1 tbsp of the rub; mix gently. Sprinkle chicken mixture evenly over tortilla chips. Bake 5-7 minutes or until cheese is melted; remove from oven to Stackable Cooling Rack. Meanwhile, dice bell pepper with Santoku Knife. Cut lime in half crosswise. Juice half of the lime using Citrus Press into Small Batter Bowl; add bell pepper and remaining rub and mix well. Snip cilantro in mincing cup of Herb Keeper using Professional Shears. Slice remaining lime half using Ultimate Mandoline fitted with v-shaped blade; cut slices in half using Utility Knife. Spoon bell pepper mixture over nachos; sprinkle evenly with cilantro. If desired, combine sour cream and additional rub in resealable plastic bag; trim corner to allow sour cream to flow through. Pipe sour cream mixture over nachos. Garnish with lime slices.", 4);

-- Outputs the data from both newly created tables (can ignore if not necessary)
SELECT * FROM Recipes;
Select * FROM Nutrition; 