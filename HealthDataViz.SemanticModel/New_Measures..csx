// Define the table
var table = Model.Tables["heart_2022_no_nans"];

// Create the %Vaccinated measure
var vaccinatedMeasure = table.AddMeasure("%Vaccinated");
vaccinatedMeasure.Expression = @"
    DIVIDE(
        COUNTROWS(FILTER('heart_2022_no_nans', 'heart_2022_no_nans'[FluVaxLast12] = ""Yes"")),
        COUNTROWS('heart_2022_no_nans')
    )";
vaccinatedMeasure.FormatString = "0.00%"; // Optional: Format as percentage

// Loop through all columns in the table
foreach (var column in table.Columns)
{
    // Check if the column name starts with "Had"
    if (column.Name.StartsWith("Had"))
    {
        // Create a measure for the percentage of "Yes" values in the column
        var measureName = "%" + column.Name; // Measure name will be %HadHeartAttack, %HadAngina, etc.
        var measure = table.AddMeasure(measureName);
        measure.Expression = string.Format(@"
            DIVIDE(
                COUNTROWS(FILTER('heart_2022_no_nans', 'heart_2022_no_nans'[{0}] = ""Yes"")),
                COUNTROWS('heart_2022_no_nans')
            )", column.Name);

                measure.FormatString = "0.00%"; // Format as percentage
            }
}