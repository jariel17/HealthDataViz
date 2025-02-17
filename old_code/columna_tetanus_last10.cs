// Define the table
var table = Model.Tables["heart_2022_no_nans"];

// Create the new calculated column
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