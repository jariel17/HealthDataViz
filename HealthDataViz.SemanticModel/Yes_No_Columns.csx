// Define the table
var table = Model.Tables["heart_2022_no_nans"];

// 1 - MODIFY SPECIFIC COLUMNS FROM YES/NO TO BOOL

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

// 2 - MODIFY ALL HAD YES/NO COLUMNS TO BOOL

foreach (var table in Model.Tables)
{
    // Loop through all columns in the table
    foreach (var column in table.Columns.ToList())
    {
        // Check if column name starts with "Had"
        if (column.Name.StartsWith("Had"))
        {
            // Add a new calculated column
            var newColumn = table.AddCalculatedColumn(
                column.Name + "_Bool",  // New column name
                // DAX formula to convert Yes/No to 1/0, defaulting to 0 for invalid values
                "IF(UPPER(" + column.DaxObjectFullName + ") = \"YES\", 1, IF(UPPER(" + column.DaxObjectFullName + ") = \"NO\", 0, BLANK()))"
            );
            
            // Optional: Hide the original column
            column.IsHidden = true;
            
            // Optional: Set format to integer
            newColumn.FormatString = "0";
        }
    }
}
