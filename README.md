# TextRazor.NET

A .NET library for accessing the TextRazor API over [REST](https://www.textrazor.com/docs/rest).

## Usage

You will first need to acquire an API key from [TextRazor](https://www.textrazor.com/), after that:

```c#
TextRazorClient client = new TextRazorClient("https://api.textrazor.com", "YOUR_API_KEY");
ApiResponse response = client.Analyse("The text you want to analyze", ExtractorTypes.Entities | ExtractorTypes.Entailments);
```

## Nuget

TextRazor.NET is available on [NuGet](https://www.nuget.org/packages/TextRazor.NET/), with CI releases on MyGet.


## Current Builds
The official TextRazor.NET build and nuget package is automated via MyGet [build services](http://docs.myget.org/docs/reference/build-services). Contributors can test private builds using MyGet build services under their own account.

### Stable
[![cskardon MyGet Build Status](https://www.myget.org/BuildSource/Badge/cskardon?identifier=a58db3b2-bfa6-4289-a5dd-9d85e1d619a4)](https://www.myget.org/)