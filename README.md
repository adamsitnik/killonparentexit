# killonparentexit

`killonparentexit` is a tiny .NET 11 command line wrapper that starts another process with `ProcessStartInfo.KillOnParentExit = true`, waits for it to finish, and returns the child process exit code.

## Usage

```bash
killonparentexit <application> [arguments...]
```

Examples:

```bash
killonparentexit /usr/bin/sleep 10
killonparentexit /bin/sh -c "echo hello"
```

## Publish

Publish a self-contained single-file executable for the target runtime identifier (RID):

```bash
dotnet publish /home/runner/work/killonparentexit/killonparentexit/killonparentexit/killonparentexit.csproj -c Release -r linux-x64
```

Supported publish targets in the project file are `linux-x64` and `win-x64`.