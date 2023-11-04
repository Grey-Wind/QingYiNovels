rmdir /s /q build
rmdir /s /q dist
pyinstaller --clean --name tools --icon ./icon/favicon.ico tools.py
xcopy /y update-log.txt dist\tools\
xcopy /y site.json dist\tools\
xcopy /y load.prop dist\tools\

REM 复制文件
xcopy /y "dist\tools\tools.exe" "Test\"
xcopy /y "site.json" "Test\"
xcopy /y "load.prop" "Test\""

REM 复制文件夹
xcopy /s /e /h /y "dist\tools\_internal" "Test\_internal\"
