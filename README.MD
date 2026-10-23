# Sluggy | SluggyUnidecode

![sluggy](https://raw.githubusercontent.com/RubenMateus/sluggy/main/sluggy.png)
![sluggyUnidecode](https://raw.githubusercontent.com/RubenMateus/sluggy/main/sluggyUnidecode.png)

---

[![Build and Test](https://github.com/RubenMateus/sluggy/actions/workflows/build-test.yml/badge.svg)](https://github.com/RubenMateus/sluggy/actions/workflows/build-test.yml)
[![Latest](https://github.com/RubenMateus/sluggy/actions/workflows/release.yml/badge.svg?branch=main)](https://github.com/RubenMateus/sluggy/actions/workflows/release.yml)
[![CodeQL](https://github.com/RubenMateus/sluggy/actions/workflows/codeql-analysis.yml/badge.svg?branch=main)](https://github.com/RubenMateus/sluggy/actions/workflows/codeql-analysis.yml)
[![Super-Linter](https://github.com/RubenMateus/sluggy/actions/workflows/super-lint-analysis.yml/badge.svg?branch=main)](https://github.com/RubenMateus/sluggy/actions/workflows/super-lint-analysis.yml)
[![codecov](https://codecov.io/gh/RubenMateus/sluggy/branch/main/graph/badge.svg)](https://codecov.io/gh/RubenMateus/sluggy)

[![CodeFactor](https://www.codefactor.io/repository/github/rubenmateus/sluggy/badge)](https://www.codefactor.io/repository/github/rubenmateus/sluggy)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/9ae9d163099a436aafcbf2189c23e6b6)](https://www.codacy.com/gh/RubenMateus/sluggy/dashboard?utm_source=github.com&utm_medium=referral&utm_content=RubenMateus/sluggy&utm_campaign=Badge_Grade)

---

## Sluggy

[![NuGet](https://img.shields.io/nuget/v/Sluggy.svg)](https://www.nuget.org/packages/Sluggy/)

`dotnet add package Sluggy`

Sluggy is a configuration based class library designed to create friendly URL's.
It targets `netstandard2.0`.

**Check the [release notes](https://github.com/RubenMateus/sluggy/releases) for more info on the latest changes.**

---

## Sluggy Unidecode

[![NuGet](https://img.shields.io/nuget/v/SluggyUnidecode.svg)](https://www.nuget.org/packages/SluggyUnidecode/)

`dotnet add package SluggyUnidecode`

SluggyUnidecode is simple and powerful.
Extends the Sluggy package by using the [Unidecode.NET](https://www.nuget.org/packages/Unidecode.NET/) library for normalization.

**Check the [release notes](https://github.com/RubenMateus/sluggy/releases) for more info on the latest changes.**

---

## QuickStart with Sluggy

### **There are 4 ways to use ToSlug()**

#### The default strategies are applied in this order

```csharp
NonAlphaNumericStrategy()   // removes everything that is not a letter, digit or whitespace
ToLowerInvariantStrategy()
NormalizationStrategy()     // removes diacritics (é -> e, ã -> a)
```

#### _Default separator is "-"_

Easiest way:

```csharp
using Sluggy;

"EU GOSTO DE TÁRTE".ToSlug();
// Output: "eu-gosto-de-tarte"

"Eu NãO GoStO de PãO Da Avó".ToSlug();
// Output: "eu-nao-gosto-de-pao-da-avo"

"Hello, World! It's 2026".ToSlug();
// Output: "hello-world-its-2026"
```

---

### You can redefine the separator

```csharp
using Sluggy;

// Defining the separator
var separator = "/";

"EU GOSTO DE TÁRTE".ToSlug(separator);
// Output: "eu/gosto/de/tarte"

"Eu NãO GoStO de PãO Da Avó".ToSlug(separator);
// Output: "eu/nao/gosto/de/pao/da/avo"
```

---

### You can redefine the composite strategy by passing it as a param

The built-in strategies live in the `Sluggy.Strategies` namespace.
You can write your own by implementing `ITranslationStrategy`:

```csharp
using System.Linq;
using Sluggy.Strategies;

// Example custom strategies (not part of the package)
public class RemoveEveryVowelStrategy : ITranslationStrategy
{
    public string Translate(string text) =>
        new string(text.Where(c => "aeiouAEIOU".IndexOf(c) < 0).ToArray());
}

public class ToUpperCaseStrategy : ITranslationStrategy
{
    public string Translate(string text) => text.ToUpperInvariant();
}
```

```csharp
using Sluggy;
using Sluggy.Strategies;

// Defining a composite strategy without the NonAlphaNumericStrategy
var strategy = new CompositeStrategy(
    new ToLowerInvariantStrategy(),
    new NormalizationStrategy());

"EU GOSTO DE TÁRTE".ToSlug(strategy);
// Output: "eu-gosto-de-tarte"

"Eu NãO GoStO de PãO Da Avó".ToSlug(strategy);
// Output: "eu-nao-gosto-de-pao-da-avo"

// Adding a custom strategy
var anotherStrategy = new CompositeStrategy(
    new ToLowerInvariantStrategy(),
    new NormalizationStrategy(),
    new RemoveEveryVowelStrategy());

"GOSTO DE TÁRTE".ToSlug(anotherStrategy);
// Output: "gst-d-trt"
```

---

### And lastly you can redefine both the separator and the composite strategy

```csharp
using Sluggy;
using Sluggy.Strategies;

// Defining the separator
var separator = "/";

// Defining the composite strategy
var normalizationWithUpperCaseStrategy = new CompositeStrategy(
    new ToUpperCaseStrategy(),
    new NormalizationStrategy());

"EU GOSTO DE TÁRTE".ToSlug(separator, normalizationWithUpperCaseStrategy);
// Output: "EU/GOSTO/DE/TARTE"

// Redefine the composite strategy
var anotherStrategy = new CompositeStrategy(
    new ToLowerInvariantStrategy(),
    new NormalizationStrategy(),
    new RemoveEveryVowelStrategy());

"GOSTO DE TÁRTE".ToSlug(separator, anotherStrategy);
// Output: "gst/d/trt"
```

---

## QuickStart with SluggyUnidecode

SluggyUnidecode is simple and uses a powerful normalizer to ASCII characters.
Its default strategy is `NonAlphaNumericStrategy`, `UnidecodeStrategy` and `ToLowerInvariantStrategy`.

```csharp
using SluggyUnidecode;

"Мне нравится татарин".ToSlug();
// Output: "mne-nravitsia-tatarin"

"ア α a A".ToSlug();
// Output: "a-a-a-a"

// Even more powerful
"château Viñedos".ToSlug();
// Output: "chateau-vinedos"

// The separator can be redefined as well
"Мне нравится татарин".ToSlug("_");
// Output: "mne_nravitsia_tatarin"
```

> If both `Sluggy` and `SluggyUnidecode` namespaces are imported in the same file, the `ToSlug()` call is ambiguous.
> Call it explicitly instead, e.g. `SluggyUnidecode.SluggyUnidecode.ToSlug(text)`.

## Contributing

Any contribution is welcome: submit an issue or pull request
to start contributing your ideas or problems you encounter.

To build and run the tests locally you need the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0):

```sh
dotnet build
dotnet test
```

---

## Release Process

Releases are fully automated via [semantic-release](https://semantic-release.gitbook.io/semantic-release/) on every push to `main`. There is no need to manually create tags or GitHub Releases.

### How it works

1. Push (or merge a PR) to `main`
2. The [release workflow](https://github.com/RubenMateus/sluggy/actions/workflows/release.yml) will automatically:
   - Build and run all tests
   - Run semantic-release once per package, each with its own tag format (`sluggy-<version>` and `sluggyUnidecode-<version>`) and version line
   - Create a package-specific git tag and GitHub Release with generated release notes
   - Pack each released package with its own version (`SluggyUnidecode` depends on the latest released `Sluggy` version)
   - Publish packages to NuGet ([Sluggy](https://www.nuget.org/packages/Sluggy/), [SluggyUnidecode](https://www.nuget.org/packages/SluggyUnidecode/)) and [GitHub Packages](https://github.com/RubenMateus?tab=packages)

> Both release streams analyze **all** commits on `main` since their own last tag; commits are not filtered by path.
> A `fix:` or `feat:` commit therefore bumps both packages, each from its own current version.

The release streams continue from the latest `sluggy-*` and `sluggyUnidecode-*` tags, and the workflow fails if no tag matching a package's format is found.
Without a matching tag semantic-release would start over at `1.0.0`, which is already published on NuGet.
The package name comes first because semantic-release only anchors tag formats at the start: with `<version>-sluggy`, tags like `<version>-sluggyUnidecode` would also count as Sluggy releases.
Older tags (`v*-sluggy`, `*-Sluggy`, `*-sluggyUnidecode`) are kept for history and ignored by the current formats.

> If no commits since the last release warrant a version bump (e.g. only `chore:` commits), no release is created.

### Commit Message Format

This project follows [Conventional Commits](https://www.conventionalcommits.org/). The commit message determines the version bump:

| Commit prefix                                     | Example                                | Version bump              |
| ------------------------------------------------- | -------------------------------------- | ------------------------- |
| `fix:`                                            | `fix: handle null input in ToSlug`     | Patch (`3.0.2` → `3.0.3`) |
| `feat:`                                           | `feat: add NonAlphanumericStrategy`    | Minor (`3.0.2` → `3.1.0`) |
| `feat!:` or `BREAKING CHANGE:`                    | `feat!: remove legacy ToSlug overload` | Major (`3.0.2` → `4.0.0`) |
| `chore:`, `docs:`, `style:`, `test:`, `refactor:` | `chore: bump xunit to 2.9.3`           | No release                |

### Required Secrets

| Secret          | Description                                                     |
| --------------- | --------------------------------------------------------------- |
| `NUGET_API_KEY` | API key from [nuget.org](https://www.nuget.org/account/apikeys) |
| `GITHUB_TOKEN`  | Automatically provided by GitHub Actions                        |

---

## Authors

- **Ruben Mateus** - [rubenmateus](https://github.com/rubenmateus)

See also the list of [contributors](https://github.com/rubenmateus/sluggy/graphs/contributors)
who participated in this project.

## License

This project is licensed under the MIT License -
see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- To **Sérgio Freitas**[[sj-freitas](https://github.com/sj-freitas)]
  for the idea, challenge, guidance and the amazing logo designs.
