# Console Calculator & Unit Converter (C#)

A  console app written in C#. It can do basic maths and convert between common units.

## Features

- **Calculator:** add, subtract, multiply and divide
- **Distance:** kilometres to miles and miles to kilometres
- **Temperature:** Celsius to Fahrenheit and Fahrenheit to Celsius
- **Currency:** GHS to USD using an exchange rate you type in
- **Safe input:** wrong input (letters, blank entries, division by zero, invalid rates) shows a message instead of crashing

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) 19.0 or newer
- An IDE such as Visual Studio Code or Visual Studio

To check that .NET is installed, run:

```
dotnet --version
```

If it prints a version number (for example `10.0.x`), you are ready.

## Project files

```
CalculatorConverter/
├── CalculatorConverter.csproj   # project settings
├── Program.cs                   # the application code
└── README.md                    # this file
```

## Setup

1. Install the .NET SDK (see Requirements above).
2. Put `Program.cs`, `CalculatorConverter.csproj` and `README.md` together in one folder, for example `CalculatorConverter`.
3. Open a terminal in that folder.

   - **VS Code:** open the folder, then choose Terminal > New Terminal.
   - **Windows:** type `cmd` in the folder's address bar in File Explorer and press Enter.
	- 
## Run

```
dotnet run
```

The first run also builds the project. To build without running, use `dotnet build`.

## How to use

After starting, you will see a menu:

```
What would you like to do?
1. Calculator (add, subtract, multiply, divide)
2. Kilometres <-> Miles
3. Celsius <-> Fahrenheit
4. GHS to USD
Choose 1, 2, 3 or 4:
```

### Calculator example

```
Choose 1, 2, 3 or 4: 1
Enter Num1: 20
Operators: add, subtract, multiply, divide
Enter Operator: divide
Enter Num2: 4
Result: 5
```

### Distance example

```
Choose 1, 2, 3 or 4: 2
Convert from (km or miles): km
Enter the distance in kilometres: 10
Result: 10 km = 6.21 miles
```

### Temperature example

```
Choose 1, 2, 3 or 4: 3
Convert from (c or f): c
Enter the temperature in Celsius: 25
Result: 25 C = 77 F
```

### Currency example

Type the rate as "how many GHS equal 1 USD". For example, if 1 USD = 12 GHS, type `12`.

```
Choose 1, 2, 3 or 4: 4
Enter the rate (how many GHS equal 1 USD): 12
Enter the amount in GHS: 600
Result: GHS 600 = USD 50
```

After every task the app asks:

```
Do you want to perform another calculation? (yes to continue, no to exit):
```

Type `y` to return to the menu. Anything else exits the program.

## Conversion formulas

| Conversion | Formula |
|---|---|
| km to miles | km × 0.621371 |
| miles to km | miles × 1.609344 |
| Celsius to Fahrenheit | C × 9 / 5 + 32 |
| Fahrenheit to Celsius | (F − 32) × 5 / 9 |
| GHS to USD | GHS ÷ rate |

Results are rounded to 2 decimal places.

## Architecture and design

The app is a single file (`Program.cs`) containing one class, `Calculator`.

```
Main()                      menu loop and "another calculation?" prompt
 ├── RunCalculator()        Num1 -> operator -> Num2 -> result
 ├── ConvertDistance()      km <-> miles
 ├── ConvertTemperature()   C <-> F
 └── ConvertGhsToUsd()      GHS -> USD using a user-supplied rate

ReadNumber(prompt)          shared helper used by every method above
```

### Program flow

1. `Main` prints the menu and reads the user's choice.
2. A `switch` statement sends the choice to the matching method.
3. The method asks for its inputs, calculates, and prints the result.
4. Back in `Main`, the app asks whether to continue. `y` repeats the loop; anything else exits.

### Design decisions

- **One method per feature:** each feature is separate, so one can be read or changed without touching the others.
- **Guard against known errors:** division by zero and a rate of zero or less are checked explicitly and produce a friendly message.
- **Method naming:** the calculator method is called `RunCalculator` because a C# method cannot have the same name as its class.
- **Rounding for display only:** `Math.Round(..., 2)` is applied when printing, so the underlying calculation keeps full precision.

## Assumptions and known limitations

### Assumptions

- The user has the .NET SDK installed and runs the app from a terminal.
- Decimal numbers are typed with a dot (for example `3.5`).
- The exchange rate is entered as "how many GHS equal 1 USD". The app does not check whether the rate is realistic.
- Only the exact word `y` continues the program; any other answer exits.

### Known limitations

- **No live exchange rates:** the GHS to USD rate is always typed manually. The app does not fetch rates from the internet.
- **One-way currency:** only GHS to USD is supported, not USD to GHS.
- **Two numbers at a time:** the calculator handles one operation between two numbers. It does not parse full expressions like `2 + 3 * 4`.
- **Console only:** there is no graphical interface, history, or saved settings.