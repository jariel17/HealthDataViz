// 1 - CREATE CALCULATED COLUMNS

var tetanusLast10Column = table.AddCalculatedColumn("TetanusLast10");
tetanusLast10Column.Expression = @"
    SWITCH(
        'heart_2022_no_nans'[TetanusLast10Tdap],
        ""Yes, received Tdap"", 1,
        ""Yes, received tetanus shot but not sure what type"", 1,
        ""Yes, received tetanus shot, but not Tdap"", 1,
        ""No, did not receive any tetanus shot in the past 10 years"", 0,
        BLANK()
    )";

// Optionally, hide the original column if needed
var originalColumn = table.Columns["TetanusLast10Tdap"];
originalColumn.IsHidden = true;

// Create the new calculated column
var smokedBoolColumn = table.AddCalculatedColumn("Smoked_Bool");
smokedBoolColumn.Expression = @"
    SWITCH(
        'heart_2022_no_nans'[SmokerStatus],
        ""Never smoked"", 0,
        ""Former smoker"", 1,
        ""Current smoker - now smokes every day"", 1,
        ""Current smoker - now smokes some days"", 1,
        BLANK()
    )";


// Create LastCheckupCategory column
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