#!/bin/bash

# Print the current directory
echo "Starting from directory: $(pwd)"

# Check permissions on our scripts
echo "Checking permissions on scripts:"
ls -la *.sh

# Make sure the scripts are executable
echo "Ensuring scripts are executable:"
chmod +x *.sh
echo "Done"

# Try running docfx directly
echo "=== RUNNING DOCFX DIRECTLY ==="
cd docs
echo "Changed to docs directory: $(pwd)"

# Check for _site directory and remove if present
if [ -d "_site" ]; then
  echo "Found _site directory, removing it"
  rm -rf _site
  if [ $? -ne 0 ]; then
    echo "ERROR: Failed to remove _site directory"
    echo "This could be a permissions issue"
  else
    echo "Successfully removed _site directory"
  fi
else
  echo "No _site directory found"
fi

# Run docfx with error checking
echo "Running docfx build..."
docfx build
build_status=$?

# Check the exit status
if [ $build_status -ne 0 ]; then
  echo "ERROR: DocFX build failed with exit code $build_status"
  echo "This indicates there was an error in the build process"
else
  echo "DocFX build completed successfully"
  
  # Check if developer-info was built
  if [ -d "_site/developer-info" ]; then
    echo "SUCCESS: developer-info directory found in _site"
    echo "Contents:"
    ls -la _site/developer-info/
  else
    echo "WARNING: developer-info directory NOT found in _site"
    echo "This suggests the files were not included in the build output"
  fi
fi

echo "Check completed"
