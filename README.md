# ProtoPost for Unity

## Dependencies
Requires [JSON.NET for Unity](https://assetstore.unity.com/packages/tools/input-management/json-net-for-unity-11347)

## Usage
```cs
StartCoroutine(ProtoPost.Post("http://localhost:8080", aJsonDotNetJToken, (json) => {
  //do something with response json object
}));
```
