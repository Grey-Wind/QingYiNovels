rmdir /s /q build
rmdir /s /q dist
pyinstaller --clean --name tools --icon ./favicon.ico tools.py
xcopy /y update-log.txt dist\tools\
xcopy /y site.json dist\tools\
xcopy /y load.prop dist\tools\
