// Define the table
var table = Model.Tables["heart_2022_no_nans"];

// Create the new calculated column
var lastCheckupCategoryColumn = table.AddCalculatedColumn("LastCheckupCategory");
lastCheckupCategoryColumn.Expression = @"
    SWITCH(
        'heart_2022_no_nans'[LastCheckupTime],
        ""Within past year (anytime less than 12 months ago)"", ""Less than a year"",
        ""5 or more years ago"", ""More than a year"",
        ""Within past 2 years (1 year but less than 2 years ago)"", ""More than a year"",
        ""Within past 5 years (2 years but less than 5 years ago)"", ""More than a year"",
        BLANK()
    )";