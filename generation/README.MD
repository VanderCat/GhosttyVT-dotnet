# Installing ClangSharp
```bash
dotnet tool install --global ClangSharpPInvokeGenerator
```
# Generating
from root directory
```bash
export PATH="$PATH:$HOME/.dotnet/tools"
ClangSharpPInvokeGenerator @generation/clang.rsp
```