var currentYear= new Date().getFullYear();
document.getElementById("currentYear").innerHTML = currentYear;

// NUnit docs adds the lang attribute ourselves for accessibility reasons, as docfx does not do this out of the box.
var htmlElement = document.querySelector("html");
htmlElement.setAttribute("lang", "en");