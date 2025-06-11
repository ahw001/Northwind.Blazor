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

function callInteriorTest() {
    alert("IN callInteriorJSTestNetMethod");
    DotNet.invokeMethodAsync('Northwind.Blazor', 'InteriorJSTestMethod')
        .then(data => {
            console.log(data);
        });
}

