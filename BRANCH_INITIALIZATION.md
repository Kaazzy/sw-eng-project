# Branch Initialization Guide

This guide is for the **repository administrator** to initialize the branch structure for the first time.

## Overview

After merging this PR, you'll need to create the three development branches (`front`, `back`, `api`) based on the `main` branch. This is a one-time setup.

## Prerequisites

- Merge this PR to create the initial documentation
- Have admin access to the repository
- Have Git installed locally

## Step-by-Step Setup

### Step 1: Update Your Local Repository

```bash
# Navigate to your local repository
cd sw-eng-project

# Fetch the latest changes
git fetch origin

# Switch to main branch (or the branch where docs were merged)
git checkout main
git pull origin main
```

### Step 2: Create the Development Branches

Create each development branch from `main`:

```bash
# Create front branch
git checkout -b front
git push -u origin front

# Create back branch
git checkout main
git checkout -b back
git push -u origin back

# Create api branch
git checkout main
git checkout -b api
git push -u origin api
```

### Step 3: Verify Branch Creation

```bash
# List all branches
git branch -a

# You should see:
# * api
#   back
#   front
#   main
#   remotes/origin/api
#   remotes/origin/back
#   remotes/origin/front
#   remotes/origin/main
```

### Step 4: Set Branch Protection Rules

Follow the detailed instructions in [REPOSITORY_SETUP.md](REPOSITORY_SETUP.md) to configure:

1. Branch protection for `main` (2 approvals required)
2. Branch protection for `front`, `back`, `api` (1 approval required)
3. Additional repository settings

**Quick Link**: Go to GitHub → Settings → Branches → Add rule

### Step 5: Configure Default Branch (Optional)

If `main` is not the default branch:

1. Go to GitHub repository Settings
2. Click "Branches" in sidebar
3. Under "Default branch", click the switch icon
4. Select `main`
5. Click "Update" and confirm

### Step 6: Notify Team Members

Once setup is complete, inform your team:

1. Share the repository URL
2. Point them to the [BRANCHING_STRATEGY.md](BRANCHING_STRATEGY.md)
3. Point them to the [GIT_CHEATSHEET.md](GIT_CHEATSHEET.md) for quick reference
4. Recommend they read [CONTRIBUTING.md](CONTRIBUTING.md)

**Example message to team:**
```
Hi team! 👋

Our repository branch structure is now ready:

📁 Repository: https://github.com/Kaazzy/sw-eng-project
📋 Branches: main, front, back, api

Please:
1. Clone the repository
2. Read the Branching Strategy guide: BRANCHING_STRATEGY.md
3. Check out the Git Cheatsheet: GIT_CHEATSHEET.md

When starting work:
- Frontend → create feature branches from 'front'
- Backend → create feature branches from 'back'  
- API → create feature branches from 'api'

Create PRs for code review before merging!

Questions? Check CONTRIBUTING.md or ask in our chat.
```

## Alternative: Script-Based Setup

If you prefer, you can use this script to create all branches at once:

```bash
#!/bin/bash

echo "Creating branch structure for sw-eng-project..."

# Ensure we're on main
git checkout main
git pull origin main

# Create and push front branch
echo "Creating front branch..."
git checkout -b front
git push -u origin front

# Create and push back branch
echo "Creating back branch..."
git checkout main
git checkout -b back
git push -u origin back

# Create and push api branch
echo "Creating api branch..."
git checkout main
git checkout -b api
git push -u origin api

# Return to main
git checkout main

echo "✅ All branches created successfully!"
echo ""
echo "Branches created:"
git branch -a | grep -E '(front|back|api|main)'

echo ""
echo "Next steps:"
echo "1. Configure branch protection rules (see REPOSITORY_SETUP.md)"
echo "2. Add team members as collaborators"
echo "3. Notify team that repository is ready"
```

Save this as `setup-branches.sh`, make it executable, and run:

```bash
chmod +x setup-branches.sh
./setup-branches.sh
```

## Verification Checklist

After completing the setup, verify:

- [ ] All four branches exist (main, front, back, api)
- [ ] `main` is the default branch
- [ ] Branch protection rules are configured
- [ ] All 5 team members have repository access
- [ ] Pull request template is visible when creating PRs
- [ ] Team has been notified with documentation links

## Troubleshooting

### Problem: Branch already exists
**Solution**: If a branch already exists, you can skip creating it or delete and recreate:
```bash
git push origin --delete front  # Delete remote branch
git branch -D front            # Delete local branch
# Then create fresh
```

### Problem: Permission denied when pushing
**Solution**: Ensure you have admin rights to the repository.

### Problem: Cannot set branch protection
**Solution**: Only repository admins can set branch protection rules. Check your repository permissions.

## Team Member Onboarding

When new team members join, have them:

1. **Clone the repository**
   ```bash
   git clone https://github.com/Kaazzy/sw-eng-project.git
   cd sw-eng-project
   ```

2. **Fetch all branches**
   ```bash
   git fetch --all
   ```

3. **Set up local tracking branches**
   ```bash
   git checkout -b front origin/front
   git checkout -b back origin/back
   git checkout -b api origin/api
   git checkout -b main origin/main
   ```

4. **Verify setup**
   ```bash
   git branch -a
   ```

5. **Read documentation**
   - [BRANCHING_STRATEGY.md](BRANCHING_STRATEGY.md) - Understand the workflow
   - [CONTRIBUTING.md](CONTRIBUTING.md) - Learn how to contribute
   - [GIT_CHEATSHEET.md](GIT_CHEATSHEET.md) - Quick reference

## Maintenance

### Adding New Team Members

1. Go to Settings → Collaborators and teams
2. Click "Add people"
3. Enter their GitHub username
4. Set permission to "Write"
5. Send them onboarding instructions

### Updating Documentation

Documentation should be kept in the `main` branch:

1. Create a feature branch from `main`
2. Update documentation files
3. Create PR to `main`
4. Merge after review

### Regular Maintenance

- **Weekly**: Check for stale branches and delete merged feature branches
- **Monthly**: Review branch protection rules
- **Quarterly**: Review and update documentation as team workflow evolves

## Need Help?

- Review [REPOSITORY_SETUP.md](REPOSITORY_SETUP.md) for detailed GitHub configuration
- Check [BRANCHING_STRATEGY.md](BRANCHING_STRATEGY.md) for workflow details
- Contact repository administrator

---

**Important**: This is a one-time setup. Once complete, the team can start working using the standard workflow described in BRANCHING_STRATEGY.md.
