rmdir /s /q build
rmdir /s /q dist
pyinstaller --clean --name tools tools.py
xcopy /y update-log.txt dist\tools\
