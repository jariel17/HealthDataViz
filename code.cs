// Loop through all tables in the model
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