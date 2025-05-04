# This script gets the the latest version of NUnit and extracts it. This is because docfx is capable of generating API docs, and this way the Codespace will be automatically enabled to do that.

# This is hard-coded for now.
NUNIT_VERSION_FOR_API_DOCS="4.3.2"

first_workspace="$(cd /workspaces && ls | head -1)"

wget "https://github.com/nunit/nunit/releases/download/$NUNIT_VERSION_FOR_API_DOCS/NUnit.Framework-$NUNIT_VERSION_FOR_API_DOCS.zip" -O /apidocs.zip


mkdir -p /workspaces/$first_workspace/code-output 
unzip -o /apidocs.zip -d /apidocs
cp -r /apidocs/bin/net8.0/* /workspaces/$first_workspace/code-output
rm -rf /apidocs.zip
rm -rf /apidocs