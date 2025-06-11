function getSessionStorageItems() {
    var items = {};
    for (var i = 0; i < sessionStorage.length; i++) {
        var key = sessionStorage.key(i);
        var value = sessionStorage.getItem(key);
        items[key] = value;
    }
    return items;
}

function getTheTimeFromFile() {
    var now = new Date();
    var theHr = now.getHours();
    var theMin = now.getMinutes();
    alert("FROM JS File - Current Time: " + theHr + ":" + theMin);
}

function showOffcanvasSidebar() {
    var offcanvasElement = document.getElementById('sidebarOffcanvas');
    var bsOffcanvas = new bootstrap.Offcanvas(offcanvasElement);
    bsOffcanvas.show();
}

function callInteriorNetMethod() {
    DotNet.invokeMethodAsync('Northwind.Blazor', 'InteriorMethod')
        .then(data => {
            console.log(data);
        });
    alert("IN callInteriorNetMethod");
}

function resetSessionData() {
    alert("RESETTING SESSION DATA!!!!");
    window.sessionStorage.clear();
    window.localStorage.clear();
    
};

