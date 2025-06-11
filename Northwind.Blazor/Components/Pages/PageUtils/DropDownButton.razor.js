function callDropDownNetMethod(itemChosen) {
    alert("IN callDropDownNetMethod");
    DotNet.invokeMethodAsync('Northwind.Blazor', 'DropDownMethod', itemChosen)
        .then(data => {
            console.log(data);
        });
}

function callCustDropDownNetMethod(itemChosen) {
    alert("IN callDropDownNetMethod");
    DotNet.invokeMethodAsync('Northwind.Blazor', 'NextAction', itemChosen)
        .then(data => {
            console.log(data);
        });
}