//PART ONE: Weather Data
//In the attached weather.dat file, you’ll find daily weather data for Morristown, NJ for June 2002.
//Save this text file, then write a program to output the day number (found in column one) with the smallest temperature spread (the maximum temperature is the second column, the minimum temperature is the third column).

using CommonLibrary.Helpers;


//Get Data
var data = DataHelper.GetData("weather.dat");

//Parse data from columns ( max tmp, min temp, output)
var parsedData = data.ParseData(1, 2, 0);

//Get the day by minimum spread
var day = parsedData.GetItemByMinimumSpread();

//Print the day with the smallest temperature spread
Console.WriteLine(day.Key);
Console.ReadLine();


