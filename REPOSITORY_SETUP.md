# GitHub Repository Setup Guide

This guide helps repository administrators set up the branch protection rules and settings for optimal team collaboration.

## Initial Branch Creation

### Step 1: Create the Required Branches

The repository needs four main branches. If they don't exist yet, create them:

```bash
# Ensure you're in the repository directory
cd sw-eng-project

# Create and push the main branch (if not exists)
git checkout -b main
git push -u origin main

# Create and push the front branch
git checkout -b front
git push -u origin front

# Create and push the back branch  
git checkout -b back
git push -u origin back

# Create and push the api branch
git checkout -b api
git push -u origin api
```

### Step 2: Set Default Branch

1. Go to repository Settings on GitHub
2. Navigate to "Branches" in the left sidebar
3. Under "Default branch", click the switch icon
4. Select `main` as the default branch
5. Click "Update" and confirm

## Branch Protection Rules

### For `main` Branch (Production)

**Purpose**: Protect production code with strict requirements

1. Go to Settings → Branches → "Add rule"
2. Branch name pattern: `main`
3. Configure the following settings:

**Require a pull request before merging**
- ✅ Require approvals: `2`
- ✅ Dismiss stale pull request approvals when new commits are pushed
- ✅ Require review from Code Owners (if CODEOWNERS file exists)

**Require status checks to pass before merging**
- ✅ Require branches to be up to date before merging
- Select status checks (if CI/CD is configured):
  - Build
  - Test
  - Lint

**Other settings**
- ✅ Require conversation resolution before merging
- ✅ Require linear history (optional, for cleaner history)
- ✅ Include administrators (enforce rules for admins too)

**Do not allow**
- ✅ Do not allow bypassing the above settings

4. Click "Create" to save the rule

### For `front`, `back`, and `api` Branches (Development)

**Purpose**: Require code review while allowing faster iteration

Repeat the following for each branch (`front`, `back`, `api`):

1. Go to Settings → Branches → "Add rule"
2. Branch name pattern: `front` (or `back`, `api`)
3. Configure the following settings:

**Require a pull request before merging**
- ✅ Require approvals: `1`
- ✅ Dismiss stale pull request approvals when new commits are pushed

**Require status checks to pass before merging** (if CI/CD configured)
- ✅ Require branches to be up to date before merging
- Select relevant status checks

**Other settings**
- ✅ Require conversation resolution before merging

**Allow specific users to bypass** (optional)
- Add senior developers who may need to merge urgent fixes

4. Click "Create" to save the rule

## Additional Repository Settings

### General Settings

**Navigation**: Settings → General

1. **Features**
   - ✅ Issues
   - ✅ Projects (if using GitHub Projects)
   - ✅ Wiki (optional)
   - ✅ Discussions (optional, for team communication)

2. **Pull Requests**
   - ✅ Allow merge commits
   - ✅ Allow squash merging (recommended for cleaner history)
   - ✅ Allow rebase merging
   - ✅ Always suggest updating pull request branches
   - ✅ Automatically delete head branches (cleanup after merge)

### Collaborators and Teams

**Navigation**: Settings → Collaborators and teams

Add your 5 team members with appropriate permissions:

1. Click "Add people" or "Add teams"
2. Enter GitHub usernames
3. Set permission level:
   - **Write**: For all team members (can push to non-protected branches)
   - **Maintain**: For team leads (can manage some settings)
   - **Admin**: For repository administrators

### Code Owners (Optional but Recommended)

Create a CODEOWNERS file to automatically request reviews from specific team members:

```bash
# Create CODEOWNERS file
mkdir -p .github
nano .github/CODEOWNERS
```

Example CODEOWNERS content:
```
# Default owners for everything in the repo
* @team-lead-username

# Frontend code
/frontend/ @frontend-developer1 @frontend-developer2
*.cshtml @frontend-developer1
*.css @frontend-developer1
*.js @frontend-developer1

# Backend code
/backend/ @backend-developer1 @backend-developer2
/Services/ @backend-developer1
/Models/ @backend-developer1

# API code  
/Controllers/ @api-developer1 @api-developer2
/api/ @api-developer1

# Configuration files
*.config @team-lead-username
*.json @team-lead-username
```

Commit and push the CODEOWNERS file:
```bash
git add .github/CODEOWNERS
git commit -m "Add CODEOWNERS file"
git push origin main
```

### Repository Notifications

Help team members stay informed:

1. **Navigation**: Settings → Notifications
2. Configure:
   - ✅ Notify on pull request reviews
   - ✅ Notify on mentions
   - ✅ Notify on issues assigned

### Actions/CI-CD (If Using GitHub Actions)

**Navigation**: Settings → Actions → General

1. **Actions permissions**
   - Allow all actions and reusable workflows (or restrict as needed)

2. **Workflow permissions**  
   - Read and write permissions (adjust based on your needs)

3. **Artifact and log retention**: 90 days (default)

## Setting Up CI/CD (Optional but Recommended)

Create basic GitHub Actions workflows for automated testing:

### Example: .NET Build and Test Workflow

Create `.github/workflows/dotnet.yml`:

```yaml
name: .NET Build and Test

on:
  push:
    branches: [ main, front, back, api ]
  pull_request:
    branches: [ main, front, back, api ]

jobs:
  build:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v3
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '8.0.x'  # Adjust to your .NET version
    
    - name: Restore dependencies
      run: dotnet restore
    
    - name: Build
      run: dotnet build --no-restore
    
    - name: Test
      run: dotnet test --no-build --verbosity normal
```

## Quick Setup Checklist

Use this checklist when setting up a new repository:

- [ ] Create all four branches (main, front, back, api)
- [ ] Set `main` as default branch
- [ ] Configure branch protection for `main` (2 approvals)
- [ ] Configure branch protection for `front` (1 approval)
- [ ] Configure branch protection for `back` (1 approval)
- [ ] Configure branch protection for `api` (1 approval)
- [ ] Add all 5 team members as collaborators
- [ ] Create CODEOWNERS file (optional)
- [ ] Enable auto-delete of merged branches
- [ ] Set up CI/CD workflows (optional)
- [ ] Create issue templates (optional)
- [ ] Set up project boards (optional)

## Verification

After setup, verify everything works:

1. **Test branch protection**:
   - Try pushing directly to `main` (should fail)
   - Create a PR to `main` (should require 2 approvals)
   - Create a PR to `front`/`back`/`api` (should require 1 approval)

2. **Test workflow**:
   - Create a feature branch from `front`
   - Make a small change
   - Push and create PR
   - Verify CI runs (if configured)
   - Merge after approval

## Troubleshooting

### Issue: Can't push to protected branch
**Solution**: This is expected. Create a pull request instead.

### Issue: PR can't be merged without approvals
**Solution**: Request reviews from team members.

### Issue: Status checks not appearing
**Solution**: Ensure GitHub Actions workflows are properly configured and have run at least once.

### Issue: CODEOWNERS not working
**Solution**: 
- File must be in `.github/CODEOWNERS`, `docs/CODEOWNERS`, or root `CODEOWNERS`
- Users must have write access to the repository
- Branch protection must have "Require review from Code Owners" enabled

## Need Help?

- [GitHub Branch Protection Documentation](https://docs.github.com/en/repositories/configuring-branches-and-merges-in-your-repository/managing-protected-branches)
- [CODEOWNERS Documentation](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-code-owners)
- [GitHub Actions Documentation](https://docs.github.com/en/actions)

---

**Note**: These settings ensure code quality while keeping the workflow simple and clean for your 5-member team.
