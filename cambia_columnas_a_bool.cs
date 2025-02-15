// Define the table
var table = Model.Tables["heart_2022_no_nans"];

// List of columns to process
var columnsToProcess = new List<string> { "FluVaxLast12", "PneumoVaxEver" };

// Loop through the columns and create calculated columns
foreach (var columnName in columnsToProcess)
{
    // Get the original column
    var originalColumn = table.Columns[columnName];

    // Create a new calculated column with boolean values
    var newColumnName = columnName + "_Bool"; // New column name, e.g., FluVaxLast12_Bool
    var newColumn = table.AddCalculatedColumn(newColumnName);
    newColumn.Expression = string.Format(@"
        IF(
            'heart_2022_no_nans'[{0}] = ""Yes"", 1,
            IF(
                'heart_2022_no_nans'[{0}] = ""No"", 0,
                BLANK()
            )
        )", columnName);

    // Hide the original column
    originalColumn.IsHidden = true;
}