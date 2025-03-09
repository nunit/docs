#!/bin/bash

echo "==== STARTING DIAGNOSTIC BUILD ===="
echo "Current directory: $(pwd)"

# Check file structure and permissions
echo "==== CHECKING FILE STRUCTURE ===="
echo "Checking for developer-info directory:"
find docs -name "developer-info" -type d
echo "Checking for TOC files:"
find docs -name "toc.yml"
echo "Content of developer-info directory:"
find docs/developer-info -type f | sort

# Check file permissions
echo "==== CHECKING FILE PERMISSIONS ===="
ls -la docs/developer-info/
ls -la docs/developer-info/toc.yml

# Check file content
echo "==== CHECKING TOC CONTENT ===="
echo "Content of main toc.yml:"
cat docs/toc.yml
echo "Content of developer-info toc.yml:"
cat docs/developer-info/toc.yml 2>/dev/null || echo "File not found"

# Clean build directory
echo "==== CLEANING BUILD DIRECTORY ===="
rm -rf docs/_site

# Run build with extreme verbosity
echo "==== RUNNING BUILD ===="
cd docs
docfx build --force --verbose

# Check output
echo "==== CHECKING BUILD OUTPUT ===="
echo "Files in _site directory:"
find _site -type f | grep -v "\.git" | sort

echo "==== BUILD COMPLETED ===="
