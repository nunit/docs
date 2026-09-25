---
title: NUnit Documentation
_disableAffix: true
_disableContribution: true
_description: Documentation for NUnit, the open-source unit-testing framework for all .NET languages.
---
<!-- markdownlint-disable-file MD033 MD041 -->
<!--
  New landing page (preview). The classic landing page is index.md.
  Styles live in custom_template/styles/main.css (all scoped under .nh),
  and the classic/new switch is handled in styles/main.js.
  NOTE: keep this HTML free of blank lines - a blank line ends the HTML block in Markdown.
  The cards follow the layout proposed in https://github.com/nunit/docs/pull/1026:
  written from the user's point of view, with writing tests up front.
-->
<div class="nh">
<div class="nh-switch" role="note">
<span class="nh-badge">Preview</span>
<span>You are looking at the new documentation home page, which is still taking shape.</span>
<a href="index.md" data-nh-layout="classic">Switch to the classic home page</a>
</div>
<section class="nh-hero">
<div class="nh-hero-text">
<p class="nh-eyebrow">NUnit documentation</p>
<h1>Write tests you can trust, for any .NET code</h1>
<p class="nh-lead">NUnit is the open-source unit-testing framework for .NET. Write a test in a few lines, run it with many sets of data, and run it anywhere: in Visual Studio, Rider, VS Code, on the command line or in your build pipeline.</p>
<div class="nh-actions">
<a class="nh-btn nh-btn-primary" href="articles/nunit/writing-tests/ordinary-tests.md">Write your first test</a>
<a class="nh-btn" href="articles/nunit/getting-started/installation.md">Install NUnit</a>
<a class="nh-btn" href="articles/nunit/release-notes/framework.md">What's new</a>
</div>
<p class="nh-popular"><span>Popular:</span>
<a href="articles/nunit/writing-tests/data-driven-tests.md">Test with many inputs</a>
<a href="articles/nunit/writing-tests/constraints/Constraints.md">Checking results</a>
<a href="articles/nunit/writing-tests/setup-teardown/index.md">Setup and cleanup</a>
<a href="articles/nunit/technical-notes/usage/Framework-Parallel-Test-Execution.md">Running tests in parallel</a>
<a href="articles/nunit/release-notes/Nunit4.0-MigrationGuide.md">Upgrading to NUnit 4</a>
</p>
</div>
<div class="nh-hero-code" aria-label="Example NUnit test">
<div class="nh-code-title"><span></span><span></span><span></span>CalculatorTests.cs</div>
<pre><code class="lang-csharp">using NUnit.Framework;
public class CalculatorTests
{
    [TestCase(2, 3, 5)]
    [TestCase(-1, 1, 0)]
    public void Add_ReturnsSum(int a, int b, int expected)
    {
        var result = new Calculator().Add(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }
}</code></pre>
</div>
</section>
<section class="nh-section" aria-label="Documentation sections">
<div class="nh-grid nh-grid-3 nh-cards">
<div class="nh-card nh-card-featured">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><polyline points="16 18 22 12 16 6"/><polyline points="8 6 2 12 8 18"/></svg></div>
<h2><a href="articles/nunit/writing-tests/ordinary-tests.md">Writing tests</a></h2>
<p>From a single test to tests that run with hundreds of inputs.</p>
<ul>
<li><a href="articles/nunit/writing-tests/ordinary-tests.md">Ordinary tests</a></li>
<li><a href="articles/nunit/writing-tests/data-driven-tests.md">Data driven tests</a></li>
<li><a href="articles/nunit/writing-tests/automating-tests.md">Automating tests</a></li>
</ul>
<h3>Reference</h3>
<ul>
<li><a href="articles/nunit/writing-tests/attributes.md">Attributes</a></li>
<li><a href="articles/nunit/writing-tests/constraints/Constraints.md">Fluent assertions</a></li>
<li><a href="articles/nunit/writing-tests/assertions/assertion-models/classic.md">Classic assertions</a></li>
<li><a href="articles/nunit/writing-tests/assertions/assertion-models/special.md">Special assertions</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M4.5 16.5c-1.5 1.26-2 5-2 5s3.74-.5 5-2c.71-.84.7-2.13-.09-2.91a2.18 2.18 0 0 0-2.91-.09z"/><path d="m12 15-3-3a22 22 0 0 1 2-3.95A12.88 12.88 0 0 1 22 2c0 2.72-.78 7.5-6 11a22.35 22.35 0 0 1-4 2z"/><path d="M9 12H4s.55-3.03 2-4c1.62-1.08 5 0 5 0"/><path d="M12 15v5s3.03-.55 4-2c1.08-1.62 0-5 0-5"/></svg></div>
<h2><a href="articles/nunit/getting-started/installation.md">Getting started</a></h2>
<p>Add NUnit to your project, or move to a newer version.</p>
<ul>
<li><a href="articles/nunit/getting-started/installation.md">Installing</a></li>
<li><a href="articles/nunit/getting-started/upgrading.md">Upgrading NUnit</a></li>
<li><a href="articles/nunit/release-notes/Nunit4.0-MigrationGuide.md">Migrating to NUnit 4</a></li>
<li><a href="articles/nunit/getting-started/samples.md">Samples</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M4 22h16a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2H8a2 2 0 0 0-2 2v16a2 2 0 0 1-2 2Zm0 0a2 2 0 0 1-2-2v-9c0-1.1.9-2 2-2h2"/><path d="M18 14h-8"/><path d="M15 18h-5"/><path d="M10 6h8v4h-8V6Z"/></svg></div>
<h2><a href="articles/nunit/release-notes/framework.md">News</a></h2>
<p>What is new in NUnit and its tools.</p>
<ul>
<li><a href="articles/nunit/release-notes/framework.md">NUnit release notes</a></li>
<li><a href="articles/vs-test-adapter/AdapterV4-Release-Notes.md">Test adapter release notes</a></li>
<li><a href="articles/nunit-engine/release-notes.md">Engine and console release notes</a></li>
<li><a href="articles/nunit/release-notes/breaking-changes.md">Breaking changes</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="M12 2a14.5 14.5 0 0 0 0 20 14.5 14.5 0 0 0 0-20"/><path d="M2 12h20"/></svg></div>
<h2><a href="articles/nunit/running-tests/Index.md">Run anywhere</a></h2>
<p>Run your tests in the IDE, on the command line or in your build.</p>
<ul>
<li><a href="articles/vs-test-adapter/Index.md">Visual Studio, Rider and dotnet test</a></li>
<li><a href="articles/nunit/running-tests/Console-Runner.md">Command line console</a></li>
<li><a href="articles/nunit/running-tests/NUnitLite-Runner.md">Self-running test programs</a></li>
<li><a href="articles/xamarin-runners/index.md">Mobile devices</a></li>
<li><a href="articles/nunit/running-tests/Test-Selection-Language.md">Choosing which tests to run</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><rect x="4" y="4" width="16" height="16" rx="2"/><rect x="9" y="9" width="6" height="6"/><path d="M9 1v3M15 1v3M9 20v3M15 20v3M20 9h3M20 14h3M1 9h3M1 14h3"/></svg></div>
<h2><a href="articles/nunit/technical-notes/usage/Usage-Notes.md">NUnit Tech</a></h2>
<p>How NUnit and its tools work under the hood.</p>
<ul>
<li><a href="articles/nunit-analyzers/NUnit-Analyzers.md">NUnit Analyzers</a></li>
<li><a href="articles/nunit-engine/Index.md">The NUnit Engine</a></li>
<li><a href="articles/nunit/technical-notes/usage/Framework-Parallel-Test-Execution.md">Parallel test execution</a></li>
<li><a href="articles/nunit/technical-notes/usage/Test-Result-XML-Format.md">Test result file format</a></li>
<li><a href="api/NUnit.Framework.yml">API reference</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z"/><path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z"/></svg></div>
<h2><a href="articles/vs-test-adapter/Tips-And-Tricks.md">Articles</a></h2>
<p>Practical guides and deeper reading.</p>
<ul>
<li><a href="articles/vs-test-adapter/Tips-And-Tricks.md">Tips and tricks</a></li>
<li><a href="articles/vs-test-adapter/Debugging.md">Debugging your tests</a></li>
<li><a href="articles/nunit/technical-notes/usage/Trace-and-Debug-Output.md">Trace and debug output</a></li>
<li><a href="articles/vs-test-generator/Visual-Studio-Test-Generator.md">Generating tests in Visual Studio</a></li>
<li><a href="articles/nunit/Towards-NUnit4.md">Towards NUnit 4</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z"/></svg></div>
<h2><a href="articles/developer-info/Team-Practices.md">Developer info</a></h2>
<p>For contributors to the NUnit projects.</p>
<ul>
<li><a href="articles/developer-info/The-Teams.md">The teams</a></li>
<li><a href="articles/developer-info/Team-Practices.md">Team practices</a></li>
<li><a href="articles/developer-info/Coding-Standards.md">Coding standards</a></li>
<li><a href="articles/developer-info/Best-practices-for-XML-documentation.md">XML documentation</a></li>
<li><a href="articles/developer-info/Contributions.md">Contributions</a></li>
<li><a href="articles/developer-info/Issue-Tracking.md">Issue tracking</a></li>
<li><a href="articles/developer-info/Notes-Toward-NUnit-4.0.md">NUnit 4.0 plans</a></li>
<li><a href="articles/developer-info/Packaging-the-Framework.md">Packaging</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M12 22v-5"/><path d="M9 8V2"/><path d="M15 8V2"/><path d="M18 8v5a4 4 0 0 1-4 4h-4a4 4 0 0 1-4-4V8Z"/></svg></div>
<h2><a href="articles/nunit/extending-nunit/Index.md">Advanced</a></h2>
<p>Make NUnit do more than it does out of the box.</p>
<ul>
<li><a href="articles/nunit/extending-nunit/Index.md">Extending NUnit</a></li>
<li><a href="articles/nunit/extending-nunit/Custom-Constraints.md">Custom constraints</a></li>
<li><a href="articles/nunit/extending-nunit/Custom-Attributes.md">Custom attributes</a></li>
<li><a href="articles/nunit/extending-nunit/Action-Attributes.md">Action attributes</a></li>
<li><a href="articles/nunit-engine/extensions/Index.md">Engine extensions</a></li>
</ul>
</div>
<div class="nh-card nh-card-wide">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><rect width="20" height="5" x="2" y="3" rx="1"/><path d="M4 8v11a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8"/><path d="M10 12h4"/></svg></div>
<h2><a href="articles/legacy/index.md">Archive</a></h2>
<p>Documentation for older versions.</p>
<ul>
<li><a href="articles/legacy/index.md">NUnit 2.x documentation</a></li>
<li><a href="articles/nunit/release-notes/Pre-3.5-Release-Notes.md">Release notes before 3.5</a></li>
<li><a href="articles/nunit/getting-started/dotnet-core-and-dotnet-standard.md">.NET Core and .NET Standard</a></li>
<li><a href="articles/vs-test-adapter/AdapterV3-Release-Notes.md">Test adapter V3 release notes</a></li>
<li><a href="articles/vs-test-adapter/AdapterV2-Release-Notes.md">Test adapter V2 release notes</a></li>
</ul>
</div>
</div>
</section>
<p class="nh-community">Questions? <a href="https://github.com/nunit/nunit/discussions">Ask in GitHub Discussions</a> &middot; <a href="https://github.com/nunit/nunit">NUnit on GitHub</a> &middot; <a href="https://github.com/nunit/docs/blob/master/CONTRIBUTING.md">Help improve these docs</a></p>
</div>
