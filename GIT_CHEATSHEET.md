# Git Quick Reference for sw-eng-project

A quick reference guide for common Git operations in our branching workflow.

## Daily Workflow Commands

### Starting Your Day

```bash
# Navigate to project
cd sw-eng-project

# Check current branch
git branch

# Update your local repository
git fetch --all

# Switch to and update the branch you're working on
git checkout front  # or back/api
git pull origin front
```

### Creating a Feature Branch

```bash
# From the appropriate base branch (front/back/api)
git checkout front
git pull origin front
git checkout -b feature/your-feature-name

# Example branch names:
# feature/user-login
# fix/button-alignment
# refactor/user-service
```

### Making Changes

```bash
# See what files changed
git status

# See specific changes
git diff

# Add files to staging
git add filename.cs           # Add specific file
git add .                     # Add all changed files
git add *.cs                  # Add all C# files

# Commit your changes
git commit -m "Brief description of changes"

# Push to remote
git push origin feature/your-feature-name

# First time pushing a new branch
git push -u origin feature/your-feature-name
```

### Updating Your Feature Branch

```bash
# Make sure you're on your feature branch
git checkout feature/your-feature-name

# Get latest from base branch
git fetch origin
git merge origin/front  # or back/api depending on your base

# Alternative: rebase (creates cleaner history)
git rebase origin/front
```

### Viewing Changes

```bash
# See commit history
git log
git log --oneline           # Compact view
git log --graph --oneline   # Visual graph

# See changes in a specific commit
git show <commit-hash>

# See changes between branches
git diff front..feature/your-feature-name

# See which files changed
git diff --name-only front..feature/your-feature-name
```

## Pull Request Workflow

### Creating a PR

```bash
# Make sure all changes are pushed
git push origin feature/your-feature-name

# Then go to GitHub and create a Pull Request
# Target: feature/your-feature-name → front (or back/api)
```

### After PR Approval

```bash
# Once merged, clean up
git checkout front  # or back/api
git pull origin front
git branch -d feature/your-feature-name  # Delete local branch
git push origin --delete feature/your-feature-name  # Delete remote branch (if not auto-deleted)
```

## Branch Management

### Switching Branches

```bash
# Switch to existing branch
git checkout front
git checkout back
git checkout api
git checkout main

# Create and switch to new branch
git checkout -b feature/new-feature

# List all branches
git branch              # Local branches
git branch -r           # Remote branches
git branch -a           # All branches
```

### Syncing Branches

```bash
# Update all remote tracking branches
git fetch --all

# Update current branch from remote
git pull

# Update specific branch
git pull origin front
```

### Deleting Branches

```bash
# Delete local branch (safe - won't delete if unmerged)
git branch -d feature/old-feature

# Force delete local branch
git branch -D feature/old-feature

# Delete remote branch
git push origin --delete feature/old-feature
```

## Handling Merge Conflicts

### When Conflicts Occur

```bash
# Pull latest changes from base branch
git pull origin front

# Git will tell you which files have conflicts
# Open conflicting files and look for:
# <<<<<<< HEAD
# Your changes
# =======
# Their changes
# >>>>>>> origin/front

# Edit files to resolve conflicts
# Remove conflict markers and keep desired code

# After resolving all conflicts
git add <resolved-files>
git commit -m "Resolve merge conflicts"
git push origin feature/your-feature-name
```

### Avoiding Conflicts

```bash
# Regularly sync with base branch
git checkout feature/your-feature-name
git fetch origin
git merge origin/front  # or back/api

# Keep feature branches short-lived
# Communicate with team about overlapping work
```

## Undoing Changes

### Undo Uncommitted Changes

```bash
# Discard changes to a specific file
git checkout -- filename.cs

# Discard all uncommitted changes (CAREFUL!)
git reset --hard HEAD

# Unstage a file (keep changes)
git reset HEAD filename.cs
```

### Undo Commits

```bash
# Undo last commit but keep changes
git reset --soft HEAD~1

# Undo last commit and discard changes (CAREFUL!)
git reset --hard HEAD~1

# Create a new commit that reverses a previous commit
git revert <commit-hash>
```

### Amend Last Commit

```bash
# Add forgotten changes to last commit
git add forgotten-file.cs
git commit --amend --no-edit

# Change last commit message
git commit --amend -m "New commit message"

# Note: Don't amend commits that have been pushed!
```

## Stashing Changes

### Save Work in Progress

```bash
# Save uncommitted changes
git stash

# Save with a message
git stash save "Work in progress on login feature"

# List stashes
git stash list

# Apply most recent stash
git stash apply

# Apply specific stash
git stash apply stash@{0}

# Apply and remove stash
git stash pop

# Delete a stash
git stash drop stash@{0}

# Clear all stashes
git stash clear
```

### Use Case for Stashing

```bash
# You're working on feature/login
# Urgent bug fix needed on another branch

git stash                    # Save current work
git checkout back           # Switch to back branch
git checkout -b fix/urgent-bug
# Fix the bug
git add .
git commit -m "Fix urgent bug"
git push origin fix/urgent-bug
git checkout feature/login   # Return to your feature
git stash pop               # Restore your work
```

## Checking Repository Status

### Useful Status Commands

```bash
# Current status
git status

# Short status
git status -s

# See remote URLs
git remote -v

# See which remote branch your local branch tracks
git branch -vv

# See unpushed commits
git log origin/front..HEAD

# See unmerged branches
git branch --no-merged
```

## Tagging Releases

### Creating Tags

```bash
# Create annotated tag (recommended)
git tag -a v1.0.0 -m "Version 1.0.0 release"

# Create lightweight tag
git tag v1.0.0

# Tag specific commit
git tag -a v1.0.0 <commit-hash> -m "Version 1.0.0"

# Push tag to remote
git push origin v1.0.0

# Push all tags
git push origin --tags
```

### Listing and Deleting Tags

```bash
# List tags
git tag

# List tags with pattern
git tag -l "v1.*"

# Delete local tag
git tag -d v1.0.0

# Delete remote tag
git push origin --delete v1.0.0
```

## Collaboration Tips

### Before Starting Work

```bash
git fetch --all
git checkout front  # or back/api
git pull origin front
```

### Before Creating a PR

```bash
# Make sure your branch is up to date
git fetch origin
git merge origin/front  # or back/api

# Run tests
dotnet test

# Review your changes
git diff origin/front..HEAD
```

### Reviewing Someone's PR

```bash
# Fetch the PR branch
git fetch origin pull/123/head:pr-123
git checkout pr-123

# Test it locally
dotnet build
dotnet test

# Return to your branch
git checkout front
```

## Emergency Procedures

### Accidentally Committed to Wrong Branch

```bash
# If you haven't pushed yet:
git reset --soft HEAD~1  # Undo commit, keep changes
git stash                # Save changes
git checkout correct-branch
git stash pop            # Apply changes
git add .
git commit -m "Your message"
```

### Need to Sync Fork (if applicable)

```bash
# Add upstream remote (one time only)
git remote add upstream https://github.com/Kaazzy/sw-eng-project.git

# Fetch upstream changes
git fetch upstream

# Merge upstream changes
git checkout main
git merge upstream/main
git push origin main
```

## Helpful Aliases (Optional)

Add to your `~/.gitconfig`:

```ini
[alias]
    st = status -s
    co = checkout
    br = branch
    ci = commit
    unstage = reset HEAD --
    last = log -1 HEAD
    visual = log --graph --oneline --all
    amend = commit --amend --no-edit
```

Usage after setup:
```bash
git st      # Instead of git status -s
git co main # Instead of git checkout main
git br      # Instead of git branch
```

## Common Issues and Solutions

### Issue: "Your branch is ahead of 'origin/front' by X commits"
```bash
git push origin front
```

### Issue: "Your branch is behind 'origin/front' by X commits"
```bash
git pull origin front
```

### Issue: "Cannot push to protected branch"
```bash
# This is expected for main/front/back/api
# Create a feature branch and PR instead
```

### Issue: "Merge conflict"
```bash
# See "Handling Merge Conflicts" section above
```

## Resources

- [Git Official Documentation](https://git-scm.com/doc)
- [GitHub Git Cheat Sheet](https://education.github.com/git-cheat-sheet-education.pdf)
- [Atlassian Git Tutorials](https://www.atlassian.com/git/tutorials)

---

**Pro Tip**: Use `git help <command>` for detailed help on any Git command
Example: `git help commit`
