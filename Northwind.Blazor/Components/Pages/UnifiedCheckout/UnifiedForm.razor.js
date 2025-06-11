function jsProcessTransToken(tt) {
    alert("IN callInteriorJSTestNetMethod");
    DotNet.invokeMethodAsync('Northwind.Blazor', 'ProcessTransToken', tt)
        .then(data => {
            console.log(data);
        });
}