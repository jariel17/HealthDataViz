// Define the table
var table = Model.Tables["heart_2022_no_nans"];

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