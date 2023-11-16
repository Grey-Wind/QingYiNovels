from distutils.core import setup
from Cython.Build import cythonize

setup(
    ext_modules=cythonize([
        "./parameterFree/parameterFree.pyx",
        "./updateLog/updateLog.pyx",
        "./package/package.pyx"])
)
