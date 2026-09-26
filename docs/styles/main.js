var currentYear= new Date().getFullYear();
document.getElementById("currentYear").innerHTML = currentYear;

// Switching between the classic (index.md) and the new (home.md) home page.
// The choice is remembered per browser, so the site root opens the layout the reader picked last.
(function () {
    var key = "nunit-docs-home-layout";
    function read() { try { return localStorage.getItem(key); } catch (e) { return null; } }
    function write(value) { try { localStorage.setItem(key, value); } catch (e) { } }

    document.addEventListener("click", function (e) {
        var link = e.target.closest ? e.target.closest("a[data-nh-layout]") : null;
        if (link) write(link.getAttribute("data-nh-layout"));
    });

    var rel = document.querySelector('meta[name="docfx:rel"]');
    var atRoot = rel && rel.getAttribute("content") === "" && /\/(index\.html)?$/.test(location.pathname);
    if (atRoot && read() === "new" && !/[?&]classic\b/.test(location.search)) {
        location.replace("home.html" + location.hash);
    }
})();
