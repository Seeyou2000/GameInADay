@echo off

set "inputDirectory=Design\Tables"
set "outputDirectory=%PlumPuzzle\Assets\Resources\CSVs"
set "outputClassDirectory=%PlumPuzzle\Assets\02.Scripts\Model"
set "converter=%ExcelToCsvConverter.vbs"
set "converter2=%ConvertCSVToCSClass.exe"

if not exist "%outputDirectory%" mkdir "%outputDirectory%"

del /s /q "%outputDirectory%\*.*"

for %%F in ("%inputDirectory%\*.xlsx") do (
    cscript "%converter%" "%cd%\%%F" "%cd%\%outputDirectory%\%%~nF.csv"
)

echo CSV files created successfully!

%converter2% %outputDirectory% %outputClassDirectory%

pause