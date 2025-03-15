#!/bin/bash

echo "=== SIMPLE DIAGNOSTIC SCRIPT ==="
echo "Current directory: $(pwd)"

echo "=== CHECKING DOCFX.JSON ==="
cd /workspaces/docs/docs
if [ -f "docfx.json" ]; then
    echo "docfx.json found in /workspaces/docs/docs"
else
    echo "docfx.json NOT found in /workspaces/docs/docs"
fi

echo "=== CHECKING DEVELOPER-INFO ==="
if [ -d "developer-info" ]; then
    echo "developer-info directory found in /workspaces/docs/docs"
    echo "Files in developer-info:"
    ls -la developer-info
else
    echo "developer-info directory NOT found in /workspaces/docs/docs"
fi

echo "=== CHECKING TOC.YML FILES ==="
if [ -f "toc.yml" ]; then
    echo "Main toc.yml found"
    echo "Content:"
    cat toc.yml
else
    echo "Main toc.yml NOT found"
fi

if [ -f "developer-info/toc.yml" ]; then
    echo "developer-info/toc.yml found"
    echo "Content:"
    cat developer-info/toc.yml
else
    echo "developer-info/toc.yml NOT found"
fi

echo "=== CHECKING FOR INDEX FILES ==="
if [ -f "developer-info/index.md" ]; then
    echo "developer-info/index.md found"
else
    echo "developer-info/index.md NOT found - this could be causing issues"
fi

echo "=== RUNNING SIMPLE BUILD ==="
rm -rf _site
docfx build

echo "=== CHECKING OUTPUT ==="
if [ -d "_site/developer-info" ]; then
    echo "developer-info directory found in output"
    ls -la _site/developer-info
else
    echo "developer-info directory NOT found in output"
fi

echo "=== DIAGNOSTIC COMPLETE ==="
