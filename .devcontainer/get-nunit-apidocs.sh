echo "SEAN WAS HERE"

NUNIT_VERSION_FOR_API_DOCS="4.0.0"

first_workspace="$(cd /workspaces && ls | head -1)"

wget "https://github.com/nunit/nunit/releases/download/v$NUNIT_VERSION_FOR_API_DOCS/NUnit.Framework-$NUNIT_VERSION_FOR_API_DOCS.zip" -O apidocs.zip


mkdir $first_workspace/code-output 
unzip -o apidocs.zip -d $first_workspace/code-output
mv ./apidocs/NUnit.Framework-$NUNIT_VERSION_FOR_API_DOCS/bin/net6.0 $first_workspace/code-output
