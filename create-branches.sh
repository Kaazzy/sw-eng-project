#!/bin/bash

# Script to create the required branches for the sw-eng-project repository
# This script creates front, back, and api branches from the main branch

set -e

echo "Creating required branches: front, back, api"
echo "=============================================="
echo ""

# Ensure we have the latest main branch
echo "Fetching latest main branch..."
git fetch origin main

# Create and push front branch
echo "Creating and pushing front branch..."
git push origin origin/main:refs/heads/front

# Create and push back branch
echo "Creating and pushing back branch..."
git push origin origin/main:refs/heads/back

# Create and push api branch
echo "Creating and pushing api branch..."
git push origin origin/main:refs/heads/api

echo ""
echo "=============================================="
echo "Successfully created all required branches!"
echo "Branches created:"
echo "  - front"
echo "  - back"
echo "  - api"
echo ""
echo "You can now check out these branches:"
echo "  git checkout front"
echo "  git checkout back"
echo "  git checkout api"
