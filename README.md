# Balzac.cs

> A C# library that enhances your favorite language


## Tests

[![Open in GitHub Codespaces (web-based version of Visual Studio Code)](https://github.com/codespaces/badge.svg)](https://codespaces.new/visicode/Balzac.cs)


## What does it do?

* Adds missing functionalities to C# language.
* Brings expected behavior to some incomplete features.
* Gently extends C# built-in objects.


## What is it not?

* A polyfill library (use [PolySharp](https://github.com/Sergio0694/PolySharp) for that).
* A C# framework.


## Installation and usage

1. Download and extract the package to your project folder:\
[https://github.com/visicode/Balzac.cs/archive/refs/heads/main.zip](https://github.com/visicode/Balzac.cs/archive/refs/heads/main.zip)

2. Import the Balzac.cs namespace into your C# files:

```c#
using Balzac.cs;
```


## Documentation

Yes, we do extend some C# built-in objects!\
And we'd love our enhancements to be added in C# language, so we'd remove them from the library.

* [C# interfaces enhancements](#doci)
* [C# structures enhancements](#docs)
* [C# classes enhancements](#docc)

<a id="doci"></a>

### C# interfaces enhancements

**IComparable interface enhancements**

```c#
/**
 * Checks if an item is between two values, bounds included.
 *  min:         The minimum value.
 *  max:         The maximum value.
 */
bool = number.IsBetween(min, max);

/**
 * Checks if an item is between two values, bounds excluded.
 *  min:         The minimum value.
 *  max:         The maximum value.
 */
bool = number.IsBetweenExclusive(min, max);
```

<a id="docs"></a>

### C# structures enhancements

**Char structure enhancements**

```c#
/**
 * Checks if a Unicode character is categorized as an uppercase letter.
 */
bool = char.IsUpper();

/**
 * Checks if a Unicode character is categorized as a lowercase letter.
 */
bool = char.IsLower();

/**
 * Converts the value of a Unicode character to its uppercase equivalent.
 *  culture:     An object that supplies culture-specific casing rules (current culture by default).
 */
char = char.ToUpper(CultureInfo.CurrentCulture);

/**
 * Converts the value of a Unicode character to its lowercase equivalent.
 *  culture:     An object that supplies culture-specific casing rules (current culture by default).
 */
char = char.ToLower(CultureInfo.CurrentCulture);

/**
 * Converts a Unicode character to its numeric value (-1 if not a digit).
 */
short = char.ToNumericValue();
```

**DateTime structure enhancements**

```c#
/**
 * Converts the value of a DateTime object to its SQL format representation.
 */
string = datetime.ToSqlString();
```

<a id="docc"></a>

### C# classes enhancements

**Enum class enhancements**

```c#
/**
 * Returns the description associated to an enum value (the enum name if not existing).
 */
string = enum.Value.GetDescription();
```

**String class enhancements**

```c#
/**
 * Checks if a string is all in uppercase letters.
 */
bool = string.IsUpper();

/**
 * Checks if a string is all in lowercase letters.
 */
bool = string.IsLower();

/**
 * Converts a string to title case (every major word capitalized).
 *  culture:     An object that supplies culture-specific casing rules (current culture by default).
 */
string = string.ToTitleCase(CultureInfo.CurrentCulture);

/**
 * Converts a string to sentence case (first word of every sentence capitalized).
 *  culture:     An object that supplies culture-specific casing rules (current culture by default).
 */
string = string.ToSentenceCase(CultureInfo.CurrentCulture);

/**
 * Replaces the format named items in a string with the string representations of corresponding objects in the specified dictionary (or an empty string if not found).
 *  args:        The dictionary that contains the keys and their object values to format.
 *  culture:     An object that supplies culture-specific formatting rules (current culture by default)
 */
string = string.FormatNamed(args, CultureInfo.CurrentCulture);

/**
 * Removes leading and trailing white-space characters from each line of a string.
 */
string = string.TrimLines();

/**
 * Truncates a string to the nearest word, with a trailing ellipsis if needed.
 *  max:         The maximum number of characters to return.
 */
string = string.Truncate(max);

/**
 * Returns only the first lines of a string.
 *  lines:       The number of lines to return.
 */
string = string.FirstLines(lines);
```

**Array class enhancements**

```c#
/**
 * Performs the specified action on each element of an array.
 *  action:      The action to perform on each element of the array.
 */
array = array.ForEach(item => action1(item)).ForEach((item, i) => action2(item, i));
```

**Object class enhancements**

```c#
/**
 * Returns the specific public property value of an object (null if not found).
 *  name:        The string containing the name of the public property to get.
 */
object = object.GetPropertyValue(name);

/**
 * Returns the specific property value of an object, using the specified binding constraints (null if not found).
 *  name:        The string containing the name of the property to get.
 *  bindingAttr: A bitwise combination of the enumeration values that specify how the search is conducted.
 */
object = object.GetPropertyValue(name, BindingFlags.NonPublic | BindingFlags.Instance);
```

**Regex class enhancements**

```c#
/**
 * Adds predefined input Regex patterns to new _Regex.PATTERN object.
 *  EMAIL:       Email address format following official specification.
 *  EMAILS:      One or more email addresses, separated by commas.
 *  PHONE:       Phone number in international or local format, with optional extension.
 *  PASSWORD:    Eight characters minimum password with at least 1 lowercase letter, 1 uppercase letter, 1 number and 1 special character.
 *  PASSPORT:    Passport number in international format.
 *  IBAN:        IBAN number from 16 to 39 characters, optionally grouped in blocks of 4.
 *  POSTCODE:    Multi-countries postal code format.
 */
bool = _Regex.PATTERN.EMAIL.IsMatch(string);
```

**DirectoryInfo class enhancements**

```c#
/**
 * Checks if a directory is empty (returns true if not existing).
 */
bool = directoryinfo.IsEmpty();

/**
 * Tries to delete a directory, specifying whether to delete subdirectories and files.
 *  recursive:   true to delete subdirectories and all files (false by default).
 */
bool = directoryinfo.TryDelete(true);
```

**FileInfo class enhancements**

```c#
/**
 * Adds size constants to new _FileInfo.SIZE object to help converting file sizes from bytes.
 *  KILOBYTE:    Size of 1 kilobyte in bytes.
 *  MEGABYTE:    Size of 1 megabyte in bytes.
 *  GIGABYTE:    Size of 1 gigabyte in bytes.
 *  TERABYTE:    Size of 1 terabyte in bytes.
 */
megabytes = fileinfo.Length / _FileInfo.SIZE.MEGABYTE;

/**
 * Tries to delete a file.
 */
bool = fileinfo.TryDelete();
```

**TimeZoneInfo class enhancements**

```c#
/**
 * Returns a time zone display name in short format (without the UTC time offset).
 */
string = timezoneinfo.ToShortName();
```

**WebUtility class enhancements**

```c#
/**
 * Encodes the specified binary string into base-64 digits.
 *  string:      The binary string to encode (a string in which each character in the string is treated as a byte of binary data).
 *  options:     The encoding options (None by default).
 */
string = WebUtility.BtoA(string, Base64FormattingOptions.InsertLineBreaks);

/**
 * Decodes the specified string, which encodes data as base-64 digits, back to its decoded form.
 *  string:      The string containing base64-encoded data to decode.
 */
string = WebUtility.AtoB(string);

/**
 * Replaces all special characters of a string (other than letters, numbers and separators) with the specified replacement string.
 *  string:      The string containing the special characters to be replaced.
 *  replacement: The replacement string (empty string by default).
 */
string = WebUtility.StripSpecialChars(string, replacement);

/**
 * Converts a string with all new lines replaced with HTML line breaks.
 *  string:      The string containing the new lines to be replaced.
 */
string = WebUtility.Nl2br(string);

/**
 * Converts a string with all new lines replaced with HTML paragraphs.
 *  string:      The string containing the new lines to be replaced.
 */
string = WebUtility.Nl2p(string);

/**
 * Converts a string to its file name representation, with all invalid characters replaced with the specified replacement string.
 *  string:      The string containing the invalid characters to be replaced.
 *  replacement: The replacement string ("_" by default).
 */
string = WebUtility.ToFileName(string, replacement);

/**
 * Converts an HTML string to plain text, with all HTML tags removed.
 *  string:      The HTML string to be converted to plain text.
 */
string = WebUtility.ToPlainText(string);

/**
 * Returns the specified password strength from PASSWORD_STRENGTH.EMPTY to PASSWORD_STRENGTH.STRONG.
 *  password:    The string containing the password to rate.
 *
 *  EMPTY:       Empty.
 *  SHORT:       Less than 8 characters.
 *  WEAK:        One or two of the PASSWORD_STRENGTH.GOOD criteria.
 *  MEDIUM:      Three of the PASSWORD_STRENGTH.GOOD criteria.
 *  GOOD:        At least 1 lowercase letter, 1 uppercase letter, 1 digit and 1 special character.
 *  STRONG:      All PASSWORD_STRENGTH.GOOD criteria and greater than or equal to 12 characters.
 */
WebUtility.GetPasswordStrength(password) >= WebUtility.PASSWORD_STRENGTH.GOOD;
```


## Support

* C# 8.0+


## Known issues

* Set `<httpRuntime fcnMode="Single" />` in `web.config` file to disable immediate IIS recycling on folders and files modification.


## Acknowledgements

Balzac.cs C# library is part of the Balzac project by [Alexandre Gastaud](https://github.com/visicode), along with [Balzac.js](https://github.com/visicode/Balzac.js) JavaScript library.
