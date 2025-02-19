# Dashboards para dataset de datos de salud

Este repo contiene los archivos de un proyecto de visualización de datos hecho en un modelo de Power BI.

El archivo del proyecto se llama HealthDataViz.pbip.
El dataset utilizado se llama heart_2022_no_nans.csv

El modelo semántico en PowerBI fue manipulado utilizando scripts en C# con la herramienta Tabular Editor.
Fueron 3 scripts utilizados que se encuentran en la carpeta HealthDataViz.SemanticModel.
- Yes_No_Columns.csx: Cambia las columnas con valores Yes/No a booleanos (1/0).
- Simplified_Columns.csx: Simplifica algunas columnas del modelo semántico para efectos prácticos en el dashboard.
- New_Measures.csx: Agrega algunas medidas calculadas que se utilizaron en el dashboard.

La carpeta old code contiene código que no se llegó a utilizar ya sea porque no se utilizaron las columnas o porque fue mejorado en los scripts finales.