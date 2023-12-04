# This script gets the 

NUNIT_VERSION_FOR_API_DOCS="4.0.0"

first_workspace="$(cd /workspaces && ls | head -1)"

wget "https://github.com/nunit/nunit/releases/download/v$NUNIT_VERSION_FOR_API_DOCS/NUnit.Framework-$NUNIT_VERSION_FOR_API_DOCS.zip" -O /apidocs.zip


mkdir -p /workspaces/$first_workspace/code-output 
unzip -o /apidocs.zip -d /apidocs
cp -r /apidocs/bin/net6.0/* /workspaces/$first_workspace/code-output
rm -rf /apidocs.zip
rm -rf /apidocs