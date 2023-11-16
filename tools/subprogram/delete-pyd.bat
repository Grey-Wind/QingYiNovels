@echo off
set "folderPath=./"
set "extensions=.pyd"

for %%E in (%extensions%) do (
    for /f "delims=" %%F in ('dir /b /s "%folderPath%*%%E"') do (
        set "filePath=%%F"
        setlocal enabledelayedexpansion
        if "!filePath:%folderPath%=!"=="!filePath!" (
            del "%%F"
            echo Deleted: %%F
        )
        endlocal
    )
)
