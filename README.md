# TextRazor.NET

A .NET library for accessing the TextRazor API over [REST](https://www.textrazor.com/docs/rest).

## Usage

You will first need to acquire an API key from [TextRazor](https://www.textrazor.com/), after that:

```c#
TextRazorClient client = new TextRazorClient("https://api.textrazor.com", "YOUR_API_KEY");
ApiResponse response = client.Analyse("The text you want to analyze", ExtractorTypes.Entities | ExtractorTypes.Entailments);
```

## Nuget

Coming very soon!
