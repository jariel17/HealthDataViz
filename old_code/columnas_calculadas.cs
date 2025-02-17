// Define the table
var table = Model.Tables["heart_2022_no_nans"];

// Create the BMI_Category calculated column
var bmiCategoryColumn = table.AddCalculatedColumn("BMI_Category");
bmiCategoryColumn.Expression = @"
    SWITCH(
        TRUE(),
        'heart_2022_no_nans'[BMI] < 18.5, ""Bajo Peso"",
        'heart_2022_no_nans'[BMI] >= 18.5 && 'heart_2022_no_nans'[BMI] < 25, ""Normal"",
        'heart_2022_no_nans'[BMI] >= 25 && 'heart_2022_no_nans'[BMI] < 30, ""Sobrepeso"",
        'heart_2022_no_nans'[BMI] >= 30, ""Obesidad""
    )";

// Create the Health_Risk calculated column
var healthRiskColumn = table.AddCalculatedColumn("Health_Risk");
healthRiskColumn.Expression = @"
    IF(
        'heart_2022_no_nans'[HadHeartAttack] = ""Yes"" || 
        'heart_2022_no_nans'[HadStroke] = ""Yes"" || 
        'heart_2022_no_nans'[HadDiabetes] = ""Yes"" || 
        'heart_2022_no_nans'[HadCOPD] = ""Yes"", ""Alto Riesgo"", ""Bajo Riesgo""
    )";

// Create the Active_Status calculated column
var activeStatusColumn = table.AddCalculatedColumn("Active_Status");
activeStatusColumn.Expression = @"
    IF('heart_2022_no_nans'[PhysicalActivities] = ""Yes"", ""Activo"", ""Sedentario"")";