//PART TWO: Soccer League Table
//The attached file football.dat contains the results from the English Premier League for 2001/2.
//The columns labeled ‘F’ and ‘A’ contain the total number of goals scored for and against each team in that season (so Arsenal scored 79 goals against opponents, and had 36 goals scored against them).
//Write a program to print the name of the team with the smallest difference in ‘for’ and ‘against’ goals.

using CommonLibrary.Helpers;


//Get Data
var data = DataHelper.GetData("football.dat");

//Parse by day and spread ( max pts, min pts, column to print)
var parsedData = data.ParseData(6, 8, 1);

var team = parsedData.GetItemByMinimumSpread();


//Print the day with the smallest temperature spread
Console.WriteLine(team.Key);
Console.ReadLine();