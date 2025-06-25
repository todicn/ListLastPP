# ListLastPP

A simple C# console application that provides two main functionalities for file operations:

1. **List file contents** - Display the complete contents of a file with line numbers
2. **Print last 10 lines** - Display the last 10 lines of a file

## Features

- List complete file contents with line numbers
- Print the last 10 lines of any text file
- Error handling for missing files and file access issues
- Clean command-line interface

## Usage

### Build the project
```bash
dotnet build
```

### Run the application
```bash
dotnet run -- <command> <file_path>
```

### Commands

#### List complete file contents
```bash
dotnet run -- list <file_path>
```
Example:
```bash
dotnet run -- list myfile.txt
```

#### Print last 10 lines
```bash
dotnet run -- last <file_path>
```
Example:
```bash
dotnet run -- last /path/to/logfile.log
```

## Public API Methods

The application exposes two public static methods that can be used programmatically:

### `ListFileContents(string filePath)`
Lists the complete contents of a file with line numbers.

### `PrintLastLines(string filePath, int lineCount = 10)`
Prints the last N lines of a file (default: 10 lines).

## Requirements

- .NET 8.0 or later

## Error Handling

The application handles common errors such as:
- File not found
- File access permissions
- Invalid file paths
- General I/O exceptions

## License

This project is open source and available under standard licensing terms. 