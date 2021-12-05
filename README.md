# Advent of Code 2021

[![Tests](https://github.com/alexblackie/aoc-2021/actions/workflows/test.yaml/badge.svg)](https://github.com/alexblackie/aoc-2021/actions/workflows/test.yaml)

These are my solutions to the [Advent of Code 2021][0] challenges. This year I
chose to use it as an opportunity to gain more experience with .NET and C#.

[0]: https://adventofcode.com/2021

## Project Structure

The codebase is split into a few different projects to keep logic isolated and reusable.

- `Cmd` is the main console app entrypoint, which generates the CLI
- `Data` manages loading inputs and some data casting of those inputs
- `Submarine` contains the business logic related to controlling the submarine and its subsystems

## Development

Install the .NET Core 6 SDK, and then you can run the app, which will output
each day's answers:

```
$ dotnet run --project Cmd
```

There is a (hopefully) exhaustive xUnit unit test suite:

```
$ dotnet test
```

## Building a publishable release

If, for whatever reason, you want to actually generate a runnable application from this, you can:

```
$ dotnet publish -c Release -r osx-arm64 -p:PublishReadyToRun=true
```

Just change `osx-arm64` to whatever target platform you want (eg., `win-x64`).

You'll find the CLI entrypoint compiled as a self-contained binary:

```
$ ./Cmd/bin/Debug/net6.0/osx-arm64/publish/Cmd
```
