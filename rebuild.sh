#!/bin/bash

echo "==== STARTING REBUILD PROCESS ===="
echo "Current directory: $(pwd)"

# First, ensure we're in the right directory
cd /workspaces/docs

# Check if _site directory exists
echo "==== CHECKING FOR _SITE DIRECTORY ===="
if [ -d "docs/_site" ]; then
    echo "_site directory found, cleaning it..."
    rm -rf docs/_site
    echo "_site directory removed"
else
    echo "No _site directory found, nothing to clean"
fi

# Navigate to docs directory and run build
echo "==== RUNNING DOCFX BUILD ===="
cd docs
docfx build

# Verify the output
echo "==== VERIFYING BUILD OUTPUT ===="
if [ -d "_site" ]; then
    echo "_site directory created successfully"
    echo "Directories in _site:"
    ls -la _site/
    
    # Check for developer-info directory
    if [ -d "_site/developer-info" ]; then
        echo "developer-info directory found in _site"
        echo "Contents of developer-info directory:"
        ls -la _site/developer-info/
    else
        echo "developer-info directory NOT found in _site"
    fi
else
    echo "ERROR: _site directory was not created!"
fi

echo "==== BUILD PROCESS COMPLETED ===="
