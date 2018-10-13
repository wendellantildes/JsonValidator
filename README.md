# JsonValidator
A tool to validate json strings



### What is JsonValidator?

JsonValidator is a tool to validate json strings in .Net Standard.

### How do I get started?

If you want a bool validator, use:

```csharp
var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
if(JsonValidator.IsValid(json)){
//code here
}
```
If you want an Exception one, use:

```csharp
var json = JsonUtils.ReadText(JsonUtils.ValidJsonFileName);
try{
  JsonValidator.Validate(json);
}catch(JsonNotValidException){
  //code here
}
```

