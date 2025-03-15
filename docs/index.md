---
title: Documentation Home
---

<style>
  /* Inline CSS (or link to an external stylesheet) */
.containerlp {
  display: grid;
  /* border: 2px solid green; */
  grid-template-columns: repeat(3, 1fr); /* 3 columns layout */
  gap: 20px;
  max-width: 1200px;
  margin: 0 auto; /* Center the container */
  padding: 0;
  box-sizing: border-box;
  background-color: #f9f9f9; /* Add background color to visualize container */
}
  .block {
    border: 2px solid blue;
    padding: 10px; /* 15px space on all sides inside the block element */
    border-radius: 10px;
    min-width: 300px; /* Prevents blocks from becoming too small */
  }

  .block h2 { font-size: 1.2em; margin-bottom: 10px; color: #000000; }
  .block h2 a { color: #000000 !important; } /* Override any blue link styling */
  .block ul { list-style: none; padding: 0; }
  .block li { margin-bottom: 5px; }
  .block li a { text-decoration: none; color: #007acc; }
  .block li a:hover { text-decoration: underline; }
  .block img.icon-img {
    margin: 2px; /* Reduced margin for the icon */
  }
</style>

<div style="text-align: center;">
  <h1>Welcome to NUnit Documentation</h1>
</div>

<div class="containerlp">
  <!-- Block 1 -->
  <div class="block" style="grid-column: 1;">
   <!--  <img src="images/AutomatedCodeTestingIcon48x48.png" alt="Automatic Test Icon" class="icon-img"> -->
    <h2><a href="/writing-tests/index.html"><strong>Writing tests</strong></a></h2>
    <ul>
      <li><a href="/writing-tests/ordinary-tests.html">Ordinary tests</a></li>
      <li><a href="/writing-tests/datadriven-tests.html">Data driven tests</a></li>
      <li><a href="/writing-tests/auto-tests.html">Automating tests</a></li>
      <li><strong>References</strong></li>
      <li><a href="/wip.html">Attributes</a></li>
      <li><a href="/wip.html">Fluent Assertions</a></li>
      <li><a href="/wip.html">Classic Assertions</a></li>
      <li><a href="/wip.html">Special Assertions</a></li>

    </ul>
  
  </div>
  <!-- Block 2 -->
  <div class="block" style="grid-column: 2;">
    <h2><a href="/getting-started/index.html"><strong>Getting started</strong></a></h2>
    <ul>
      <li><a href="/getting-started/index.html">Installing</a></li>
      <li><a href="/getting-started/upgrading.html">Upgrading NUnit</a></li>
    </ul>
  </div>
  <!-- Block 3 -->
  <div class="block" style="grid-column: 3;">
    <h2><a href="/news/index.html"><strong>News</strong></a></h2>
    <ul>
      <li><a href="/wip.html">Page 7</a></li>
      <li><a href="/wip.html">Page 8</a></li>
      <li><a href="/wip.html">Page 9</a></li>
    </ul>
  </div>
  <!-- Block 4 -->
  <div class="block" style="grid-column: 1;">
    <h2><a href="/wip.html"><strong>Run Anywhere</strong></a></h2>
    <ul>
      <li><a href="/wip.html">Page 10</a></li>
      <li><a href="/wip.html">Page 11</a></li>
      <li><a href="/wip.html">Page 12</a></li>
    </ul>
  </div>
  <!-- Block 5 -->
  <div class="block" style="grid-column: 2;">
    <h2><a href="/wip.html"><strong>NUnit Tech</strong></a></h2>
    <ul>
      <li><a href="/wip.html">Page 13</a></li>
      <li><a href="/wip.html">Page 14</a></li>
      <li><a href="/wip.html">Page 15</a></li>
    </ul>
  </div>
  <!-- Block 6 -->
  <div class="block" style="grid-column: 3;">
    <h2><a href="/wip.html"><strong>Articles</strong></a></h2>
    <ul>
      <li><a href="/wip.html">Page 16</a></li>
      <li><a href="/wip.html">Page 17</a></li>
      <li><a href="/wip.html">Page 18</a></li>
    </ul>
  </div>
  <!-- Block 7 -->
  <div class="block" style="grid-column: 1;">
    <h2><a href="/developer-info/index.html"><strong>Developer Info</strong></a></h2>
    <ul>
      <li><a href="/developer-info/The-Teams.html">The Teams</a></li>
      <li><a href="/developer-info/Team-Practices.html">Team Practices</a></li>
      <li><a href="/developer-info/Coding-Standards.html">Coding Standards</a></li>
      <li><a href="/developer-info/Best-practices-for-XML-documentation.html">XML Documentation</a></li>
      <li><a href="/developer-info/Contributions.html">Contributions</a></li>
      <li><a href="/developer-info/Issue-Tracking.html">Issue Tracking</a></li>
      <li><a href="/developer-info/Notes-Toward-NUnit-4.0.html">NUnit 4.0 Plans</a></li>
      <li><a href="/developer-info/Packaging/index.html">Packaging</a></li>
    </ul>
  </div>
  <!-- Block 8 -->
  <div class="block" style="grid-column: 2;">
    <h2><a href="/wip.html"><strong>Advanced</strong></a></h2>
    <ul>
      <li><a href="/wip.html">Page 22</a></li>
      <li><a href="/wip.html">Page 23</a></li>
      <li><a href="/wip.html">Page 24</a></li>
    </ul>
  </div>
  <!-- Block 9 -->
  <div class="block" style="grid-column: 3;">
    <h2><a href="/wip.html"><strong>Archive</strong></a></h2>
    <ul>
      <li><a href="/wip.html">Page 25</a></li>
      <li><a href="/wip.html">Page 26</a></li>
      <li><a href="/wip.html">Page 27</a></li>
    </ul>
  </div>
</div>
