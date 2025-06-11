function callCustDropDownNetMethod(itemChosen) {
    alert("IN callDropDownNetMethod");
    DotNet.invokeMethodAsync('Northwind.Blazor', 'NextAction', itemChosen)
        .then(data => {
            console.log(data);
        });
}