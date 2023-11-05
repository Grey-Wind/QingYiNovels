@echo off

rmdir /s /q build
rmdir /s /q __pycache__

setlocal enabledelayedexpansion

set "folderPath=./"
set "extensions=.c;.pyd;.pyc"

for %%E in (%extensions%) do (
    for /r "%folderPath%" %%F in (*%%E) do (
        del "%%F"
        echo Deleted: %%F
    )
)

python setup.py build_ext --inplace
pause