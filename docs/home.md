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
  and the classic/new switch is handled in custom_template/styles/main.js.
  NOTE: keep this HTML free of blank lines - a blank line ends the HTML block in Markdown.
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
<h1>Unit testing for all .NET languages</h1>
<p class="nh-lead">NUnit is the open-source unit-testing framework for .NET. Here you will find guides and reference documentation for the framework, the test runners, the Visual Studio adapter and the analyzers.</p>
<div class="nh-actions">
<a class="nh-btn nh-btn-primary" href="articles/nunit/getting-started/installation.md">Get started</a>
<a class="nh-btn" href="articles/nunit/writing-tests/attributes.md">Write tests</a>
<a class="nh-btn" href="articles/nunit/release-notes/framework.md">What's new</a>
</div>
<p class="nh-popular"><span>Popular:</span>
<a href="articles/nunit/writing-tests/constraints/Constraints.md">Assert.That</a>
<a href="articles/nunit/writing-tests/attributes/testcase.md">[TestCase]</a>
<a href="articles/nunit/writing-tests/setup-teardown/index.md">[SetUp] &amp; [TearDown]</a>
<a href="articles/nunit/technical-notes/usage/Framework-Parallel-Test-Execution.md">Parallel execution</a>
<a href="articles/nunit/release-notes/Nunit4.0-MigrationGuide.md">Migrating to NUnit 4</a>
</p>
</div>
<div class="nh-hero-code" aria-label="Example NUnit test">
<div class="nh-code-title"><span></span><span></span><span></span>CalculatorTests.cs</div>
<pre><code class="lang-csharp">using NUnit.Framework;
[TestFixture]
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
<section class="nh-section" aria-labelledby="nh-start">
<h2 id="nh-start">Start here</h2>
<p class="nh-section-lead">Task-oriented entry points, from your first test to upgrading an existing test suite.</p>
<div class="nh-grid nh-grid-4">
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M4.5 16.5c-1.5 1.26-2 5-2 5s3.74-.5 5-2c.71-.84.7-2.13-.09-2.91a2.18 2.18 0 0 0-2.91-.09z"/><path d="m12 15-3-3a22 22 0 0 1 2-3.95A12.88 12.88 0 0 1 22 2c0 2.72-.78 7.5-6 11a22.35 22.35 0 0 1-4 2z"/><path d="M9 12H4s.55-3.03 2-4c1.62-1.08 5 0 5 0"/><path d="M12 15v5s3.03-.55 4-2c1.08-1.62 0-5 0-5"/></svg></div>
<h3><a href="articles/nunit/getting-started/installation.md">Get started</a></h3>
<p>Add NUnit to a project and run your first test.</p>
<ul>
<li><a href="articles/nunit/getting-started/installation.md">Installation</a></li>
<li><a href="articles/nunit/getting-started/downloading.md">Downloading</a></li>
<li><a href="articles/nunit/getting-started/dotnet-core-and-dotnet-standard.md">.NET Core and .NET Standard</a></li>
<li><a href="articles/nunit/getting-started/samples.md">Samples</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><polyline points="16 18 22 12 16 6"/><polyline points="8 6 2 12 8 18"/></svg></div>
<h3><a href="articles/nunit/writing-tests/attributes.md">Write tests</a></h3>
<p>Fixtures, attributes, assertions and data-driven tests.</p>
<ul>
<li><a href="articles/nunit/writing-tests/assertions/assertions.md">Assertions</a></li>
<li><a href="articles/nunit/writing-tests/constraints/Constraints.md">Constraints</a></li>
<li><a href="articles/nunit/technical-notes/usage/Parameterized-Tests.md">Parameterized tests</a></li>
<li><a href="articles/nunit/writing-tests/TestContext.md">TestContext</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><polygon points="6 3 20 12 6 21 6 3"/></svg></div>
<h3><a href="articles/nunit/running-tests/Index.md">Run tests</a></h3>
<p>In Visual Studio, with <code>dotnet test</code>, or from the console.</p>
<ul>
<li><a href="articles/vs-test-adapter/Usage.md">Visual Studio and dotnet test</a></li>
<li><a href="articles/nunit/running-tests/Console-Runner.md">Console runner</a></li>
<li><a href="articles/nunit/running-tests/NUnitLite-Runner.md">NUnitLite</a></li>
<li><a href="articles/nunit/running-tests/Test-Selection-Language.md">Selecting tests</a></li>
</ul>
</div>
<div class="nh-card">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="m16 12-4-4-4 4"/><path d="M12 16V8"/></svg></div>
<h3><a href="articles/nunit/getting-started/upgrading.md">Upgrade</a></h3>
<p>Move to a newer NUnit version with confidence.</p>
<ul>
<li><a href="articles/nunit/release-notes/Nunit4.0-MigrationGuide.md">NUnit 4 migration guide</a></li>
<li><a href="articles/nunit/release-notes/breaking-changes.md">Breaking changes</a></li>
<li><a href="articles/nunit/release-notes/framework.md">Framework release notes</a></li>
<li><a href="articles/nunit/getting-started/upgrading.md">Upgrading</a></li>
</ul>
</div>
</div>
</section>
<section class="nh-section" aria-labelledby="nh-reference">
<h2 id="nh-reference">Reference</h2>
<p class="nh-section-lead">Look things up quickly.</p>
<div class="nh-grid nh-grid-links">
<a class="nh-link" href="articles/nunit/writing-tests/attributes.md"><strong>Attributes</strong><span>[Test], [TestCase], [SetUp] and more</span></a>
<a class="nh-link" href="articles/nunit/writing-tests/constraints/Constraints.md"><strong>Constraints</strong><span>The Assert.That constraint model</span></a>
<a class="nh-link" href="articles/nunit/writing-tests/assertions/assertion-models/classic.md"><strong>Classic assertions</strong><span>ClassicAssert.AreEqual and friends</span></a>
<a class="nh-link" href="articles/nunit/writing-tests/assertions/assertion-models/special.md"><strong>Special assertions</strong><span>Pass, Fail, Ignore, Inconclusive</span></a>
<a class="nh-link" href="articles/nunit-analyzers/NUnit-Analyzers.md"><strong>Analyzer rules</strong><span>NUnit1001 &ndash; NUnit4xxx diagnostics</span></a>
<a class="nh-link" href="articles/nunit/running-tests/Console-Command-Line.md"><strong>Console command line</strong><span>All nunit3-console options</span></a>
<a class="nh-link" href="articles/nunit/technical-notes/usage/Test-Result-XML-Format.md"><strong>Test result XML</strong><span>The result file format</span></a>
<a class="nh-link" href="api/NUnit.Framework.yml"><strong>API reference</strong><span>Generated from the NUnit assemblies</span></a>
</div>
</section>
<section class="nh-section" aria-labelledby="nh-ecosystem">
<h2 id="nh-ecosystem">The NUnit family</h2>
<p class="nh-section-lead">NUnit is more than a framework. Pick the tool you are working with.</p>
<div class="nh-grid nh-grid-3">
<a class="nh-card nh-card-link" href="articles/nunit/intro.md">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/></svg></div>
<h3>NUnit Framework</h3>
<p>The core framework, NUnitLite and the console runner.</p>
</a>
<a class="nh-card nh-card-link" href="articles/vs-test-adapter/Index.md">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><rect width="20" height="14" x="2" y="3" rx="2"/><line x1="8" x2="16" y1="21" y2="21"/><line x1="12" x2="12" y1="17" y2="21"/></svg></div>
<h3>VS Test Adapter</h3>
<p>Run NUnit tests in Visual Studio, Rider and <code>dotnet test</code>.</p>
</a>
<a class="nh-card nh-card-link" href="articles/nunit-analyzers/NUnit-Analyzers.md">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M15 14c.2-1 .7-1.7 1.5-2.5 1-.9 1.5-2.2 1.5-3.5A6 6 0 0 0 6 8c0 1 .2 2.2 1.5 3.5.7.7 1.3 1.5 1.5 2.5"/><path d="M9 18h6"/><path d="M10 22h4"/></svg></div>
<h3>NUnit Analyzers</h3>
<p>Roslyn analyzers and code fixes that catch test mistakes as you type.</p>
</a>
<a class="nh-card nh-card-link" href="articles/nunit-engine/Index.md">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><rect x="4" y="4" width="16" height="16" rx="2"/><rect x="9" y="9" width="6" height="6"/><path d="M9 1v3M15 1v3M9 20v3M15 20v3M20 9h3M20 14h3M1 9h3M1 14h3"/></svg></div>
<h3>NUnit Engine</h3>
<p>The engine all runners are built on, and its extensions.</p>
</a>
<a class="nh-card nh-card-link" href="articles/vs-test-generator/Visual-Studio-Test-Generator.md">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M14.5 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7.5L14.5 2z"/><polyline points="14 2 14 8 20 8"/><line x1="12" x2="12" y1="18" y2="12"/><line x1="9" x2="15" y1="15" y2="15"/></svg></div>
<h3>VS Test Generator</h3>
<p>Generate NUnit test stubs from Visual Studio.</p>
</a>
<a class="nh-card nh-card-link" href="articles/xamarin-runners/index.md">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><rect width="14" height="20" x="5" y="2" rx="2"/><path d="M12 18h.01"/></svg></div>
<h3>Xamarin Runners</h3>
<p>Run NUnit tests on mobile devices.</p>
</a>
</div>
</section>
<section class="nh-section nh-split">
<div class="nh-panel" aria-labelledby="nh-further">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M12 22v-5"/><path d="M9 8V2"/><path d="M15 8V2"/><path d="M18 8v5a4 4 0 0 1-4 4h-4a4 4 0 0 1-4-4V8Z"/></svg></div>
<h2 id="nh-further">Go further</h2>
<ul>
<li><a href="articles/nunit/extending-nunit/Index.md">Extending the framework</a></li>
<li><a href="articles/nunit-engine/extensions/Index.md">Engine extensions</a></li>
<li><a href="articles/nunit/technical-notes/usage/Usage-Notes.md">Usage notes</a></li>
<li><a href="articles/nunit/technical-notes/nunit-internals/NUnit-Internals.md">NUnit internals</a></li>
</ul>
</div>
<div class="nh-panel" aria-labelledby="nh-community">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M22 21v-2a4 4 0 0 0-3-3.87"/><path d="M16 3.13a4 4 0 0 1 0 7.75"/></svg></div>
<h2 id="nh-community">Community and contributing</h2>
<ul>
<li><a href="https://github.com/nunit/nunit">NUnit on GitHub</a></li>
<li><a href="https://github.com/nunit/nunit/discussions">Ask a question in Discussions</a></li>
<li><a href="articles/developer-info/Team-Practices.md">Team practices and developer info</a></li>
<li><a href="https://github.com/nunit/docs/blob/master/CONTRIBUTING.md">Help improve these docs</a></li>
</ul>
</div>
<div class="nh-panel" aria-labelledby="nh-archive">
<div class="nh-icon" aria-hidden="true"><svg viewBox="0 0 24 24"><rect width="20" height="5" x="2" y="3" rx="1"/><path d="M4 8v11a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8"/><path d="M10 12h4"/></svg></div>
<h2 id="nh-archive">Archive</h2>
<ul>
<li><a href="articles/legacy/index.md">NUnit 2.x documentation</a></li>
<li><a href="articles/nunit/release-notes/Pre-3.5-Release-Notes.md">Release notes before 3.5</a></li>
<li><a href="articles/nunit/Towards-NUnit4.md">Towards NUnit 4</a></li>
<li><a href="https://github.com/TestCentric/testcentric-gui/wiki">TestCentric GUI</a></li>
</ul>
</div>
</section>
</div>
