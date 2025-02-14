// Define the table
var table = Model.Tables["heart_2022_no_nans"];

// Create the Avg_Sleep_Hours measure
var avgSleepHoursMeasure = table.AddMeasure("Avg_Sleep_Hours");
avgSleepHoursMeasure.Expression = @"s
    AVERAGE('heart_2022_no_nans'[SleepHours])";
avgSleepHoursMeasure.FormatString = "0.00"; // Optional: Format to two decimal places

// Create the %Vaccinated measure
var vaccinatedMeasure = table.AddMeasure("%Vaccinated");
vaccinatedMeasure.Expression = @"
    DIVIDE(
        COUNTROWS(FILTER('heart_2022_no_nans', 'heart_2022_no_nans'[FluVaxLast12] = ""Yes"")),
        COUNTROWS('heart_2022_no_nans')
    )";
vaccinatedMeasure.FormatString = "0.00%"; // Optional: Format as percentage