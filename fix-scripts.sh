#!/bin/bash

echo "== FIXING PERMISSIONS =="
chmod +x /workspaces/docs/diagnose.sh
chmod +x /workspaces/docs/simple-diagnose.sh
echo "Scripts should now be executable"

echo "== RUNNING DIAGNOSE SCRIPT WITH BASH =="
bash /workspaces/docs/simple-diagnose.sh
