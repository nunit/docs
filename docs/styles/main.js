// Site-wide scripts for docs.nunit.org.
// DocFX's default template loads styles/main.js on every page (after jQuery and docfx.js),
// and this resource file replaces the template's empty copy in the build output.

var currentYear= new Date().getFullYear();
document.getElementById("currentYear").innerHTML = currentYear;

// Report clicks on the "Edit this page" / "View Source" links to Google Analytics (GA4)
// so we can see, per page, where readers feel the docs need work (see nunit/docs#591).
// The event lands in GA4 as "contribution_link_click"; break it down by page in
// Reports > Engagement > Events, or in Explore using the page_path parameter.
//
// Safety notes:
// - The click is never intercepted (no preventDefault, no delayed navigation), so the link
//   behaves identically whether or not analytics is loaded or blocked.
// - gtag is only called when it exists; ad blockers that remove it make this a no-op.
// - GA4 sends events via navigator.sendBeacon by default, so the hit survives navigation.
document.addEventListener("click", function (event) {
  var link = event.target && event.target.closest ? event.target.closest("a.contribution-link") : null;
  if (!link || typeof window.gtag !== "function") {
    return;
  }

  try {
    window.gtag("event", "contribution_link_click", {
      link_text: (link.textContent || "").trim(),
      link_url: link.href,
      page_path: window.location.pathname
    });
  } catch (e) {
    // Never let analytics interfere with the link.
  }
});
