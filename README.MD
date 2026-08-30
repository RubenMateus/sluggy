# Sluggy | SluggyUnidecode

![sluggy](https://raw.githubusercontent.com/RubenMateus/sluggy/master/sluggy.png)
![sluggyUnidecode](https://raw.githubusercontent.com/RubenMateus/sluggy/master/sluggyUnidecode.png)

---

[![Build Status](https://travis-ci.org/RubenMateus/sluggy.svg?branch=master)](https://travis-ci.org/RubenMateus/sluggy)
[![codecov](https://codecov.io/gh/RubenMateus/sluggy/branch/master/graph/badge.svg)](https://codecov.io/gh/RubenMateus/sluggy)

![Build and Test](https://github.com/RubenMateus/sluggy/workflows/Build%20and%20Test/badge.svg)
![Latest](https://github.com/RubenMateus/sluggy/workflows/Latest/badge.svg)

[![CodeFactor](https://www.codefactor.io/repository/github/rubenmateus/sluggy/badge)](https://www.codefactor.io/repository/github/rubenmateus/sluggy)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/9ae9d163099a436aafcbf2189c23e6b6)](https://www.codacy.com/gh/RubenMateus/sluggy/dashboard?utm_source=github.com&utm_medium=referral&utm_content=RubenMateus/sluggy&utm_campaign=Badge_Grade)

---

## Sluggy

[![NuGet](https://img.shields.io/nuget/v/Sluggy.svg)](https://www.nuget.org/packages/Sluggy/)

`dotnet add package Sluggy --version 3.0.1`

Sluggy is a configuration based class library designed to create friendly URL's.

**Check release notes for more info on the latest changes.**

---

## Sluggy Unidecode

[![NuGet](https://img.shields.io/nuget/v/SluggyUnidecode.svg)](https://www.nuget.org/packages/SluggyUnidecode/)

`dotnet add package SluggyUnidecode --version 2.0.0`

SluggyUnidecode is simple and powerful.
Extends the Sluggy package by using the Unidecode.NET library for normalization.

**Check release notes for more info on the latest changes.**

---

## QuickStart with Sluggy

### **There are 4 ways to use ToSlug()**

#### The default strategies are

```csharp
NonAlphaNumericStrategy()
ToLowerInvariantStrategy()
NormalizationStrategy()
```

#### _Default separator is "-"_

Easiest way:

```csharp
using Sluggy;

"EU GOSTO DE TÁRTE".ToSlug();
// Output: "eu-gosto-de-tarte"

"Eu NãO GoStO de PãO Da Avó".ToSlug();
// Output: "eu-nao-gosto-de-pao-da-avo"
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

### You can redefine the default composite strategy by passing as a param

```csharp
using Sluggy;

// Defining the composite strategy
var defaultStrategy = new CompositeStrategy(
    new ToLowerInvariantStrategy(),
    new NormalizationStrategy());

"EU GOSTO DE TÁRTE".ToSlug(defaultStrategy);
// Output: "eu-gosto-de-tarte"

"Eu NãO GoStO de PãO Da Avó".ToSlug(defaultStrategy);
// Output: "eu-nao-gosto-de-pao-da-avo"

// Redefine the composite strategy
var anotherStrategy = new CompositeStrategy(
    new ToLowerInvariantStrategy(),
    new NormalizationStrategy(),
    new RemoveEveryVowelStrategy());

"GOSTO DE TÁRTE".ToSlug(anotherStrategy);
// Output: "gst-d-trt"
```

---

### And lastly you can redefine the default separator and the composite strategy

```csharp
using Sluggy;

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

```csharp
using SluggyUnidecode;

"Мне нравится татарин".ToSlug();
// Output: "mne-nravitsya-tatarin"

"ア α a A".ToSlug();
// Output: "a-a-a-a";

// Even more powerful
"ch\u00e2teau Vi\u00f1edos".ToSlug();
// Output: "chateau-vinedos"
```

## Contributing

Any contribution is allowed, submit a issue or pull request
to start contributing your ideias or problems you encounter.

---

## Release Process

Releases are fully automated via [semantic-release](https://semantic-release.gitbook.io/semantic-release/) on every push to `master`. There is no need to manually create tags or GitHub Releases.

### How it works

1. Push (or merge a PR) to `master`
2. The [release workflow](https://github.com/RubenMateus/sluggy/actions/workflows/release.yml) will automatically:
   - Build and run all tests
   - Analyze commit messages since the last release to determine the version bump
   - Create a git tag, GitHub Release, and changelog
   - Pack `Sluggy` and `SluggyUnidecode` using the new version
   - Publish packages to [NuGet](https://www.nuget.org/packages/Sluggy/) and [GitHub Packages](https://github.com/RubenMateus?tab=packages)

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
see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments

- To **Sérgio Freitas**[[sj-freitas](https://github.com/sj-freitas)]
  for the idea, challenge, guidance and the amazing logo designs.
