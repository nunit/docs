#!/bin/bash

echo "==== DocFX CONTENT DIAGNOSTIC ===="

# Check DocFX configuration
echo "Checking docfx.json location:"
find /workspaces/docs -name "docfx.json" | sort

# Check working directory structure
echo "Top-level directories in /workspaces/docs:"
ls -la /workspaces/docs

echo "Contents of /workspaces/docs/docs directory:"
ls -la /workspaces/docs/docs

# Check if key files exist in expected locations
echo "Looking for index.md files:"
find /workspaces/docs -name "index.md" | sort

echo "Looking for developer-info directory:"
find /workspaces/docs -name "developer-info" -type d

echo "Files in developer-info directory:"
find /workspaces/docs/docs/developer-info -type f | sort

# Run a simple clean build
echo "==== RUNNING CLEAN BUILD ===="
cd /workspaces/docs/docs
rm -rf _site
docfx build

# Check output size and structure
echo "==== CHECKING BUILD OUTPUT ===="
find /workspaces/docs/docs/_site -type d | sort

echo "File count in _site by directory:"
find /workspaces/docs/docs/_site -type f | grep -o "^/workspaces/docs/docs/_site/[^/]*" | sort | uniq -c

echo "Checking for developer-info content in _site:"
find /workspaces/docs/docs/_site -path "*developer-info*" | sort

echo "==== DIAGNOSTIC COMPLETE ===="
